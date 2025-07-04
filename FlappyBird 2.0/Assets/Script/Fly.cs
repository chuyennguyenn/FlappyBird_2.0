using UnityEngine;
using UnityEngine.InputSystem;

public class Fly : MonoBehaviour
{
    [SerializeField] private float flySpeed = 1.5f; // Speed of the fly
    [SerializeField] private float rotationSpeed = 10f; // Speed of the fly's rotation

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Mouse.current.leftButton.isPressed)
        {
            rb.linearVelocity  = Vector2.up * flySpeed; // Move the fly upwards when the left mouse button is pressed
        }

        float t = Time.timeSinceLevelLoad;

        rb.gravityScale = Mathf.Min(1.2f, Mathf.Lerp(0.8f, 1.2f, t / 120f)); // Gradually reduce gravity scale over time

    }

    private void FixedUpdate()
    {
        transform.rotation = Quaternion.Euler(0, 0, rb.linearVelocity.y * rotationSpeed); // Rotate the fly based on its vertical velocity
    }
}
