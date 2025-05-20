using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    public GameObject[] platforms;
    public float platformSpacing = 3f;
    public float spawnWidth = 6f;

    private float nextSpawnY = 1f;
    private Transform player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        // Spawn initial platforms
        for (int i = 0; i < 20; i++)
        {
            SpawnPlatform();
        }
    }

    // void Update()
    // {
    //     if (player.position.y + 5f > nextSpawnY)
    //     {
    //         SpawnPlatform();
    //     }
    // }

    void SpawnPlatform()
    {
        Vector3 spawnPos = new Vector3(transform.position.x + Random.Range(-spawnWidth, spawnWidth), nextSpawnY, 0);
        int randomIndex = Random.Range(0, platforms.Length);
        Instantiate(platforms[randomIndex], spawnPos, Quaternion.identity);

        nextSpawnY += platformSpacing;
    }
}





