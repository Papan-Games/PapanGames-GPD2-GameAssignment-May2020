using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
[AddComponentMenu("Control Script/FPS Input")]

public class FPSInput : MonoBehaviour
{
    public float speed = 6.0f;
    public float gravity = -9.8f;
    private bool playerGrounded;
    private float jumpHeight = 1.0f;
    private Vector3 playerVelocity;

    private CharacterController charController;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        charController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        playerGrounded = charController.isGrounded;
        if (playerGrounded && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        float deltaX = Input.GetAxis("Horizontal") * speed;
        float deltaZ = Input.GetAxis("Vertical") * speed;
        Vector3 movement = new Vector3(deltaX, 0, deltaZ);
        movement = Vector3.ClampMagnitude(movement, speed);

        movement *= Time.deltaTime;
        movement = transform.TransformDirection(movement);
        charController.Move(movement);

        if (Input.GetButtonDown("Jump") && playerGrounded)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravity);
        }

        //movement.y = gravity;
        playerVelocity.y += gravity * Time.deltaTime;
        charController.Move(playerVelocity * Time.deltaTime);
    }
}
