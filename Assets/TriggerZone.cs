using UnityEngine;

public class TriggerZone : MonoBehaviour
{
    // Called when another collider enters this trigger collider
    private void OnTriggerEnter(Collider other)
    {
        // Check if the object entering has the "Player" tag
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player has entered the trigger zone!");
            // You can add additional interaction logic here.
        }
    }
}
