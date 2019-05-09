using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour {

    // Config called before we start the game
    [SerializeField] GameObject player;
    public float damage = 10;
    PlayerHealth playerHealth;
    Animator enemyAnimator;
    bool playerInRange;
    BoxCollider2D enemyBoxCollider;
    CapsuleCollider2D enemyCapsuleCollider2D;
    float timeToWaitBeforeNextAttack = 2.0f;


    // Start is called before the first frame update
    void Start() {
        playerHealth = GetComponent<PlayerHealth>();
        enemyAnimator = GetComponent<Animator>();
        enemyBoxCollider = GetComponent<BoxCollider2D>();
        enemyCapsuleCollider2D = GetComponent<CapsuleCollider2D>();

    }

    // Update is called once per frame
    void Update() {
        Attack(player);


    }

    public void Attack(GameObject target) {
        if (target == player && enemyBoxCollider.IsTouchingLayers(LayerMask.GetMask("Player")) ) {
            GetComponent<Animator>().SetBool("isAttacking", true);
        }else if(!enemyBoxCollider.IsTouchingLayers(LayerMask.GetMask("Player"))) {
            GetComponent<Animator>().SetBool("isAttacking", false);
        }

    }


    public void StrikeCurrentTarget(float damage) {
        if (player && enemyCapsuleCollider2D.IsTouching(player.GetComponent<CapsuleCollider2D>())) {
            player.GetComponent<PlayerHealth>().TakeDamage(damage);
        }
    }
    


}


