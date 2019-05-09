using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameSession : MonoBehaviour {

    [SerializeField] int playerLives = 3;
    [SerializeField] int score = 0;
   

    [SerializeField] Text livesText;
    [SerializeField] Text scoreText;
    [SerializeField] Text healthText;

    PlayerHealth health;
    GameObject player;

    private void Awake() {
        //singleton pattern used to only have one object.
        int numGameSessions = FindObjectsOfType<GameSession>().Length;
        if (numGameSessions > 1) {
            Destroy(gameObject);
        } else {
            DontDestroyOnLoad(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start() {
        livesText.text = playerLives.ToString();
        scoreText.text = score.ToString();
        health = GetComponent<PlayerHealth>();
        player = GameObject.FindGameObjectWithTag("Player");


    }

    // Update is called once per frame
    void Update() {
        ShowHealth();
    }

    public void AddToScore(int pointsToAdd) {
        score += pointsToAdd;
        scoreText.text = score.ToString();
    }

    public void ProcessPlayerDeath() {
        if(playerLives > 1) {
            TakeLife();
        }else {
            ResetGameSession();
        }
    }

    private void TakeLife() {
        playerLives = playerLives - 1;
        var currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
        livesText.text = playerLives.ToString();
    }

    private void ResetGameSession() {
        SceneManager.LoadScene(0);
        Destroy(gameObject);
    }

    public void ShowHealth() {
        healthText.text = player.gameObject.GetComponent<PlayerHealth>().currentHealth.ToString();
    }
}
