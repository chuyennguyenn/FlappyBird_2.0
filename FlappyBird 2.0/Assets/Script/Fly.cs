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
    private Animator animator;

    public bool invincible;
    public bool shieldActive; 

    private Coroutine shieldCoroutine;
    private PlayerInput playerInput;
    private InputAction skill;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        gameManager = FindFirstObjectByType<GameManager>();
        animator = GetComponent<Animator>();
        playerInput = GetComponent<PlayerInput>();

        invincible = false;

        skill = playerInput.actions["Skill"];

    }

    private void Update()
    {
        if (!gameManager.started)
        {
            rb.gravityScale = 0;
            return;
        }

        DifficultyIncrease();

        if (Mouse.current.leftButton.isPressed)
        {
            rb.linearVelocity = Vector2.up * flySpeed; // move up
        }

        if (skill.WasPressedThisFrame())
        {
            Time.timeScale = 0.5f;
            StartCoroutine(BackToNormal());
        }
       
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
                animator.SetTrigger("Invincible");
                StartCoroutine(BeingInvincible());
            }
        }
    }

    public void ActivateShield()
    {
        if (shieldCoroutine != null)
            StopCoroutine(shieldCoroutine);

        animator.SetBool("Shield", true);
        shieldCoroutine = StartCoroutine(ShieldRoutine());
    }

    public void DifficultyIncrease()
    {
        float t = Time.timeSinceLevelLoad;

        rb.gravityScale = Mathf.Min(1.2f, Mathf.Lerp(0.8f, 1.2f, t / 120f)); // gravity stronger overtime
        flySpeed = Mathf.Min(1.5f, Mathf.Lerp(1.0f, 1.5f, t / 120f)); // fly "height" stronger overtime

    }

    private IEnumerator ShieldRoutine()
    {
        invincible = true;
        shieldActive = true;
        float timer = 0f;
        float duration = 8f;

        while (timer < duration && shieldActive)
        {
            timer += Time.deltaTime;
            yield return null;
        }

        animator.SetBool("Shield", false);
        invincible = false;
        shieldActive = false;
        shieldCoroutine = null;
    }

    private IEnumerator BeingInvincible()
    {
        yield return new WaitForSeconds(1f);
        Debug.Log("Invincibility ended!");
        animator.SetBool("Shield", false);
        invincible = false;
    }

    private IEnumerator BackToNormal()
    {
        yield return new WaitForSeconds(5f);
        Time.timeScale = 1f;
    }
}
