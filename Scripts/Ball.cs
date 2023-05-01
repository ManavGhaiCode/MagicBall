using UnityEngine;

public class Ball : MonoBehaviour {
    private Rigidbody2D rb;

    [SerializeField] private Transform ResetPosition;

    private void Start() {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update() {
        if (rb.velocity.magnitude > 7) {
            rb.velocity = rb.velocity.normalized * 7;
        }
    }

    public void ResetBall() {
        transform.position = ResetPosition.position;
        rb.velocity = Vector2.zero;
    }
}