using UnityEngine;

public class P_latformSpawner : MonoBehaviour
{
    public GameObject platformPrefab;
    public GameObject potionPrefab;
    public float spawnInterval = 3f;
    public float platformSpacing = 3f;
    public float spawnWidth = 6f;
    public float potionSpawnChance = 0.5f; // 💡 50% chance to spawn potion

    private float nextSpawnY = 5f;
    private Transform player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        // Spawn initial platforms
        for (int i = 0; i < 5; i++)
        {
            SpawnPlatform();
        }
    }

    void Update()
    {
        if (player.position.y + 5f > nextSpawnY)
        {
            SpawnPlatform();
        }
    }

    void SpawnPlatform()
    {
        Vector3 spawnPos = new Vector3(Random.Range(-spawnWidth, spawnWidth), nextSpawnY, 0);
        GameObject newPlatform = Instantiate(platformPrefab, spawnPos, Quaternion.identity);

        // 🎯 Random chance to spawn a potion on the platform
        if (Random.value < potionSpawnChance)
        {
            Vector3 potionPos = spawnPos + new Vector3(0, 1f, 0);
            Instantiate(potionPrefab, potionPos, Quaternion.identity);
        }

        nextSpawnY += platformSpacing;
    }
}





