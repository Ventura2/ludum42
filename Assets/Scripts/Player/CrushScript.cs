using UnityEngine;

public class CrushScript : MonoBehaviour {

    PlayerDeath playerDeath;
    private BoxCollider2D boxCollider;

    private void Start() {
        playerDeath = this.GetComponentInParent<PlayerDeath>();
        boxCollider = this.GetComponent<BoxCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Platform")) {
            playerDeath.Death();
        }
    }
}

