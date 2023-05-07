using UnityEngine;

public class Ball : MonoBehaviour {
    private Rigidbody2D rb;
    private GameObject LastHitObj;
    private float TimeBetLastCol = 1f;

    [SerializeField] private Transform ResetPosition;
    [SerializeField] private GameObject HitParticleSys;

    private void Start() {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update() {
        if (rb.velocity.magnitude > 7) {
            rb.velocity = rb.velocity.normalized * 7;
        }
        
        TimeBetLastCol -= Time.deltaTime;

        if (TimeBetLastCol <= 0) {
            LastHitObj = null;
        }
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (LastHitObj != other.gameObject) {
            Vector2 contact = other.contacts[0].point;
            Instantiate(HitParticleSys, contact, Quaternion.identity);

            LastHitObj = other.gameObject;
            TimeBetLastCol = 1f;
        }
    }

    public void ResetBall() {
        transform.position = ResetPosition.position;
        rb.velocity = Vector2.zero;
    }
}