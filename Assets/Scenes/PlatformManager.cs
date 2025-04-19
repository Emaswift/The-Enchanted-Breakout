using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    public GameObject platformPrefab;
    public GameObject potionPrefab; // Assign your potion prefab in the Inspector
    public float levelWidth = 3f;
    public float minY = 2f;
    public float maxY = 3.5f;
    public int initialPlatformCount = 10;
    public float potionSpawnChance = 0.5f; // 50% chance to spawn a potion on a platform

    private float lastY;

    void Start()
    {
        lastY = transform.position.y;
        for (int i = 0; i < initialPlatformCount; i++)
        {
            SpawnPlatform();
        }
    }

    void Update()
    {
        // When camera reaches near the top of last platform, spawn more
        if (Camera.main.transform.position.y + 10f > lastY)
        {
            SpawnPlatform();
        }
    }

    void SpawnPlatform()
    {
        float y = lastY;
    }
}

    