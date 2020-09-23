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
    private bool finalDialogue;
    private bool isTalking;

    public Transform revivePoint;

    private void Awake()
    {
        Messenger.AddListener(GameEvent.TREEMAN_IN_RANGE, TreemanInRange);
        Messenger.AddListener(GameEvent.TREEMAN_NOT_IN_RANGE, TreemanNotInRange);
        Messenger.AddListener(GameEvent.DIALOGUE_END, DialogueEnded);
        Messenger.AddListener(GameEvent.FINAL_DIALOGUE_END, DialogueEnded);
        Messenger.AddListener(GameEvent.SOUL_COLLECTED_ALL, TriggerFinalDialogue);
        Messenger.AddListener(GameEvent.PLAYER_DEAD, PlayerDead);
        Messenger.AddListener(GameEvent.PLAYER_REVIVED, PlayerRevived);
    }

    private void OnDestroy()
    {
        Messenger.RemoveListener(GameEvent.TREEMAN_IN_RANGE, TreemanInRange);
        Messenger.RemoveListener(GameEvent.TREEMAN_NOT_IN_RANGE, TreemanNotInRange);
        Messenger.RemoveListener(GameEvent.DIALOGUE_END, DialogueEnded);
        Messenger.RemoveListener(GameEvent.FINAL_DIALOGUE_END, DialogueEnded);
        Messenger.RemoveListener(GameEvent.SOUL_COLLECTED_ALL, TriggerFinalDialogue);
        Messenger.RemoveListener(GameEvent.PLAYER_DEAD, PlayerDead);
        Messenger.RemoveListener(GameEvent.PLAYER_REVIVED, PlayerRevived);
    }

    void Start()
    {
        charController = GetComponent<CharacterController>();
        canMove = true;
        isTalking = false;
        nearTreeman = false;
        finalDialogue = false;
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
        if (nearTreeman && !isTalking && Input.GetKeyDown(KeyCode.E))
        {
            canMove = false;
            isTalking = true;
            if (!finalDialogue)
            {
                Messenger.Broadcast(GameEvent.DIALOGUE_START);
            }
            else
            {
                Messenger.Broadcast(GameEvent.FINAL_DIALOGUE_START);
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            Messenger.Broadcast(GameEvent.SOUL_COLLECTED_ALL);
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
        isTalking = false;
    }

    private void TriggerFinalDialogue()
    {
        finalDialogue = true;
        isTalking = false;
    }

    private void PlayerDead()
    {
        canMove = false;
        transform.position = revivePoint.transform.position;
    }

    private void PlayerRevived()
    {
        canMove = true;
    }
}
