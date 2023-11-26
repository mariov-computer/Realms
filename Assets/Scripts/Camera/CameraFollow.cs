using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraFollow : MonoBehaviour
{
    public Transform target; // Reference to the player's transform
    public Vector3 offset = new Vector3(0f, 0f, -10f); // Offset of the camera from the player
    public float smoothTime = 0.3f; // Smoothing duration

    private Vector3 velocity = Vector3.zero;

    void LateUpdate()
    {
        if (target != null)
        {
            // Calculate the target position with the offset
            Vector3 targetPosition = target.position + offset;

            // Smoothly move the camera towards the target position
            transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
        }
    }
}