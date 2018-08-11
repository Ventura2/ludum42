using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollCamera : MonoBehaviour {

    public const float minStopDistance = 0.01f;

    public float force = 3;
    public float boundary = 0f;

    private bool following;

    GameObject player;
    GameController gameController;



	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        gameController = GameController.instance;
	}
	
	void FixedUpdate () {

        if (isPlaying()) {
            UpdateCameraPosition();
		   
        }
    }

    private void UpdateCameraPosition() {
        if (isInBoundaries(player.transform)) {
            following = true;
        }

        if (following) {
            Follow(player.transform);

            if (isCloseEnough(player.transform)) {
                following = false;
            }

        }
    }

    private bool isCloseEnough(Transform player) {
        Vector2 vectorTarget = getVectorTarget(player);

        return vectorTarget.sqrMagnitude <= minStopDistance;
    }

    private Vector2 getVectorTarget(Transform player) {
        return player.position - transform.position; 
    }

    private bool isPlaying() {
        return gameController != null && gameController.GetGameState() == GameState.Playing;
    }

    private bool isInBoundaries(Transform player) {
        Vector2 vectorTarget = getVectorTarget(player);

        return vectorTarget.sqrMagnitude > boundary;

    }

    void Follow(Transform thing) {
        Vector2 vectorTarget = getVectorTarget(thing);
        Vector2 smoothMovement = force* vectorTarget * Time.deltaTime;

        transform.position += new Vector3(smoothMovement.x, smoothMovement.y, 0.0f);


    }
}
