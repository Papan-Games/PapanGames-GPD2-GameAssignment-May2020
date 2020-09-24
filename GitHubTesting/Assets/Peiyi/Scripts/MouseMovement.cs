using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This is a script for player look around or can say mouse movement.
/// If the boolean canMove is true, players are allow to look around by moving the mouse.
/// Else they cannot look around in the game.
/// </summary>
public class MouseMovement : MonoBehaviour
{
    public enum RotationAxes
    {
        MouseXAndY = 0,
        MouseX = 1,
        MouseY = 2
    }
    public RotationAxes axes = RotationAxes.MouseXAndY;

    /// <summary>
    /// Sensitivity value for the mouse
    /// </summary>
    public float sensitivityHor = 9.0f;
    public float sensitivityVer = 9.0f;

    /// <summary>
    /// Min and max vertical angle
    /// </summary>
    public float minVer = -45.0f;
    public float maxVer = 45.0f;

    private float rotationX = 0;

    bool canMove; //A boolean for checking whether the mouse can move or not

    /// <summary>
    /// These are the variable for attaching the GameObject that when they are active,
    /// mouse cannot move in thw game
    /// </summary>
    public GameObject newspaperPanel;
    public GameObject bedQuestion;
    public GameObject staringDialogue;
    public GameObject settingPanel;

    // Start is called before the first frame update
    void Start()
    {
        Rigidbody body = GetComponent<Rigidbody>();
        if (body != null)
        {
            body.freezeRotation = true;
        }

        canMove = true;
    }

    // Update is called once per frame
    void Update()
    {
        //If these gameobkect is active, canMove = false
        if(newspaperPanel.activeSelf == true || bedQuestion.gameObject.activeSelf == true
            || staringDialogue.gameObject.activeSelf == true || settingPanel.gameObject.activeSelf == true
            || MissingItemScript.itemCount == 3)
        {
            canMove = false;
        }

        else
        {
            canMove = true;
        }

        //If canMove = true, player can look around by moving the mouse
        if (canMove)
        {
            if (axes == RotationAxes.MouseX)
            {
                //horizontal rotation here
                //this assign to character
                transform.Rotate(0, Input.GetAxis("Mouse X") * sensitivityHor, 0);
            }

            else if (axes == RotationAxes.MouseY)
            {
                //vertical rotation here
                //this assign to camera
                rotationX -= Input.GetAxis("Mouse Y") * sensitivityVer;
                rotationX = Mathf.Clamp(rotationX, minVer, maxVer);

                float rotationY = transform.localEulerAngles.y;

                transform.localEulerAngles = new Vector3(rotationX, rotationY, 0);
            }
        }
    }

}
