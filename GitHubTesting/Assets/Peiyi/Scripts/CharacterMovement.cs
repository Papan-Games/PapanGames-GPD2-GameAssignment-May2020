using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
[AddComponentMenu("Control Script/CharacterMovement")]
public class CharacterMovement : MonoBehaviour
{
    //public float speed = 6.0f; //character speed
    //public float jumpSpeed = 5.0f;
    //private CharacterController _charController;
    //public float gravity = -9.8f; //gravity

    //// Start is called before the first frame update
    //void Start()
    //{
    //    _charController = GetComponent<CharacterController>();
    //}

    //// Update is called once per frame
    //void Update()
    //{
    //    float deltaX = Input.GetAxis("Horizontal") * speed; //Move left and right
    //    float deltaZ = Input.GetAxis("Vertical") * speed; //Move forward and backward
    //    Vector3 movement = new Vector3(deltaX, 0, deltaZ);
    //    movement = Vector3.ClampMagnitude(movement, speed);

    //    movement.y = gravity; //avoid character floating, able to fall down from up

    //    movement *= Time.deltaTime;
    //    movement = transform.TransformDirection(movement);


    //    _charController.Move(movement);


    //}

    //public GameObject camera;
    //private float cameraOriPos;
    public float speed = 6.0f;
    public float jumpSpeed = 5.0f;
    public float gravity = 9.8f;
    private bool canMove;

    private CharacterController charController;
    Vector3 moveDirection = Vector3.zero;

    void Start()
    {
        charController = GetComponent<CharacterController>();
        canMove = true;
        //cameraOriPos = 0.46f;
    }

    void Update()
    {
        // Movements
        if (canMove)
        {
            Vector3 forward = transform.TransformDirection(Vector3.forward);
            Vector3 right = transform.TransformDirection(Vector3.right);

            float deltaX = Input.GetAxis("Vertical") * speed;
            float deltaY = Input.GetAxis("Horizontal") * speed;
            float movementY = moveDirection.y;
            moveDirection = (forward * deltaX) + (right * deltaY);

            if (charController.isGrounded && Input.GetButton("Jump"))
            {
                moveDirection.y = jumpSpeed;
            }
            else
            {
                moveDirection.y = movementY;
            }
            if (!charController.isGrounded)
            {
                moveDirection.y += gravity * Time.deltaTime;
            }
            

            charController.Move(moveDirection * Time.deltaTime);
        }

        
    }
}
