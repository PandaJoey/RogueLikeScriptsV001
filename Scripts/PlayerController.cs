using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.UI;


public class PlayerController : MonoBehaviour {

    // Config aka before we start the game
    [SerializeField] float runSpeed;
    [SerializeField] float jumpSpeed;
    [SerializeField] float jumpForce;
    [SerializeField] float climbSpeed;
   
    // State
    private bool isAlive = true;

    // Cached variables
    private Rigidbody2D myRigidbody;
    private Animator playerAnimator;
    CapsuleCollider2D playerBodyCollider;
    CircleCollider2D playerFeet;
    float gravityScaleAtStart;

    // Messages and methods
    // Start is called before the first frame update
    void Start() {
        myRigidbody = GetComponent<Rigidbody2D>();
        gravityScaleAtStart = myRigidbody.gravityScale;
        playerAnimator = GetComponent<Animator>();
        playerBodyCollider = GetComponent<CapsuleCollider2D>();
        playerFeet = GetComponent<CircleCollider2D>();
    }

    // Update is called once per frame
    void Update() {
        if (!isAlive) {
            return;
        }
        Run();
        ClimbLadder();
        Jump();
        FlipSprite();
    }

    private void Run() {
        float move = CrossPlatformInputManager.GetAxis("Horizontal");
        Vector2 playerVelocity = new Vector2(move * runSpeed, myRigidbody.velocity.y);
        myRigidbody.velocity = playerVelocity;
        bool playerHasHorizontalSpeed = Mathf.Abs(myRigidbody.velocity.x) > Mathf.Epsilon;
        playerAnimator.SetBool("isRunning", playerHasHorizontalSpeed);

    }

    private void ClimbLadder() {
        LayerMask layer = LayerMask.GetMask("Ladder");
        if (!playerFeet.IsTouchingLayers(layer)) {
            playerAnimator.SetBool("isClimbing", false);
            myRigidbody.gravityScale = gravityScaleAtStart;
            return;
        }

        float climb = CrossPlatformInputManager.GetAxis("Vertical");
        Vector2 climbVelocity = new Vector2(myRigidbody.velocity.x, climb * climbSpeed);
        myRigidbody.velocity = climbVelocity;
        myRigidbody.gravityScale = 0f;
        bool playerVerticalSpeed = Mathf.Abs(myRigidbody.velocity.y) > Mathf.Epsilon;
        playerAnimator.SetBool("isClimbing", playerVerticalSpeed);

    }

    private void Jump() {
        LayerMask layer = LayerMask.GetMask("Ground");
        if (!playerFeet.IsTouchingLayers(layer)) {
            return;
        }

        if (CrossPlatformInputManager.GetButtonDown("Jump")) {
            Vector2 jumpVelocityToAdd = new Vector2(0f, jumpSpeed);
            myRigidbody.velocity += jumpVelocityToAdd;
        }
    }

    private void FlipSprite() {
        bool playerHasHorizontalSpeed = Mathf.Abs(myRigidbody.velocity.x) > Mathf.Epsilon;
        if (playerHasHorizontalSpeed) {
            transform.localScale = new Vector2(Mathf.Sign(myRigidbody.velocity.x), 1f);
        }
    }
}


 

