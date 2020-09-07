using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseOutlineLookAt : MonoBehaviour
{
    public Camera _camera;
    public float distance;

    private HouseOutlineController prevController;
    private HouseOutlineController currentController;

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
            if(hit.collider.CompareTag("Doors") || hit.collider.CompareTag("cockroach"))
            {
                currentController = hit.collider.GetComponent<HouseOutlineController>();

                if(prevController != currentController)
                {
                    HideOutline();
                    ShowOutline();
                }

                prevController = currentController;
            }

            else
            {
                HideOutline();
            }
        }

        else
        {
            HideOutline();
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
}
