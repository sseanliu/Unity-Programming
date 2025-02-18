using UnityEngine;

public class TargetScriptFollow : TargetScript
{
    // the target will follow the player
    public Transform PlayerTransform;
    public float speed = 2f;
    public Vector3 startPosition;
    public Vector3 endPosition;
    private float journeyLength;
    private float startTime;
    public FollowTypeEnum followType;

    void Start()
    {
        startTime = Time.time;
    }

    void Update()
    {
        // Calculate direction to the player
        Vector3 direction = PlayerTransform.position - transform.position;
        
        // Move towards the player at a constant speed
        switch (followType)
        {
            case FollowTypeEnum.Speed1x:
                transform.position += direction.normalized * speed * Time.deltaTime;
                break;
            case FollowTypeEnum.Speed2x:
                transform.position += direction.normalized * speed * 10 * Time.deltaTime;
                break;
        }
    }

    private void OnEnable()
    {
        // Subscribe to the FollowType event
        FollowType.OnFollowTypeChanged += HandleFollowTypeChanged;
    }

    private void OnDisable()
    {
        // Unsubscribe from the FollowType event
        FollowType.OnFollowTypeChanged -= HandleFollowTypeChanged;
    }

    private void HandleFollowTypeChanged(FollowTypeEnum newFollowType)
    {
        followType = newFollowType;
        Debug.Log("FollowType changed to: " + followType);
    }
}
