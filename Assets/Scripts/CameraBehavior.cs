using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehavior : MonoBehaviour
{
    public Transform player; // Reference to the player's Transform
    public Vector3 offset; // Offset position of the camera
    public float smoothSpeed = 0.125f; // Smooth speed for camera movement

    void Start()
    {
        // initialize offset based on the initial positions of camera and player
        if (player != null)
            offset = transform.position - player.position;
    }

    void LateUpdate()
    {
        if (player != null)
        {
            // calculate target position based on player's position and offset
            Vector3 targetPosition = player.position + offset;

            // smoothly move camera to target position
            transform.position = Vector3.Lerp(transform.position, targetPosition, smoothSpeed);

            // no rotation
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }
}
