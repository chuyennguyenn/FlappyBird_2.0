using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Fly : MonoBehaviour
{
    [SerializeField] private float flySpeed = 1.0f; // how much "goes up" when button is pressed
    [SerializeField] private float rotationSpeed = 10f;

    GameManager gameManager;

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        gameManager = FindFirstObjectByType<GameManager>();
    }

    private void Update()
    {
        if (!gameManager.started)
        {
            rb.gravityScale = 0;
        }
        else
        {
            if (Mouse.current.leftButton.isPressed)
            {
                rb.linearVelocity = Vector2.up * flySpeed; // move up
            }

            float t = Time.timeSinceLevelLoad;

            rb.gravityScale = Mathf.Min(1.2f, Mathf.Lerp(0.8f, 1.2f, t / 120f)); // gravity stronger overtime
            flySpeed = Mathf.Min(1.5f, Mathf.Lerp(1.0f, 1.5f, t / 120f)); // fly speed stronger overtime
        }

    }

    private void FixedUpdate()
    {
        if (!GameManager.instance.started) return;

        transform.rotation = Quaternion.Euler(0, 0, rb.linearVelocity.y * rotationSpeed);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        gameManager.GameOver();
    }
}
