using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Vector3 move;
    public float speed = 5;
    public float maxSpeed = 9;
    public float currentSpeed = 5;
    public float multiplier = 1f;
    public float accelerationTimer = 1;
    // Update is called once per frame
    void Update()
    {
        move = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        Accelerate();
        Move();


    }
    void Accelerate()
    {

        if (move.magnitude > 0)
        {
            if (currentSpeed < maxSpeed)
            {
                accelerationTimer += Time.deltaTime;
                float acc = multiplier * (accelerationTimer * accelerationTimer);
                currentSpeed = speed * acc;
            }
        }
        else
        {
            accelerationTimer = 1;
            currentSpeed = speed;
        }
    }
    void Move()
    {
        // Get the camera's forward and right vectors
        Vector3 cameraForward = Camera.main.transform.forward;
        Vector3 cameraRight = Camera.main.transform.right;

        // Neutralize the y-component to ignore vertical movement
        cameraForward.y = 0;
        cameraRight.y = 0;

        // Normalize these vectors to ensure they don't affect the movement speed
        cameraForward.Normalize();
        cameraRight.Normalize();

        // Calculate the desired movement direction based on the input and camera orientation
        Vector3 desiredMoveDirection = (cameraForward * move.z + cameraRight * move.x).normalized;

        // Apply the movement
        transform.Translate(desiredMoveDirection * currentSpeed * Time.deltaTime, Space.World);
    }

}
