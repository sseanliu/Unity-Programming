using UnityEngine;

public class BouncingCube : MonoBehaviour
{
    [Header("Bounce Settings")]
    public float bounceSpeed = 5f;
    public float bounceForce = 5f;
    public GameObject boundaryBox;

    private Vector3 direction;
    private Bounds boxBounds;
    private BoxCollider boxCollider;
    private float fixedHeight;

    void Start()
    {
        direction = new Vector3(
            Random.Range(-1f, 1f),
            0,
            Random.Range(-1f, 1f)
        ).normalized;

        fixedHeight = transform.position.y;

        if (boundaryBox != null)
        {
            boxCollider = boundaryBox.GetComponent<BoxCollider>();
            if (boxCollider != null)
            {
                boxBounds = boxCollider.bounds;
            }
            else
            {
                Debug.LogError("Boundary box must have a Box Collider!");
            }
        }
        else
        {
            Debug.LogError("Please assign a boundary box in the inspector!");
        }
    }

    void Update()
    {
        if (boundaryBox == null) return;

        Vector3 movement = direction * bounceSpeed * Time.deltaTime;
        movement.y = 0;
        transform.position += movement;

        Vector3 pos = transform.position;
        Vector3 cubeExtents = GetComponent<Collider>().bounds.extents;

        pos.y = fixedHeight;

        if (pos.x + cubeExtents.x > boxBounds.max.x)
        {
            direction.x = -Mathf.Abs(direction.x);
            pos.x = boxBounds.max.x - cubeExtents.x;
        }
        else if (pos.x - cubeExtents.x < boxBounds.min.x)
        {
            direction.x = Mathf.Abs(direction.x);
            pos.x = boxBounds.min.x + cubeExtents.x;
        }

        if (pos.z + cubeExtents.z > boxBounds.max.z)
        {
            direction.z = -Mathf.Abs(direction.z);
            pos.z = boxBounds.max.z - cubeExtents.z;
        }
        else if (pos.z - cubeExtents.z < boxBounds.min.z)
        {
            direction.z = Mathf.Abs(direction.z);
            pos.z = boxBounds.min.z + cubeExtents.z;
        }

        transform.position = pos;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Vector3 awayFromPlayer = (transform.position - other.transform.position);
            awayFromPlayer.y = 0;
            direction = awayFromPlayer.normalized;
            
            transform.position += direction * 0.5f;
            transform.position = new Vector3(transform.position.x, fixedHeight, transform.position.z);
        }
    }
} 