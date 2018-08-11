using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CounterScript : MonoBehaviour {

    public static CounterScript instance;
    public ShowPlop plop;

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
        timer -= Time.deltaTime;

        counterText.text = "" + (int)timer;


        if(timer <= 0.5f) {
            counterText.color = new Color(counterText.color.r, counterText.color.g, counterText.color.b, 0.0f);
            plop.Show();
        }
    }

    public void SetTimer(int timer) {
        this.timer = timer;
    }
}
