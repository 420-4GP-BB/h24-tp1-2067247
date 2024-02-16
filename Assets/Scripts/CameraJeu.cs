using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraJeu : MonoBehaviour
{
    public Transform target; // The ball's transform
    public Vector3 offset; // Offset from the ball to the camera
    public float smoothSpeed = 0.125f; // How smoothly the camera catches up to its target position

    void Start()
{
    EnableCameraFollow(false); // Disable camera follow at the start
}

    void LateUpdate()
    {
        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;

        // Optionally, make the camera always look at the ball
        transform.LookAt(target);
    }
    public void EnableCameraFollow(bool enable)
    {
        this.enabled = enable; // Enable or disable this camera follow script
    }
}
