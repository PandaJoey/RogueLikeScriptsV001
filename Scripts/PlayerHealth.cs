using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {
    
    
    [SerializeField] Vector2 deathRoll = new Vector2(100f, 250f);
    [SerializeField] GameObject enemy;
    public float startingHealth = 100f;
    public float currentHealth;
    public Image healthImage;
    public Text healthNumber;

    // State
    private bool isAlive = true;

    // Cached variables
    private Rigidbody2D myRigidbody;
    private Animator myAnimator;
    PlayerController playerController;
    CapsuleCollider2D myBodyCollider;
    CircleCollider2D myFeet;

    /*
    void Awake() {
        myRigidbody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        myBodyCollider = GetComponent<CapsuleCollider2D>();
        myFeet = GetComponent<CircleCollider2D>();
        playerController = GetComponent<PlayerController>();
        currentHealth = startingHealth;
    }
    */

    private void Start() {
        myRigidbody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        myBodyCollider = GetComponent<CapsuleCollider2D>();
        myFeet = GetComponent<CircleCollider2D>();
        playerController = GetComponent<PlayerController>();
        currentHealth = startingHealth;
        isAlive = true;
    }


    // Update is called once per frame
    void Update() {
        if (!isAlive) {
            return;
        }
        //Die();
        
    }

    private void Die() {
        isAlive = false;
        myAnimator.SetTrigger("Die");
        GetComponent<Rigidbody2D>().velocity = deathRoll;
        FindObjectOfType<GameSession>().ProcessPlayerDeath();
    }

    public void TakeDamage(float damage) {
        if (currentHealth > 0 && myBodyCollider.IsTouchingLayers(LayerMask.GetMask("Enemy", "Traps"))
           || myFeet.IsTouchingLayers(LayerMask.GetMask("Enemy", "Traps"))) {
            currentHealth -= damage;
            healthImage.fillAmount = currentHealth / startingHealth;
        } else if (currentHealth <= 0) {
            Die();
        }
        
    }
}
