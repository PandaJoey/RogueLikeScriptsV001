using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelExit : MonoBehaviour {

    [SerializeField] float timeToWait = 2f;
    [SerializeField] float levelSlow = 0.2f;


    private void OnTriggerEnter2D(Collider2D collision) {
        StartCoroutine(ExitLevel());
    }

    IEnumerator ExitLevel() {
        Time.timeScale = levelSlow;
        yield return new WaitForSeconds(timeToWait);
        Time.timeScale = 1f;
        var currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }
}
