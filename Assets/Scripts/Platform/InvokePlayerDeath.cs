using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvokePlayerDeath : MonoBehaviour {

    private PlayerDeath player;

    private void Start() {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerDeath>();

    }


    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Player")) {
            player.Death();
        }
    }
}
