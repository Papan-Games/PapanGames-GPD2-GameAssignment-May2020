using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lineOfSight : MonoBehaviour
{
    float range = 5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    /// <summary>
    /// Send message to the target object to do their action
    /// if player press E
    /// </summary>
    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.E))
        //{
            RaycastHit hit;
            Ray ray = new Ray(transform.position, transform.forward);

            if (Physics.Raycast(ray, out hit, range))
            {
            if (hit.collider.tag == "Interactable")
            {
                //Show tool tip here

                if (Input.GetKeyDown(KeyCode.E))
                {
                    //Debug.Log("Hit!");
                    hit.collider.SendMessage("interact",
                    SendMessageOptions.DontRequireReceiver);
                    Debug.Log("interact");
                }
            }

            else if (hit.collider.tag == "Doors")
            {
                //Show tool tip here
                Debug.Log("Aim door");
                if (Input.GetKeyDown(KeyCode.E))
                {
                    //Debug.Log("Hit!");
                    hit.collider.SendMessage("Operate",
                    SendMessageOptions.DontRequireReceiver);
                    Debug.Log("operate");
                }
            }

            else if (hit.collider.tag == "cockroach")
            {
                //Show tool tip here
                Debug.Log("cockroach");
                if (Input.GetKeyDown(KeyCode.E))
                {
                    hit.collider.SendMessage("Operate",
                    SendMessageOptions.DontRequireReceiver);
                }
            }

            else if (hit.collider.tag == "bed")
            {
                //show tool tip here

                if (Input.GetKeyDown(KeyCode.E))
                {
                    hit.collider.SendMessage("interactBed",
                    SendMessageOptions.DontRequireReceiver);
                    Debug.Log("ask question");
                }
            }

            else if (hit.collider.tag == "powerSwitch")
            {
                //show tool tip here
                //Debug.Log("Switch");
                if (Input.GetKeyDown(KeyCode.E))
                {
                    hit.collider.SendMessage("onOffLight",
                    SendMessageOptions.DontRequireReceiver);
                    Debug.Log("on");
                }
            }

            else if (hit.collider.tag == "cailingFanSwitch")
            {
                //show tool tip here
                Debug.Log("Switch");
                if (Input.GetKeyDown(KeyCode.E))
                {
                    hit.collider.SendMessage("onOffFan",
                    SendMessageOptions.DontRequireReceiver);
                    Debug.Log("fan");
                }
            }
        }
        //}
        Debug.DrawLine(transform.position, transform.forward * range);
    }
}
