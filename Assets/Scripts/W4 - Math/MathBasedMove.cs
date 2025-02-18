using UnityEngine;

public class MathBasedMoveLerp : MonoBehaviour
{

    public float speed = 1f;
    public Vector3 startPosition;
    public Vector3 endPosition;

    private float journeyLength;
    private float startTime;

    void Start()
    {
        startTime = Time.time;
        journeyLength = Vector3.Distance(startPosition, endPosition);
    }
    void Update()
    {
        float distCovered = (Time.time - startTime) * speed;
        float fractionOfJourney = distCovered / journeyLength;
        transform.position = Vector3.Lerp(startPosition, endPosition, fractionOfJourney);
    }
}
