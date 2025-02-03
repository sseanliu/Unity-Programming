using UnityEngine;

public class BallDropper : MonoBehaviour
{

    public GameObject ballPrefab;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(ballPrefab, new Vector3(transform.position.x, transform.position.y - 1, 0), Quaternion.identity);
        }
    }
}
