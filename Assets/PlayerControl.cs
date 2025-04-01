using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Movement Settings")]
    public float moveSpeed = 5f;

    public KeyCode forwardKey = KeyCode.UpArrow;
    public KeyCode backwardKey = KeyCode.DownArrow;
    public KeyCode leftKey = KeyCode.LeftArrow;
    public KeyCode rightKey = KeyCode.RightArrow;

    public float rotateSpeed = 100f;
    
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetKey(forwardKey))
        {
            rb.linearVelocity += Vector3.up * moveSpeed * Time.deltaTime;
        }

        if (Input.GetKey(backwardKey))
        {
            rb.linearVelocity -= Vector3.up * moveSpeed * Time.deltaTime;
        }
        
        if (Input.GetKey(leftKey))
        {
            rb.linearVelocity -= Vector3.right * moveSpeed * Time.deltaTime;
        }
        
        if (Input.GetKey(rightKey))
        {
            rb.linearVelocity += Vector3.right * moveSpeed * Time.deltaTime;
        }
    }
}
