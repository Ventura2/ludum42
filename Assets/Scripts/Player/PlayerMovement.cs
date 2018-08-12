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

	// Use this for initialization
	void Start () {
        rigidBody = GetComponent<Rigidbody2D>();
	}

    // Update is called once per frame
    void Update() {

        float jumpVelocity = getJumpVelocity();
        float horizontalMovement = getHorizontalMovement();

        rigidBody.velocity = new Vector2(horizontalMovement, jumpVelocity);

        if (isVelocityPoweredUp) {
            UpdatePowerUp();
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

    internal void OnPowerUpVelocity(float newVelocity, float totalTime) {
        oldXVelocity = xVelocity;
        xVelocity = newVelocity;

        this.expireTimePowerUp = Time.time + totalTime;

        isVelocityPoweredUp = true;
    }

}
