using UnityEngine;
using System;

public enum FollowTypeEnum
{
    Speed1x,
    Speed2x
} 

public class FollowType : MonoBehaviour
{
    // Event declaration
    public static event Action<FollowTypeEnum> OnFollowTypeChanged;

    [SerializeField]
    private FollowTypeEnum _followType = FollowTypeEnum.Speed1x;
    private FollowTypeEnum _previousFollowType;

    private void Update()
    {
        // Only invoke the event if the value has changed
        if (_followType != _previousFollowType)
        {
            OnFollowTypeChanged?.Invoke(_followType);
            _previousFollowType = _followType;
        }
    }
} 