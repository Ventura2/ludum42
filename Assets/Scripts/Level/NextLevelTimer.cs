using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevelTimer : MonoBehaviour {

    public int timeToNext = 10;

    private float nextTime;
	// Use this for initialization
	void Start () {
        nextTime = Time.time + timeToNext;
	}
	
	// Update is called once per frame
	void Update () {
		
        if(Time.time > nextTime || Input.GetButtonDown("Jump") || Input.GetButtonDown("Fire1")) {
            NextLevel();
        }

	}
    
    private void NextLevel() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
