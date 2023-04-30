using UnityEngine;

[System.Serializable]
public class PlayerContorller : MonoBehaviour{
    public float speed = 5f;

    [SerializeField] private KeyBindings KeyBinds;

    private Vector2 MoveInput;
    private Rigidbody2D rb;
    private int Health = 5;

    private void Start() {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update() {
        MoveInput.x = InputX();
        MoveInput.y = InputY();

        if (Health <= 0) {
            Destroy(gameObject);
        }
    }

    private void FixedUpdate() {
        float ForceX = MoveInput.normalized.x * speed * Time.deltaTime;
        float ForceY = MoveInput.normalized.y * speed * Time.deltaTime;

        rb.MovePosition(rb.position + new Vector2 (ForceX, ForceY));
    }

    private float InputX() {
        if (Input.GetKey(KeyBinds.GetKey("moveRight"))) {
            return 1f;
        } else if (Input.GetKey(KeyBinds.GetKey("moveLeft"))) {
            return -1f;
        }

        return 0f;
    }

    private float InputY() {
        if (Input.GetKey(KeyBinds.GetKey("moveUp"))) {
            return 1f;
        } else if (Input.GetKey(KeyBinds.GetKey("moveDown"))) {
            return -1f;
        }

        return 0f;
    }

    public void TakeDamage(int Damage = 1) {
        Health -= Damage;
        Debug.Log(Health);
    }
}
