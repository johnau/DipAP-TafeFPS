using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerInput : MonoBehaviour
{
    Vector3 moveVector = new();
    Vector2 lookVector = new();

    public PlayerMovement movement;

    public UnityEvent shoot;
    public UnityEvent endShoot;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GetInput();
    }

    void GetInput()
    {
        moveVector.x = Input.GetAxisRaw("Horizontal");
        moveVector.z = Input.GetAxisRaw("Vertical");

        lookVector.x = Input.GetAxis("Mouse X");
        lookVector.y = Input.GetAxis("Mouse Y");

        bool jump = false;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            jump = true;
        }

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            shoot.Invoke();
        }

        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            endShoot.Invoke();
        }

        movement.UpdateMovement(moveVector, lookVector, jump);
    }
}
