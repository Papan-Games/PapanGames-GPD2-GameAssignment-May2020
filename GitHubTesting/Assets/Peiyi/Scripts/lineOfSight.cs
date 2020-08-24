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
        if (Input.GetKeyDown(KeyCode.E))
        {
            RaycastHit hit;
            Ray ray = new Ray(transform.position, transform.forward);

            if (Physics.Raycast(ray, out hit, range))
            {
                if (hit.collider.tag == "Interactable")
                {

                    hit.collider.SendMessage("interact",
                    SendMessageOptions.DontRequireReceiver);

                    hit.collider.SendMessage("showInteractWord",
                    SendMessageOptions.DontRequireReceiver);

                }

                else if (hit.collider.tag == "Doors")
                {

                    hit.collider.SendMessage("Operate",
                    SendMessageOptions.DontRequireReceiver);

                }

                else if (hit.collider.tag == "cockroach")
                {

                    hit.collider.SendMessage("Operate",
                    SendMessageOptions.DontRequireReceiver);

                }

                else if (hit.collider.tag == "bed")
                {

                    hit.collider.SendMessage("interactBed",
                    SendMessageOptions.DontRequireReceiver);
                }

                else if (hit.collider.tag == "powerSwitch")
                {
                    hit.collider.SendMessage("onOffLight",
                    SendMessageOptions.DontRequireReceiver);

                }

                else if (hit.collider.tag == "cailingFanSwitch")
                {
                   
                    hit.collider.SendMessage("onOffFan",
                    SendMessageOptions.DontRequireReceiver);

                }


            }

        }
    }
}
