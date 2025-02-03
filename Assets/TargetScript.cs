using UnityEngine;

public class TargetScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.name + " entered the trigger");
    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.name + " collided with " + name);
    }
}
