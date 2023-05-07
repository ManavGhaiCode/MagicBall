using System.Collections;
using UnityEngine;

public class Ball : MonoBehaviour {
    private Rigidbody2D rb;
    private GameObject LastHitObj;
    private float TimeBetLastCol = 1f;

    [SerializeField] private Transform ResetPosition;
    [SerializeField] private GameObject HitParticleSys;
    [SerializeField] private GameObject BallRDParticalEffect;
    [SerializeField] private GameObject BallRSParticalEffect;

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

    private IEnumerator ResetPos() {
        float SponTime = 4f;

        Instantiate(BallRDParticalEffect,transform.position, Quaternion.identity);

        transform.position = new Vector2(0, 20);
        rb.velocity = Vector2.zero;

        yield return new WaitForSeconds(.2f);

        Instantiate(BallRSParticalEffect, ResetPosition.position, Quaternion.identity);

        yield return new WaitForSeconds(.05f);

        Instantiate(BallRSParticalEffect, ResetPosition.position, Quaternion.identity);
        transform.position = ResetPosition.position;

        while (SponTime > 0) {
            SponTime -= Time.deltaTime;
            float t = (4f - SponTime) * 2.5f;

            transform.localScale = Vector3.Lerp(Vector3.zero, new Vector3 (1, 1, 1), t);

            yield return new WaitForSeconds(Time.deltaTime);
        }
    }

    public void ResetBall() {
        StartCoroutine(ResetPos());
    }
}