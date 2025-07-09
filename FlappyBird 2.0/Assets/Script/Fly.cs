using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Fly : MonoBehaviour
{
    [SerializeField] private float flySpeed = 1.0f; // how much "goes up" when button is pressed
    [SerializeField] private float rotationSpeed = 10f;

    GameManager gameManager;

    private Rigidbody2D rb;

    public bool invincible;
    public bool shieldActive; 
    private Coroutine shieldCoroutine;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        gameManager = FindFirstObjectByType<GameManager>();
        invincible = false;
    }

    private void Update()
    {
        if (!gameManager.started)
        {
            rb.gravityScale = 0;
            return;
        }

        if (Mouse.current.leftButton.isPressed)
        {
            rb.linearVelocity = Vector2.up * flySpeed; // move up
        }

        float t = Time.timeSinceLevelLoad;

        rb.gravityScale = Mathf.Min(1.2f, Mathf.Lerp(0.8f, 1.2f, t / 120f)); // gravity stronger overtime
        flySpeed = Mathf.Min(1.5f, Mathf.Lerp(1.0f, 1.5f, t / 120f)); // fly "height" stronger overtime
        
    }

    private void FixedUpdate()
    {
        if (!GameManager.instance.started) return;

        transform.rotation = Quaternion.Euler(0, 0, rb.linearVelocity.y * rotationSpeed);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name != "SkyBox")
        {
            if (!invincible)
            {
                gameManager.GameOver();
            }
            else if (shieldActive)
            {
                // End shield immediately on first hit
                shieldActive = false;
                if (shieldCoroutine != null)
                {
                    StopCoroutine(shieldCoroutine);
                    shieldCoroutine = null;
                }
                Debug.Log("Shield broken by collision!");
                StartCoroutine(BeingInvincible());
            }
        }
    }

    public void ActivateShield()
    {
        if (shieldCoroutine != null)
            StopCoroutine(shieldCoroutine);

        shieldCoroutine = StartCoroutine(ShieldRoutine());
    }

    private IEnumerator ShieldRoutine()
    {
        invincible = true;
        shieldActive = true;
        float timer = 0f;
        float duration = 5f;

        while (timer < duration && shieldActive)
        {
            timer += Time.deltaTime;
            yield return null;
        }

        invincible = false;
        shieldActive = false;
        shieldCoroutine = null;
    }

    private IEnumerator BeingInvincible()
    {
        yield return new WaitForSeconds(1f); // invincibility lasts for 5 seconds
        Debug.Log("Invincibility ended!");
        invincible = false;
    }
}
