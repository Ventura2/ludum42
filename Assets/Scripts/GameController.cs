using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum GameState { Playing, Death}

public class GameController : MonoBehaviour {

    public int counterTime = 5;
    public float restartTime = 0.5f;
    public static GameController instance;

    GameState gameState = GameState.Playing;

    // Use this for initialization
    void Awake () {
	    if(instance == null) {
            instance = this;
        }

        gameState = GameState.Playing;
	}

    private void Start() {
        if (CounterScript.instance != null) {
            CounterScript.instance.SetTimer(counterTime);
        }
    }

    void Update() {
        if (gameState == GameState.Death) {
            Invoke("RestartLevel", restartTime);
        }
    }

    void RestartLevel() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void SetGameState (GameState gameState) {
        this.gameState = gameState;
    }

    public GameState GetGameState() {
        return this.gameState;
    }

}
