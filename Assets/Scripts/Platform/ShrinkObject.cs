using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShrinkObject : MonoBehaviour {

    public Vector2 shrinkObjectPerSecond = new Vector2(1f,1f);

    GameController gameController;

    private void Start() {
        if(gameController == null) {
            gameController = GameController.instance;
        }
    }

    void Update () {
		
        if(gameController.GetGameState() == GameState.Playing) {
            Shrink();
        }
	}

    private void Shrink() {
        Vector3 newScale = transform.localScale;
        newScale.x -= shrinkObjectPerSecond.x * Time.deltaTime;
        newScale.y -= shrinkObjectPerSecond.y * Time.deltaTime;

        transform.localScale = newScale;
    }
}
