using UnityEngine;

public class Core : MonoBehaviour {
    [SerializeField] private PlayerContorller Player;

    private void OnTriggerEnter2D(Collider2D hitInfo) {
        if (Player != null) {
            Ball ball = hitInfo.GetComponent<Ball>();

            if (ball != null) {
                Player.TakeDamage();
                hitInfo.GetComponent<Ball>().ResetBall();
            }
        }
    }
}
