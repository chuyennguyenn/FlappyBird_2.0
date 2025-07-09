using UnityEngine;

public class Star : MonoBehaviour
{
    ScoreManager scoreManager;

    private void Start()
    {
        scoreManager = FindFirstObjectByType<ScoreManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            scoreManager.score += 3; 
            Destroy(gameObject); 
        }
    }
}
