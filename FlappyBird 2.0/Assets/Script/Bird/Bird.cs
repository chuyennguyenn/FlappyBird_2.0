using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class Bird : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    int Id;

    private PlayerInput playerInput;
    private InputAction skill;
    private bool skillReady = true;
    private bool skillActive = false;

    private void Start()
    {

        playerInput = GetComponent<PlayerInput>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        var characterManager = CharacterManager.instance;
        if (characterManager != null && characterManager.SelectedCharacterSprite != null)
        {
            spriteRenderer.sprite = characterManager.SelectedCharacterSprite;
            Debug.Log("Bird sprite set to: " + spriteRenderer.sprite.name);
        }

        Id = characterManager.SelectedCharacterId;

        skill = playerInput.actions["Skill"];
    }

    private void Update()
    {
        if (skill.WasPressedThisFrame() && skillReady && !skillActive)
        {
            switch (Id)
            {
                case 0:
                    SlowDown();
                    break;

                case 1:
                    Shrink();
                    break;

                case 2:
                    Ghost();
                    break;
            }
        }
    }

    private void SlowDown()
    {
        Time.timeScale = 0.5f;
        skillActive = true;
        StartCoroutine(BackToNormalTime());
    }

    private void Shrink()
    {
        transform.localScale = new Vector3(0.5f, 0.5f, 1f);
        skillActive = true;
        StartCoroutine(BackToNormalSize());
    }

    private void Ghost()
    {
        Collider2D collider = GetComponent<Collider2D>();
        collider.enabled = false;

        Color color = spriteRenderer.color; 
        color.a = 0.5f; // transparent
        spriteRenderer.color = color; 
        skillActive = true;
        StartCoroutine(BackToNormalCollider(collider));
    }

    private IEnumerator BackToNormalTime()
    {
        yield return new WaitForSeconds(3f);
        Time.timeScale = 1f;
        skillReady = false;
        StartCoroutine(CoolDown());
    }

    private IEnumerator BackToNormalSize()
    {
        yield return new WaitForSeconds(8f);
        transform.localScale = new Vector3(1f, 1f, 1f);
        skillReady = false;
        StartCoroutine(CoolDown());
    }

    private IEnumerator BackToNormalCollider(Collider2D collider)
    {
        yield return new WaitForSeconds(5f);

        collider.enabled = true;

        Color color = spriteRenderer.color;
        color.a = 1f; // normal
        spriteRenderer.color = color;

        skillReady = false;
        StartCoroutine(CoolDown());
    }

    private IEnumerator CoolDown()
    {
        yield return new WaitForSeconds(5f);
        skillReady = true;
        skillActive = false;
    }
}
