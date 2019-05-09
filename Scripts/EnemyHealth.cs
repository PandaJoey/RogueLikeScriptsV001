using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour {

     [SerializeField] float startingHealth;
     [SerializeField] float currentHealth;

    Animator enemyAnimator;
   
    BoxCollider2D enemyBoxCollider2D;
    bool isAlive;

    // Start is called before the first frame update
    void Start() {
        enemyAnimator = GetComponent<Animator>();
        enemyBoxCollider2D = GetComponent<BoxCollider2D>();
        currentHealth = startingHealth;
    }

    // Update is called once per frame
    void Update() {
        if (!isAlive) {
            return;
        }
        EnemyDie();
    }

    public void EnemieTakeDamage(float damage) {
       currentHealth -= damage;
        if(currentHealth <= 0) {
            EnemyDie();
        }
    }

    void EnemyDie() {
        isAlive = false;

        enemyBoxCollider2D.isTrigger = true;

        enemyAnimator.SetTrigger("Die");

        Destroy(gameObject);

    }
}
