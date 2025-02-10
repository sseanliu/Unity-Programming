using UnityEngine;

public class TargetScript : MonoBehaviour
{
    public int scoreValue = 10;
    private static int totalScore = 0;
    
    public float moveSpeed = 3f;
    public float moveRange = 5f;
    private float startingX;
    private float direction = 1f;
    
    public static int TotalScore
    {
        get { return totalScore; }
    }

    void Start()
    {
        startingX = transform.position.x;
    }

    void Update()
    {
        Vector3 position = transform.position;
        position.x += direction * moveSpeed * Time.deltaTime;

        if (position.x >= startingX + moveRange)
        {
            position.x = startingX + moveRange;
            direction = -1f;
        }
        else if (position.x <= startingX - moveRange)
        {
            position.x = startingX - moveRange;
            direction = 1f;
        }

        transform.position = position;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Projectile"))
        {
            totalScore += scoreValue;
            Debug.Log($"Hit! Score: {totalScore}");
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
