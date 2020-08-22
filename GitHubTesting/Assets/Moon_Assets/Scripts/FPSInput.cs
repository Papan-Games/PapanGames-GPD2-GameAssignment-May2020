using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
[AddComponentMenu("Control Script/FPS Input")]

public class FPSInput : MonoBehaviour
{
    public float speed = 6.0f;
    public float jumpSpeed = 5.0f;
    public float gravity = 9.8f;
    private bool canMove;

    private CharacterController charController;
    Vector3 moveDirection = Vector3.zero;

    private bool nearTreeman;

    private void Awake()
    {
        Messenger.AddListener(GameEvent.TREEMAN_IN_RANGE, TreemanInRange);
        Messenger.AddListener(GameEvent.TREEMAN_NOT_IN_RANGE, TreemanNotInRange);
        Messenger.AddListener(GameEvent.DIALOGUE_END, DialogueEnded);
    }

    private void OnDestroy()
    {
        Messenger.RemoveListener(GameEvent.TREEMAN_IN_RANGE, TreemanInRange);
        Messenger.RemoveListener(GameEvent.TREEMAN_NOT_IN_RANGE, TreemanNotInRange);
        Messenger.RemoveListener(GameEvent.DIALOGUE_END, DialogueEnded);
    }

    void Start()
    {
        charController = GetComponent<CharacterController>();
        canMove = true;
        nearTreeman = false;
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
                moveDirection.y -= gravity * Time.deltaTime;
            }

            charController.Move(moveDirection * Time.deltaTime);
        }

        // Interactions
        if (nearTreeman && Input.GetKeyDown(KeyCode.E))
        {
            canMove = false;
            Messenger.Broadcast(GameEvent.DIALOGUE_START);
        }
    }

    private void TreemanInRange()
    {
        nearTreeman = true;
    }

    private void TreemanNotInRange()
    {
        nearTreeman = false;
    }

    private void DialogueEnded()
    {
        canMove = true;
    }
}
