using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public float moveSpeed = 8;
    public float moveSmoothingTime = 0.1f;
    float currentVelocityX = 0;
    float currentVelocityZ = 0;
    public float gravityForce = -20;
    public float jumpForce = 8;
    Vector3 currentMovement = new();

    public Transform camera;
    public float lookSensitivity;
    public float maxY = 90;
    public float minY = -90;
    float yRotation = 0f;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }


    public void UpdateMovement(Vector3 movement, Vector3 lookVector, bool jump)
    {
        transform.Rotate(transform.up, lookVector.x * lookSensitivity);
        yRotation += lookVector.y * lookSensitivity;
        yRotation = Mathf.Clamp(yRotation, minY, maxY);
        camera.eulerAngles = new Vector3(-yRotation, camera.eulerAngles.y, camera.eulerAngles.z);

        if (movement.magnitude > 1)
        {
            movement.Normalize();
        }
        movement = transform.TransformDirection(movement);
        movement *= moveSpeed;

        currentMovement.x = Mathf.SmoothDamp(currentMovement.x, movement.x, ref currentVelocityX, moveSmoothingTime);
        currentMovement.z = Mathf.SmoothDamp(currentMovement.z, movement.z, ref currentVelocityZ, moveSmoothingTime);

        if (jump && controller.collisionFlags.HasFlag(CollisionFlags.Below))
        {
            currentMovement.y = jumpForce;
        } 
        else
        {
            currentMovement.y += gravityForce * Time.deltaTime;
        }

        currentMovement.y = Mathf.Clamp(currentMovement.y, gravityForce, jumpForce);
        controller.Move(currentMovement * Time.deltaTime);
    }
}
