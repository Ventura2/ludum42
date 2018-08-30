using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    private const float MIN_HORIZONTAL_AXIS = 0.01f;

    public float xVelocity = 1;
    public float jumpForce = 4;


    private Rigidbody2D rigidBody;

    private float oldXVelocity;
    private bool isVelocityPoweredUp = false;
    private float expireTimePowerUp;

    private bool jumping;

    private bool facingRight;

    public AudioSource jumpingAudioSource;
    public AudioSource powerUpAudioSource;

    public SimpleTouchPad movementTouchPad;
    public TouchAreaButton touchAreaButton;

	void Start () {
        facingRight = true;
        rigidBody = GetComponent<Rigidbody2D>();

#if UNITY_ANDROID
        movementTouchPad = GameObject.FindGameObjectWithTag("MovementTouchPad").GetComponent<SimpleTouchPad>();
        touchAreaButton = GameObject.FindGameObjectWithTag("JumpZone").GetComponent<TouchAreaButton>();
#endif

    }

    private void Update() {
        if (isVelocityPoweredUp && powerUpExpired()) {
            resetVelocity();
        }
    }

    private bool powerUpExpired() {
        return Time.time > expireTimePowerUp;
    }

    private void resetVelocity() {
            xVelocity = oldXVelocity;
            Debug.Log("Powerup Finished");
    }

    void FixedUpdate() {

        float jumpVelocity = getJumpVelocity();
        float horizontalMovement = getHorizontalMovement();

        rigidBody.velocity = new Vector2(horizontalMovement, jumpVelocity);

        
        if (isLookingToWrongDirection(horizontalMovement)) {
            Flip();
        }
	}



    private float getJumpVelocity() {
        float jumpVelocity = rigidBody.velocity.y;
        if (canJump()) {
            jumpingAudioSource.Play();
            jumpVelocity = jumpForce;
            jumping = true;
        }

        return jumpVelocity;
    }

    private bool canJump() {
        bool buttonPressed;

#if UNITY_ANDROID
        buttonPressed = touchAreaButton.IsTouched();
#else
        buttonPressed = Input.GetButton("Jump");
#endif

        return buttonPressed && !jumping;
    }

    private float getHorizontalMovement() {
        float horizontalMovement = rigidBody.velocity.x;

        float xAxis = 0f;

#if UNITY_ANDROID
         xAxis = movementTouchPad.GetDirection().x;
#else
            xAxis = Input.GetAxis("Horizontal");
#endif

        if (enoughAxis(xAxis, MIN_HORIZONTAL_AXIS)) {
            horizontalMovement = xAxis * xVelocity;
        }
        return horizontalMovement;
    }


    private bool enoughAxis(float xAxis, float min) {
        return xAxis > min || xAxis < -min;
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Platform")) {
            jumping = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {

        jumping = true;
    }

    internal void OnPowerUpVelocity(float newVelocity, float totalTime) {
        oldXVelocity = xVelocity;
        xVelocity = newVelocity;

        this.expireTimePowerUp = Time.time + totalTime;

        isVelocityPoweredUp = true;
        powerUpAudioSource.Play();
    }


    private bool isLookingToWrongDirection(float horizontalMovement) {
        return (horizontalMovement > 0.1f && !facingRight) || (horizontalMovement < -0.1f && facingRight);
    }
    private void Flip() {
            facingRight = !facingRight;
            Vector3 scale = transform.localScale;
            scale.x *= -1;
            transform.localScale = scale;
       
    }

}
