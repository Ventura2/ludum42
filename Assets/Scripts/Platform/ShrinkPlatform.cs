using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShrinkPlatform : MonoBehaviour {

    public float ShrinkPerSecond = 5;

    private GameController gameController;

    void Start() {
        if(GameController.instance != null) {
            gameController = GameController.instance;
        }
    }


    private void Update() {
        if(gameController.GetGameState() != GameState.Death) {
            ReducePlatform();
        }

    }

    private void ReducePlatform() {

        if (transform.localScale.x <= 0) {
            Destroy(this.gameObject);
        }

        Vector3 newScale = transform.localScale;
        newScale.x -= ShrinkPerSecond * Time.deltaTime;

        transform.localScale = newScale;
    }

}
