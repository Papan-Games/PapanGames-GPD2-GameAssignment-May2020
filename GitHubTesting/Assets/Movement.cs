using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
[AddComponentMenu("Control Script/Movement")]
public class Movement : MonoBehaviour
{
    public float speed = 2.5f;
    public float gravity = 0f;
    public float recalibrateSpeed = 0.5f;
    private CharacterController _charController;

    // Start is called before the first frame update
    void Start()
    {
        _charController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        CheckHeight();
    }

    void Move()
    {
        float walk = Input.GetAxis("Horizontal") * speed;
        float straffe = Input.GetAxis("Vertical") * speed;

        Vector3 movement = new Vector3(walk, 0, straffe);
        movement = Vector3.ClampMagnitude(movement, speed);

        movement.y = gravity;
        movement *= Time.deltaTime;
        movement = transform.TransformDirection(movement);
        _charController.Move(movement);
    }

    void CheckHeight()
    {
        if(transform.position.y != 0)
        {
            Vector3 targetPos = new Vector3 (transform.position.x, 0, transform.position.z);
            transform.position = Vector3.MoveTowards(transform.position, targetPos, recalibrateSpeed * Time.deltaTime);
        }
    }
}
