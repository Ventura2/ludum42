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
	void Start () {
        facingRight = true;
        rigidBody = GetComponent<Rigidbody2D>();

    }

    void Update() {

        float jumpVelocity = getJumpVelocity();
        float horizontalMovement = getHorizontalMovement();

        rigidBody.velocity = new Vector2(horizontalMovement, jumpVelocity);


        if (isVelocityPoweredUp) {
            UpdatePowerUp();
        }

        if (isLookingToWrongDirection(horizontalMovement)) {
            Flip();
        }
	}


    private void UpdatePowerUp() {
        
        if(Time.time > expireTimePowerUp) {
            xVelocity = oldXVelocity;
            Debug.Log("Powerup Finished");
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
        return Input.GetButtonDown("Jump") && !jumping;
    }

    private float getHorizontalMovement() {
        float horizontalMovement = rigidBody.velocity.x;
        float xAxis = Input.GetAxis("Horizontal");

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
