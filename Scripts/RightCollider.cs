using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightCollider : MonoBehaviour {

    [SerializeField] GameObject player;
    [SerializeField] GameObject fireDeamon;
    Rigidbody2D enemyRigidbody;
    BoxCollider2D enemyBoxCollider2D;
    EnemyMovement movement;
    bool playerInRange;
    Animator enemyAnimator;
    public Transform target;

    // Start is called before the first frame update
    void Start() {
        enemyRigidbody = GetComponent<Rigidbody2D>();
        enemyBoxCollider2D = GetComponent<BoxCollider2D>();
        enemyAnimator = GetComponent<Animator>();
        target = player.gameObject.GetComponent<Transform>();
        movement = GetComponent<EnemyMovement>();
    }

    // Update is called once per frame
    void Update() {

    }

    void OnTriggerEnter2D(Collider2D other) {
        // If the entering collider is the player...

        if (other.gameObject == player) {
            // ... the player is in range.
            playerInRange = true;

            LayerMask playerLayer = LayerMask.GetMask("Player");
            if (playerInRange && enemyBoxCollider2D.IsTouchingLayers(playerLayer)) {
                fireDeamon.GetComponent<Animator>().SetBool("isWalking", false);
                fireDeamon.GetComponent<Animator>().SetBool("isRunning", true);
                fireDeamon.transform.localScale = new Vector2((Mathf.Sign(fireDeamon.GetComponent<Rigidbody2D>().velocity.x)), 1f);


                // transform.localScale = new Vector2(-(Mathf.Sign(enemyRigidbody.velocity.x)), 1f);
                //transform.localScale = new Vector2((Mathf.Sign(enemyRigidbody.velocity.x)), 1f);


            }
        }
    }

    void OnTriggerExit2D(Collider2D other) {
        // If the exiting collider is the player...
        if (other.gameObject == player) {
            // ... the player is no longer in range.
            playerInRange = false;
            LayerMask playerLayer = LayerMask.GetMask("Player");
            if (!playerInRange && !enemyBoxCollider2D.IsTouchingLayers(playerLayer)) {
                fireDeamon.GetComponent<Animator>().SetBool("isRunning", false);
                fireDeamon.GetComponent<Animator>().SetBool("isWalking", true);

            }
        }
        /*
        private void OnTriggerEnter2D(Collider2D other) {

        }

        private void OnTriggerExit2D(Collider2D collision) {
        //so this is used to flip the sprite one way or the other based on its scale in the game        
        transform.localScale = new Vector2(-(Mathf.Sign(enemyRigidbody.velocity.x)), 1f);
            }
            */

    }
}
