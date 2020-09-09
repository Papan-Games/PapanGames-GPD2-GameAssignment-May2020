using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hatchopen : MonoBehaviour
{
    public bool invertDoorOpenDirection = false;
    private float openAngle = 75.0f;
    private bool isOpening;
    [SerializeField] private float targetAngle;
    [SerializeField] private bool isOpened;
    [SerializeField] private float openSpeed = 1.0f;
    [SerializeField] private AudioSource DoorSFX;

    public KeyPrompt promptScript;

    public ForcePlayerBehave scriptRef;

    // Start is called before the first frame update
    void Start()
    {
        DoorSFX = GetComponent<AudioSource>();
        isOpened = false;
        isOpening = false;
        if(!invertDoorOpenDirection)
        {
            targetAngle = transform.eulerAngles.y - openAngle;
        }
        else
        {
            targetAngle = transform.eulerAngles.y + openAngle;
        }
    }

    // Update is called once per frame
    void Update()
    {
        CheckHatch();
    }

    void CheckHatch()
    {
        if(isOpening)
        {
            float yAngle = transform.eulerAngles.y;
            if(!invertDoorOpenDirection)
            {
                if (yAngle - targetAngle > 0.0f)
                {
                    transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y - openSpeed, transform.eulerAngles.z);
                }
                else
                {
                    isOpened = true;
                    isOpening = false;
                }
            }
            else
            {
                if(targetAngle - yAngle > 0.0f)
                {
                    transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y + openSpeed, transform.eulerAngles.z);
                }
                else
                {
                    isOpened = true;
                    isOpening = false;
                }
            }
        }
    }

    void OnTriggerStay(Collider others)
    {
         if (others.CompareTag("Player"))
        {
            // call UI to show tool tip to press what key
            if(!isOpened && !isOpening)
            {
                promptScript.ShowPrompt = true;
                if(Input.GetKey(KeyCode.E))
                {
                    if(scriptRef.runCoroutine())
                    {
                        isOpening = true;
                        DoorSFX.Play();
                    }
                }
            }
        }
    }

    private void OnTriggerExit(Collider other) 
    {
        promptScript.ShowPrompt = false;
    }

}