using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelController : MonoBehaviour
{
    [Header("Wheel Colliders")]
    [SerializeField] WheelCollider frontRightWheel;
    [SerializeField] WheelCollider frontLeftWheel;
    [SerializeField] WheelCollider rearRightWheel;
    [SerializeField] WheelCollider rearLeftWheel;

    [Header("Wheel Meshes")]
    [SerializeField] Transform frontRightWheelMesh;
    [SerializeField] Transform frontLeftWheelMesh;
    [SerializeField] Transform rearRightWheelMesh;
    [SerializeField] Transform rearLeftWheelMesh;

    public float acceleration = 1000f;
    public float breakingForce = 100000f;
    public float smoothness = 50f;
    public float maxTurnAngle = 30f;

    private float currentAcceleration = 0f;
    private float currentBreakForce = 0f;
    private float currentTurnAngle = 0f;

    private void FixedUpdate()
    {
        Time.timeScale = 2;

        // If the up or down arrow key is pressed, apply acceleration.
        currentAcceleration = Input.GetAxis("Vertical") * acceleration;

        // If the Space key is pressed, apply breaking force.
        if (Input.GetKey(KeyCode.Space))
            currentBreakForce = breakingForce;
        else
            currentBreakForce = 0f;

        // If the R key is pressed, lift the car and rotate it to its original state.
        if (Input.GetKey(KeyCode.R))
        {
            // Lift the car a few meters in the air.
            transform.position += new Vector3(0f, 2f, 0f);

            // Rotate the car to its original state.
            transform.rotation = Quaternion.identity;
        }

        // Apply acceleration to front wheels.
        frontRightWheel.motorTorque = currentAcceleration;
        frontLeftWheel.motorTorque = currentAcceleration;

        // Apply breaking force to rear wheels.
        frontRightWheel.brakeTorque = currentBreakForce;
        frontLeftWheel.brakeTorque = currentBreakForce;
        rearRightWheel.brakeTorque = currentBreakForce;
        rearLeftWheel.brakeTorque = currentBreakForce;

        // Take care of the steering.
        float targetTurnAngle = Input.GetAxis("Horizontal") * maxTurnAngle;
        currentTurnAngle = Mathf.Lerp(currentTurnAngle, targetTurnAngle, Time.deltaTime * smoothness);
        frontLeftWheel.steerAngle = currentTurnAngle;
        frontRightWheel.steerAngle = currentTurnAngle;

        // If no button is being held, rapidly make the wheels go straight.
        if (!Input.anyKey)
        {
            currentTurnAngle = Mathf.Lerp(currentTurnAngle, 0f, Time.deltaTime * 5);
            frontLeftWheel.steerAngle = currentTurnAngle;
            frontRightWheel.steerAngle = currentTurnAngle;
        }
        // Les positions des roues ne correspondent pas exactement à celles des roues colliders. Fonction à corriger plus tard... - Colin

        /*
        updateWheel(frontRightWheel, frontRightWheelMesh);
        updateWheel(frontLeftWheel, frontLeftWheelMesh);
        updateWheel(rearRightWheel, rearRightWheelMesh);
        updateWheel(rearLeftWheel, rearLeftWheelMesh);
        */
    }

    // Les positions des roues ne correspondent pas exactement à celles des roues colliders. Fonction à corriger plus tard... - Colin

    /*void updateWheel(WheelCollider col, Transform trans) {

        // Get wheel collider state
        Vector3 position;
        Quaternion rotation;
        col.GetWorldPose(out position, out rotation);

        // Set wheel transform state.
        trans.position = position;
        trans.rotation = rotation;
    }*/


}
