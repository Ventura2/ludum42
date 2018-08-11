using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShrinkPlatform : MonoBehaviour {

    public float ShrinkPerSecond = 5;





    private void Update() {

        if (transform.localScale.x <= 0) {
            Destroy(this.gameObject);
        }

        Vector3 newScale = transform.localScale;
        newScale.x -= ShrinkPerSecond * Time.deltaTime;

        transform.localScale = newScale;

    }

}
