using UnityEngine;

public class TargetSpawner : MonoBehaviour
{
    public GameObject targetPrefab;
    public float spawnInterval = 3f;
    public Vector3 spawnAreaSize = new Vector3(10f, 0f, 10f);
    public float minHeight = 1f;
    public float maxHeight = 3f;
    public int maxTargets = 5;

    private float nextSpawnTime;

    void Start()
    {
        nextSpawnTime = Time.time + spawnInterval;
    }

    void Update()
    {
        if (Time.time >= nextSpawnTime && GameObject.FindGameObjectsWithTag("Target").Length < maxTargets)
        {
            SpawnTarget();
            nextSpawnTime = Time.time + spawnInterval;
        }
    }

    void SpawnTarget()
    {
        Vector3 randomPosition = transform.position + new Vector3(
            Random.Range(-spawnAreaSize.x/2, spawnAreaSize.x/2),
            Random.Range(minHeight, maxHeight),
            Random.Range(-spawnAreaSize.z/2, spawnAreaSize.z/2)
        );

        GameObject target = Instantiate(targetPrefab, randomPosition, Quaternion.identity);
        target.tag = "Target";
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(transform.position + new Vector3(0, (minHeight + maxHeight)/2, 0), 
            new Vector3(spawnAreaSize.x, maxHeight - minHeight, spawnAreaSize.z));
    }
}