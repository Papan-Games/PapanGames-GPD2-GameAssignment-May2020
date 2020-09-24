using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A script for character movement.
/// If canMove, player can move.
/// If !canMove, player cannot move.
/// </summary>
[RequireComponent(typeof(CharacterController))]
[AddComponentMenu("Control Script/CharacterMovement")]
public class CharacterMovement : MonoBehaviour
{
    public float speed = 6.0f; //move speed
    public float jumpSpeed = 5.0f; //jump speed
    public float gravity = 9.8f; //gravity
    private bool canMove; //check player if player can move

    private CharacterController charController;
    Vector3 moveDirection = Vector3.zero;

    /// <summary>
    /// GameObjects for checking player stop movement condition
    /// </summary>
    public GameObject newspaperPanel;
    public GameObject bedQuestion;
    public GameObject staringDialogue;
    public GameObject settingPanel;

    void Start()
    {
        charController = GetComponent<CharacterController>();
        canMove = true;
    }

    void Update()
    {
        //Checking whether these gameobject is active or not.
        //If active, canMove = false;
        if(newspaperPanel.gameObject.activeSelf == true || bedQuestion.gameObject.activeSelf == true ||
           staringDialogue.gameObject.activeSelf == true || settingPanel.gameObject.activeSelf == true)
        {
            canMove = false;
        }

        else
        {
            canMove = true;
        }

        // If canMove, run code below for player movement
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
