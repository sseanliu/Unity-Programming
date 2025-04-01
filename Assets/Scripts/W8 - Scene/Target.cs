using UnityEngine;
using GameManager;

public class Target : MonoBehaviour
{
    // Bounds for random spawning
    public float spawnRange = 6f;
    
    // Target properties
    public Color targetColor = Color.red;
    public float targetScale = 1f;

    void Start()
    {
        // Apply color to this target if it's a newly created one
        Renderer renderer = GetComponent<Renderer>();
        if (renderer != null)
        {
            renderer.material.color = targetColor;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        // Check if the collision is with the player
        if (collision.gameObject.GetComponent<PlayerController>() != null)
        {
            // Use the singleton instance to increase the score
            if (GameManager.GameManager.Instance != null)
            {
                GameManager.GameManager.Instance.score++;
                Debug.Log("Score increased! Current score: " + GameManager.GameManager.Instance.score);
                
                // Spawn a new target at random position
                SpawnNewTarget();
                
                // Destroy this target
                Destroy(gameObject);
            }
            else
            {
                Debug.LogError("GameManager instance not found!");
            }
        }
    }
    
    void SpawnNewTarget()
    {
        // Generate random position within the specified range
        float randomX = Random.Range(-spawnRange, spawnRange);
        float randomY = Random.Range(-spawnRange, spawnRange);
        Vector3 spawnPosition = new Vector3(randomX, randomY, 0f);
        
        // Create a primitive capsule
        GameObject newTarget = GameObject.CreatePrimitive(PrimitiveType.Capsule);
        
        // Set position and scale
        newTarget.transform.position = spawnPosition;
        newTarget.transform.localScale = Vector3.one * targetScale;
        
        // Add the Target script
        Target targetScript = newTarget.AddComponent<Target>();
        targetScript.targetColor = this.targetColor;
        targetScript.targetScale = this.targetScale;
        targetScript.spawnRange = this.spawnRange;
        
        // Add a Rigidbody to allow for collisions
        Rigidbody rb = newTarget.AddComponent<Rigidbody>();
        rb.useGravity = false; // Disable gravity to keep it in place
        rb.isKinematic = true; // Make it kinematic to prevent physics effects
        
        // Apply the color
        Renderer renderer = newTarget.GetComponent<Renderer>();
        if (renderer != null)
        {
            renderer.material.color = targetColor;
        }
    }
} 