using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour {


    private bool isDeath = false;


    public void Death() {
        isDeath = true;

        if (GameController.instance != null) {
            GameController.instance.SetGameState(GameState.Death);
        }

        Destroy(this.gameObject);
    }


    public bool isPlayerDeath() {
        return isDeath;
    }
}
