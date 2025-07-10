using UnityEngine;

public class CollectibleSpawn : MonoBehaviour
{
    public GameObject star;
    public GameObject shield;

    private void Start()
    {
        //Debug.Log("CollectibleSpawn started");
        int randomSpawn = Random.Range(0, 6);

        if (randomSpawn == 0)
        {
            //Debug.Log("Spawning");
            Spawning();
        }
    }

    private void Spawning()
    {
        float chance = Random.Range(0f, 1f);

        if (chance < 0.7f)
        {
            //Debug.Log("Spawning Star");
            Instantiate(star, transform.position, Quaternion.identity, transform);
        }
        else
        {
            //Debug.Log("Spawning Shield");
            Instantiate(shield, transform.position, Quaternion.identity, transform);
        }
    }
}
