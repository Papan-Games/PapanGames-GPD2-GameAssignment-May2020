using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
[AddComponentMenu("Control Script/CharacterMovement")]
public class CharacterMovement : MonoBehaviour
{
    public float speed = 6.0f; //character speed
    private CharacterController _charController;
    public float gravity = -9.8f; //gravity

    // Start is called before the first frame update
    void Start()
    {
        _charController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        float deltaX = Input.GetAxis("Horizontal") * speed; //Move left and right
        float deltaZ = Input.GetAxis("Vertical") * speed; //Move forward and backward
        Vector3 movement = new Vector3(deltaX, 0, deltaZ);
        movement = Vector3.ClampMagnitude(movement, speed);

        //movement = Vector3.ClampMagnitude(movement, speed);
        movement.y = gravity; //aaoid character floating, able to fall down from up

        movement *= Time.deltaTime;
        movement = transform.TransformDirection(movement);
        _charController.Move(movement);
    }
}
