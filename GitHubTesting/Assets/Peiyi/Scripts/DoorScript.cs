using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    public bool invertDoorOpenDirection = false;
    private float openAngle = 75.0f;
    private bool isOpening;
    private bool isClosing;
    [SerializeField] private float targetOpenAngle;
    [SerializeField] private float targetCloseAngle;
    [SerializeField] private bool isOpened;
    [SerializeField] private bool isClosed;
    [SerializeField] private float openSpeed = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        isOpened = false;
        isClosed = true;
        isOpening = false;
        isClosing = false;
        if (!invertDoorOpenDirection)
        {
            targetOpenAngle = transform.eulerAngles.y - openAngle;
            targetCloseAngle = transform.eulerAngles.y + openAngle;
        }
        else
        {
            targetOpenAngle = transform.eulerAngles.y + openAngle;
            targetCloseAngle = transform.eulerAngles.y - openAngle;
        }
        
    }


    // Update is called once per frame
    void Update()
    {
        CheckHatch();
    }

    void CheckHatch()
    {
        if (isOpening)
        {
            float yAngle = transform.eulerAngles.y;
            if (!invertDoorOpenDirection)
            {
                if (yAngle - targetOpenAngle > 0.0f)
                {
                    transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y - openSpeed, transform.eulerAngles.z);
                }
                else
                {
                    isOpened = true;
                    isOpening = false;
                    isClosed = false;
                }
            }
            else
            {
                if (targetOpenAngle - yAngle > 0.0f)
                {
                    transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y + openSpeed, transform.eulerAngles.z);
                }
                else
                {
                    isOpened = true;
                    isOpening = false;
                    isClosed = false;
                }
            }
            Debug.Log("Halo");
        }

        if(isClosing)
        {
            float yAngle = transform.eulerAngles.y;
            if (!invertDoorOpenDirection)
            {
                if (targetOpenAngle - yAngle > 0.0f)
                {
                    transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y + openSpeed, transform.eulerAngles.z);
                }
                else
                {
                    //isClosed = true;
                    //isClosing = false;
                    isOpened = true;
                    isOpening = false;
                }
                Debug.Log("Hei");
            }
            else
            {
                if (yAngle - targetOpenAngle > 0.0f)
                {
                    transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y - openSpeed, transform.eulerAngles.z);
                }
                else
                {
                    //isClosed = true;
                    //isClosing = false;
                    isOpened = true;
                    isOpening = false;
                }
                Debug.Log("Sha");
            }

            Debug.Log("Hello");
        }
    }

    void OnTriggerStay(Collider others)
    {
        if (others.CompareTag("Player"))
        {
            // call UI to show tool tip to press what key

            if (!isOpened && !isOpening && isClosed)
            {
                if (Input.GetKey(KeyCode.E))
                {
                    isOpening = true;
                    //isClosing = false;
                }
            }

            else if (!isClosed && !isClosing && isOpened)
            {
                if (Input.GetKey(KeyCode.E))
                {
                    isClosing = true;
                    //isOpening = false;
                    Debug.Log("Hi");
                } 
            }
        }
    }
}
