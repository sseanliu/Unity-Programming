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
        float horizontalInput = Input.GetAxis("Horizontal"); // A & D
        float verticalInput = Input.GetAxis("Vertical");     // W & S
        
        Vector3 movement = new Vector3(horizontalInput, 0, verticalInput);
        transform.Translate(movement * moveSpeed * Time.deltaTime, Space.World);

        if (Input.GetKey(KeyCode.Q))
        {
            transform.Rotate(0, -rotationSpeed * Time.deltaTime, 0);
        }
        if (Input.GetKey(KeyCode.E))
        {
            transform.Rotate(0, rotationSpeed * Time.deltaTime, 0);
        }

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
