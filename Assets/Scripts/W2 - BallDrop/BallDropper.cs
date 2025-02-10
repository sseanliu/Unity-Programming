using UnityEngine;

public class BallDropper : MonoBehaviour
{
    public GameObject ballPrefab;
    public float shootForce = 1000f;
    public float moveSpeed = 5f;
    public float rotationSpeed = 100f;

    void Start()
    {
        
    }

    void Update()
    {
        // Forward/Backward movement with W/S
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 movement = transform.forward * verticalInput;
        transform.Translate(movement * moveSpeed * Time.deltaTime, Space.World);

        // Rotation with A/D
        float horizontalInput = Input.GetAxis("Horizontal");
        transform.Rotate(0, horizontalInput * rotationSpeed * Time.deltaTime, 0);

        // Shooting with Space
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject ball = Instantiate(ballPrefab, transform.position + transform.forward, Quaternion.identity);
            Rigidbody rb = ball.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddForce(transform.forward * shootForce);
            }
        }
    }
}
