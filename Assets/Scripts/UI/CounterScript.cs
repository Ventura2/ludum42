using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CounterScript : MonoBehaviour {

    public static CounterScript instance;

    private float timer = 5;

    private Text counterText;

    private void Awake() {
        if(instance == null) {
            instance = this;
        }
    }

    void Start() {
        counterText = GetComponent<Text>();
    }

    void Update() {
        if(GameController.instance != null) {
            if (GameController.instance.GetGameState() == GameState.Death)
                return;
        }


        timer -= Time.deltaTime;

        counterText.text = "" + (int)timer;


        if(timer <= 0.5f) {
            counterText.color = new Color(counterText.color.r, counterText.color.g, counterText.color.b, 0.0f);
        }
    }

    public void SetTimer(int timer) {
        this.timer = timer;
    }
}
