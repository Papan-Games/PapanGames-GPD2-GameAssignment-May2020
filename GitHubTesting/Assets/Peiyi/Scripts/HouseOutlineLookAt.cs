using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HouseOutlineLookAt : MonoBehaviour
{
    public Camera _camera;
    public float distance;

    private HouseOutlineController prevController;
    private HouseOutlineController currentController;


    //public string tooltipText;
    public TextMeshProUGUI tooltip;
    public TextMeshProUGUI interactTooltip;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        HandleLookAtRay();
    }

    private void HandleLookAtRay()
    {
        Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if(Physics.Raycast(ray, out hit, distance))
        {
            if(hit.collider.CompareTag("Doors") || hit.collider.CompareTag("cockroach") ||
               /*hit.collider.CompareTag("smallRoomKey") ||*/ hit.collider.CompareTag("Interactable") ||
               hit.collider.CompareTag("bed") || hit.collider.CompareTag("powerSwitch") ||
               hit.collider.CompareTag("cailingFanSwitch") /*|| hit.collider.tag == "newspaper"*/)
            {
                currentController = hit.collider.GetComponent<HouseOutlineController>();

                if(prevController != currentController)
                {
                    HideOutline();
                    ShowOutline();
                }

                prevController = currentController;

                if (Input.GetKeyDown(KeyCode.E))
                {
                    hit.collider.SendMessage("Operate",
                    SendMessageOptions.DontRequireReceiver);
                }

                hit.collider.SendMessage("ShowTooltip",
                SendMessageOptions.DontRequireReceiver);
            }

            else
            {
                HideOutline();
                HideTooltip();
            }
        }

        else
        {
            HideOutline();
            HideTooltip();
        }
    }

    private void ShowOutline()
    {
        if(currentController != null)
        {
            currentController.ShowOutline();
        }
    }

    private void HideOutline()
    {
        if (prevController != null)
        {
            prevController.HideOutline();
            prevController = null;
        }
    }

    //public void ShowTooltip()
    //{
    //    tooltip.text = "Press 'E' to interact";
    //    tooltip.gameObject.SetActive(true);
    //}

    public void HideTooltip()
    {
        interactTooltip.gameObject.SetActive(false);
    }
}
