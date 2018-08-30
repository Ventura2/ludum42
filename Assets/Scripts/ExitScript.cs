using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitScript : MonoBehaviour {

    private static ExitScript instance;

    private void Awake() {
        if (instance == null) {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else {
            Destroy(this.gameObject);
        }
    }
	
	void Update () {
		if(Input.GetKeyDown(KeyCode.Escape)) {
            Application.Quit();
        }
	}
}
