using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCar : MonoBehaviour
{
    public Transform carTransform; // Reference to the car's transform
    public Vector3 offset; // Offset between the car and the camera
    public float smoothTime = 0.5f; // Smooth time for camera movement
    public float rotationSpeed = 5f; // Speed of camera rotation

    // Update is called once per frame
    void Update()
    {
        // Calculate the desired position for the camera
        Vector3 desiredPosition = carTransform.position + offset;

        // Smoothly move the camera towards the desired position
        transform.position = Vector3.Lerp(transform.position, desiredPosition, smoothTime * Time.deltaTime);

        // Calculate the desired rotation for the camera
        Quaternion desiredRotation = Quaternion.LookRotation(carTransform.position - transform.position, Vector3.up);

        // Smoothly rotate the camera towards the desired rotation
        transform.rotation = Quaternion.Slerp(transform.rotation, desiredRotation, rotationSpeed * Time.deltaTime);
    }
}
