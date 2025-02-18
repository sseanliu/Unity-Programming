using UnityEngine;

public class MathBasedMoveLerp : MonoBehaviour
{

    public float speed = 1f;
    public Vector3 startPosition;
    public Vector3 endPosition;
    public Transform target;

    private float journeyLength;
    private float startTime;

    void Start()
    {
        startTime = Time.time;
        startPosition = transform.position;
        endPosition = target.position;
        Vector3 direction = endPosition - startPosition;
        Vector3 normalizedDirection = direction.normalized;
        journeyLength = Vector3.Distance(startPosition, endPosition);
    }
    void Update()
    {
        float distCovered = (Time.time - startTime) * speed;
        float fractionOfJourney = distCovered / journeyLength;
        transform.position = Vector3.Lerp(startPosition, endPosition, fractionOfJourney);
    }
}
