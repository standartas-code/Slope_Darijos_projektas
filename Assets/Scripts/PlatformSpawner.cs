using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    public GameObject[] platformPrefabs;
    public Transform startPlatform;
    public Transform player;

    private Vector3 nextSpawnPosition;
    private int platformsAhead = 6;
    private int platformsSpawned = 0;

    [Header("Усложнение с каждой платформой")]
    public float baseZStep = 35f;       
    public float baseYStep = 15f;         
    public float zStepGrowth = 7f;     
    public float yStepGrowth = 3f;     

    void Start()
    {
        nextSpawnPosition = GetEndPosition(startPlatform.gameObject);
        SpawnPlatforms(platformsAhead);
    }

    void Update()
    {
        float distanceToNextSpawn = nextSpawnPosition.z - player.position.z;

        if (distanceToNextSpawn < 20f)
        {
            SpawnPlatforms(1);
        }
    }

    void SpawnPlatforms(int count)
    {
        for (int i = 0; i < count; i++)
        {
            GameObject prefab = platformPrefabs[Random.Range(0, platformPrefabs.Length)];
            GameObject newPlatform = Instantiate(prefab);

            BoxCollider col = newPlatform.GetComponent<BoxCollider>();
            if (col == null)
            {
                Destroy(newPlatform);
                return;
            }

            Vector3 spawnPos = nextSpawnPosition;

            float currentZStep = baseZStep + platformsSpawned * zStepGrowth;
            float currentYStep = baseYStep + platformsSpawned * yStepGrowth;

            spawnPos.z += currentZStep;
            spawnPos.y -= currentYStep;
            spawnPos.x = startPlatform.position.x;

            newPlatform.transform.position = spawnPos;

            nextSpawnPosition = GetEndPosition(newPlatform);
            platformsSpawned++;
        }
    }

    Vector3 GetEndPosition(GameObject platform)
    {
        BoxCollider col = platform.GetComponentInChildren<BoxCollider>();
        if (col == null)
        {
            return platform.transform.position;
        }

        Bounds bounds = col.bounds;
        Vector3 pos = platform.transform.position;

        return new Vector3(
            pos.x,
            pos.y - bounds.size.y / 2f,
            pos.z + bounds.size.z / 2f
        );
    }
}
