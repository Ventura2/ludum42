using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpVelocity : MonoBehaviour {

    public float velocity = 5f;
    public float timePowerUp = 3f;

    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.CompareTag("Player")) {

            collision.GetComponent<PlayerMovement>().OnPowerUpVelocity(velocity, timePowerUp);
            Destroy(this.gameObject);
        }
    }
}
