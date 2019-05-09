using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

    [SerializeField] float moveSpeed;
    [SerializeField] GameObject player;
    [SerializeField] GameObject leftCollider;
    [SerializeField] GameObject rightCollider;
    [SerializeField] float minJumpTime;
    [SerializeField] float maxJumpTime;
    Rigidbody2D enemyRigidbody;
    CapsuleCollider2D enemyCapsuleCollider2D;
    BoxCollider2D enemyBoxCollider2D;
    CircleCollider2D enemyCircleCollider2D;
    bool playerInRange;
    Animator enemyAnimator;
    public Transform target;

    // Start is called before the first frame update
    void Start() {
        enemyRigidbody = GetComponent<Rigidbody2D>();
        enemyCapsuleCollider2D = GetComponent<CapsuleCollider2D>();
        enemyAnimator = GetComponent<Animator>();
        target = player.gameObject.GetComponent<Transform>();

    }

    // Update is called once per frame
    void Update() {
        MoveEnemy();
        //Jump();
        //need to figure out how to use the localscale to flip the 
        //sprite and make the enemy change direction based on what side the player hits it
    }

    public void SetMovementSpeed(float speed) {
        moveSpeed = speed;
    }

   public void MoveEnemy() {
        if (IsFacingRight()) {
            enemyRigidbody.velocity = new Vector2(moveSpeed, 0f);
        } else {
            enemyRigidbody.velocity = new Vector2(-moveSpeed, 0f);
        }
    }

    private bool IsFacingRight() {
        return transform.localScale.x > 0;
    }

    /*
    IEnumerator Jump() {
        LayerMask player = LayerMask.GetMask("Player");
        if (leftCollider.GetComponent<BoxCollider2D>().IsTouchingLayers(player) || rightCollider.GetComponent<BoxCollider2D>().IsTouchingLayers(player)) {
            enemyAnimator.SetBool("isJumping", true);
            yield return new WaitForSeconds(Random.Range(minJumpTime, maxJumpTime));
        }

    }
    */

        /*

    private void OnTriggerExit2D(Collider2D collision) {
        //so this is used to flip the sprite one way or the other based on its scale in the game        
        
            transform.localScale = new Vector2(-(Mathf.Sign(enemyRigidbody.velocity.x)), 1f);
        
       
    }
    */
}





