using UnityEngine;

public class TriggerZone : MonoBehaviour
{
    ScoreManager scoreManager;

    private void Start()
    {
        scoreManager = FindFirstObjectByType<ScoreManager>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        scoreManager.score += 1;
    }
}
