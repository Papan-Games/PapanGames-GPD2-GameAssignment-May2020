using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class showTooltip : MonoBehaviour
{
    private Camera _camera;
    float range = 5f;
    public GameObject tooltip;
    // Start is called before the first frame update
    void Start()
    {
        _camera = GetComponent<Camera>();
        //tooltip = GameObject.Find("Tooltip");
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        Ray ray = new Ray(transform.position, transform.forward);

        if (Physics.Raycast(_camera.transform.position, _camera.transform.forward, out hit, 5f))
            {
            if (hit.collider.tag == "tooltipTrigger")
            {
                hit.collider.SendMessage("showToolTipText",
                SendMessageOptions.DontRequireReceiver);
            }

            else if(hit.collider.tag == "smallRoomDoor")
            {
                hit.collider.SendMessage("showToolTipText",
                SendMessageOptions.DontRequireReceiver);
            }

            else
            {
                tooltip.gameObject.SetActive(false);
            }    
        }
    }
}
