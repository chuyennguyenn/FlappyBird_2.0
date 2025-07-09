using UnityEngine;

public class Shield : MonoBehaviour
{
    Fly fly;

    private void Start()
    {
        fly = FindFirstObjectByType<Fly>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            fly.ActivateShield();
            Destroy(gameObject);
        }    
    }
}
