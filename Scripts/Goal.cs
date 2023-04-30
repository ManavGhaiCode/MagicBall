using UnityEngine;

public class Goal : MonoBehaviour {
    [SerializeField] private PlayerContorller Player;

    private void OnTriggerEnter2D(Collision2D hitInfo) {
        Ball ball = hitInfo.collider.GetComponent<Ball>();

        if (ball != null) {
            Player.TakeDamage();
        }
    }
}
