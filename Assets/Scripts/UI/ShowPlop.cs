using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowPlop : MonoBehaviour {

    Text text;

    void Start() {
        text = GetComponent<Text>();
    }
	
	void Update () {
		if(GameController.instance != null) {
            if(GameController.instance.GetGameState() == GameState.Death) {
                Show();
            }
        }
	}

    public void Show() {
        text.color = new Color(text.color.r, text.color.g, text.color.b, 1.0f);
    }
}
