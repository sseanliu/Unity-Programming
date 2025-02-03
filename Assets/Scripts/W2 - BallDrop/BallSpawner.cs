using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    public GameObject prefabSpawn;

    void Start()
    {
        InvokeRepeating("SpawnBall", 0, 1);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            CancelInvoke("SpawnBall");
        }
    }

    public void SpawnBall()
    {
        Instantiate(prefabSpawn, transform.position, Quaternion.identity);
    }
}
