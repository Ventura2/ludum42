using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncreasePlatform : MonoBehaviour {

    public float IncreasePerSecond = 5;

    private GameController gameController;

    void Start() {
        if (GameController.instance != null) {
            gameController = GameController.instance;
        }
    }


    private void Update() {
        if (gameController.GetGameState() != GameState.Death) {
            ReducePlatform();
        }

    }

    private void ReducePlatform() {

        float yMovement = IncreasePerSecond * Time.deltaTime;

        transform.position += new Vector3(0, yMovement, 0);

    }


}
