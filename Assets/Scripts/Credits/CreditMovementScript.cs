using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditMovementScript : MonoBehaviour {
    float speed = 5f;

	// Update is called once per frame
	void Update () {
        Vector3 position = transform.position;
        position.y += speed * Time.deltaTime;

        transform.position = position;
	}
}
