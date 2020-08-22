using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutlineLookAt : MonoBehaviour
{
    public Camera playerCam;
    public float maxDistance;

    private OutlineController prevController;
    private OutlineController currentController;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        LookAt();
    }

    private void LookAt()
    {
        //Ray ray = playerCam.ScreenPointToRay(Input.mousePosition);
        Ray ray = new Ray (playerCam.transform.position, playerCam.transform.forward);

        RaycastHit hit;

        if(Physics.Raycast(ray, out hit, maxDistance))
        {
            if(hit.collider.CompareTag("Interactable"))
            {
                currentController = hit.collider.GetComponent<OutlineController>();

                if(prevController != currentController)
                {
                    HideOutline();
                    ShowOutline();

                    prevController = currentController;
                }
            }
            else
            {
                HideOutline();
            }
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
        if(prevController != null)
        {
            prevController.HideOutline();
            prevController = null;
        }
    }
}
