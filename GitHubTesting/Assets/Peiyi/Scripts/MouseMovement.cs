using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseMovement : MonoBehaviour
{

    public enum RotationAxes
    {
        MouseXAndY = 0,
        MouseX = 1,
        MouseY = 2
    }
    public RotationAxes axes = RotationAxes.MouseXAndY;

    public float sensitivityHor = 9.0f;
    public float sensitivityVer = 9.0f;

    public float minVer = -45.0f;
    public float maxVer = 45.0f;

    private float rotationX = 0;

    bool canMove;

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

        //newspaperPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //Checking if player is reading newspaper
        if(newspaperPanel.activeSelf == true || bedQuestion.gameObject.activeSelf == true
            || staringDialogue.gameObject.activeSelf == true /*|| settingPanel.gameObject.activeSelf == true*/)
        {
            canMove = false;
        }

        else
        {
            canMove = true;
        }

        //Look around
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
