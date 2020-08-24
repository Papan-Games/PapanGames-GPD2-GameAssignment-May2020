using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
[AddComponentMenu("Control Script/CharacterMovement")]
public class CharacterMovement : MonoBehaviour
{
    public float speed = 6.0f;
    public float jumpSpeed = 5.0f;
    public float gravity = 9.8f;
    private bool canMove;

    private CharacterController charController;
    Vector3 moveDirection = Vector3.zero;

    public GameObject newspaperPanel;

    void Start()
    {
        charController = GetComponent<CharacterController>();
        canMove = true;
    }

    void Update()
    {
        //Check if reading newspaper
        if(newspaperPanel.gameObject.activeSelf == true)
        {
            canMove = false;
        }

        else if(newspaperPanel.gameObject.activeSelf == false)
        {
            canMove = true;
        }
        
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
