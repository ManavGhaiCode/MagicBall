using UnityEngine;

public class ball : MonoBehaviour {
    private Rigidbody2D rb;

    private void Start() {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update() {
        if (rb.velocity.magnitude > 10) {
            rb.velocity = rb.velocity.normalized * 10;
        }
    }
}