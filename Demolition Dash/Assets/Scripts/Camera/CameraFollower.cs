using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollower : MonoBehaviour
{

    public Transform Target;

    public float SmoothSpeed = 0.250f;

    public Vector3 Offset;
    void FollowPlayer()
    {
        Target = GameObject.Find("CarHolder").transform;
        // transform.position = PlayerObject.transform.position + new Vector3(5, 4, 0);
        Vector3 DesiredPose = Target.position + Offset;
        Vector3 SmoothedPosition =
            Vector3.Lerp(transform.position, DesiredPose, SmoothSpeed);
        transform.position = SmoothedPosition;
    }

    private void Update()
    {
        FollowPlayer();
    }
}
