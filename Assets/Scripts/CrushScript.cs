using UnityEngine;

public class CrushScript : MonoBehaviour {


    private BoxCollider2D boxCollider;

    private void Start() {
        boxCollider = this.GetComponent<BoxCollider2D>();
    }

    private void Update() {
        

    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Platform")) {
            Debug.Log("aplastado");
        }
    }
}

