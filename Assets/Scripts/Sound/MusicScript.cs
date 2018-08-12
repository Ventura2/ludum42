using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicScript : MonoBehaviour {
    
    public static MusicScript instance;


    void Awake() {
        if ((instance != null && instance != this) || SceneManager.GetActiveScene().buildIndex == (SceneManager.sceneCountInBuildSettings - 1)) {
            Destroy(this.gameObject);
            return;
        } else {
            instance = this;
        }
        DontDestroyOnLoad(this.gameObject);

       
    }

    private void Update() {
        if (SceneManager.GetActiveScene().buildIndex == (SceneManager.sceneCountInBuildSettings - 1)) {
            Destroy(this.gameObject);
        }
    }


}
