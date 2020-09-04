using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class lineOfSight : MonoBehaviour
{
    float range = 5f;

    public GameObject currentHitObject;

    public float sphereRadius;
    public float maxDistance;
    public LayerMask layerMask;

    private Vector3 origin;
    private Vector3 direction;

    private float currentHitDistance;

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
            origin = transform.position;
            direction = transform.forward;

            RaycastHit hit;
            //Ray ray = new Ray(transform.position, transform.forward);

            if (Physics.SphereCast(origin, sphereRadius, direction, out hit, maxDistance, layerMask, QueryTriggerInteraction.UseGlobal))
            {
                currentHitObject = hit.transform.gameObject;
                currentHitDistance = hit.distance;
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

        else
        {
            currentHitDistance = maxDistance;
            currentHitObject = null;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Debug.DrawLine(origin, origin + direction * currentHitDistance);
        Gizmos.DrawWireSphere(origin + direction * currentHitDistance, sphereRadius);
    }
}
