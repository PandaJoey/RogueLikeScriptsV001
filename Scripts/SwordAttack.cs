using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordAttack : MonoBehaviour {

   
    [SerializeField] GameObject enemy;

    PlayerController playerMovement;
    PlayerAttack playerAttack;

    Animator animator;
    CapsuleCollider2D swordCapsuleCollider2D;
   
    
    public GameObject player;


    private void Awake() {
     
    }
    // Start is called before the first frame update
    void Start() {
        animator = GetComponent<Animator>();
        playerMovement = player.GetComponent<PlayerController>();
        swordCapsuleCollider2D = GetComponentInChildren<CapsuleCollider2D>();
        playerAttack = player.GetComponent<PlayerAttack>();
    }

    // Update is called once per frame
    void Update() {
        RunningAnimation();
        AttackAnimation();

    }

    public void DealDamage(float damage) {
        if (swordCapsuleCollider2D.IsTouching(enemy.GetComponent<BoxCollider2D>())) {
            enemy.GetComponent<EnemyHealth>().EnemieTakeDamage(damage);
        }else {
            return; 
        }
    }

    public void RunningAnimation() {
        if (playerMovement.GetComponent<Animator>().GetBool("isRunning")) {
            animator.SetBool("isRunning", true);
        }else
            animator.SetBool("isRunning", false);
    }

    public void AttackAnimation() {
        if (playerMovement.GetComponent<Animator>().GetBool("isAttacking") == true && Input.GetButtonDown("Attack")) {
            animator.SetBool("isAttacking", true);
        } else {
            animator.SetBool("isAttacking", false);
        }
       
    }
}

