using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour {

    [SerializeField] Image healthBar;
    [SerializeField] PlayerHealth player;
    [SerializeField] EnemyDamage enemy;
    float maxHealth;
    public static float health;



    private void Awake() {
        healthBar = GetComponent<Image>();
        player = GetComponent<PlayerHealth>();
        maxHealth = player.startingHealth;
        health = player.currentHealth;
    }
    // Start is called before the first frame update
    void Start() {
        

    }

    // Update is called once per frame
    void Update() {
        SetHealthBar();
    }

    public void SetHealthBar() {
        healthBar.fillAmount = health / maxHealth;
    }
}


   