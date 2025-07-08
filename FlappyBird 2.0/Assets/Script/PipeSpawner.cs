using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    [SerializeField] private GameObject EasyPipePrefab; 
    [SerializeField] private GameObject MidPipePrefab; 
    [SerializeField] private GameObject HardPipePrefab; 
    [SerializeField] private GameObject SpeicalPipePrefab; 
    [SerializeField] private float spawnInterval = 1.75f; 

    private float timer = 0f;

    GameManager gameManager;

    private void Start()
    {
        gameManager = FindFirstObjectByType<GameManager>();
    }
    private void Update()
    {
        if (!gameManager.started) return; // spawn pipes if the game has started

        timer += Time.deltaTime;

        if (timer > spawnInterval)
        {
            SpawnPipe();
            timer = 0f;
        }
    }
    private void SpawnPipe()
    {
        float randomHeight = 0f;
        int randomDifficulty = Random.Range(0,4);                                                   // 1 in 4 chance to spawn a special pipe
        //int randomDifficulty = 0;

        GameObject pipePrefab = null;
        
        if (randomDifficulty == 0)
        {
            pipePrefab = SpeicalPipePrefab; 
            randomHeight = Random.Range(0.15f, -0.15f);
            //Debug.Log("Special Pipe Spawned at " + transform.position);
        }
        else
        {
            float easyChance = Mathf.Lerp(0.65f, 0f, Time.timeSinceLevelLoad / 120f);               // easy: 65% -> 0%
            float midChance = Mathf.Lerp(0.25f, 0.5f, Time.timeSinceLevelLoad / 120f);              // mid: 25% -> 50%
            float hardChance = 1f - easyChance - midChance;                                         // fill the rest (10% → 50%)

            float randomPipe = Random.Range(0f, 1f);

            if (randomPipe < easyChance)
            {
                pipePrefab = EasyPipePrefab;
                randomHeight = Random.Range(-1.25f, 0.4f);
                //Debug.Log("Easy Pipe Spawned at " + transform.position);
            }
            else if (randomPipe < easyChance + midChance)
            {
                pipePrefab = MidPipePrefab;
                randomHeight = Random.Range(-1f, 0.65f);
                //Debug.Log("Mid Pipe Spawned at " + transform.position);
            }
            else
            {
                pipePrefab = HardPipePrefab;
                randomHeight = Random.Range(-0.45f, 0.95f);
                //Debug.Log("Hard Pipe Spawned at " + transform.position);
            }
        }

            Vector3 spawnPos = transform.position + new Vector3(0, randomHeight, 0);

        if (pipePrefab != null) 
        {
            GameObject pipe = Instantiate(pipePrefab, spawnPos, Quaternion.identity);
            Destroy(pipe, 8f); 
        }
    }
}
