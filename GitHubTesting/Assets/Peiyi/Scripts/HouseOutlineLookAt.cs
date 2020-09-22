using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;

public class HouseOutlineLookAt : MonoBehaviour
{
    public Camera _camera;
    public float distance;

    private HouseOutlineController prevController;
    private HouseOutlineController currentController;


    public GameObject operateTooltip;

    public KeyPrompt promptScript;

    public GameObject livingRoomLight;
    bool lightOn;
    bool isReadingNews;

    // Start is called before the first frame update
    void Start()
    {
        isReadingNews = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(livingRoomLight.gameObject.activeSelf == true)
        {
            lightOn = true;
        }
        else
        {
            lightOn = false;
        }
        HandleLookAtRay();
    }

    private void HandleLookAtRay()
    {
        if (!EventSystem.current.IsPointerOverGameObject())
        {
            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, distance))
            {
                if (hit.collider.CompareTag("Doors") || hit.collider.CompareTag("cockroach") ||
                   hit.collider.CompareTag("smallRoomKey") || hit.collider.CompareTag("Interactable") ||
                   hit.collider.CompareTag("bed") || hit.collider.CompareTag("powerSwitch") ||
                   hit.collider.CompareTag("cailingFanSwitch") || hit.collider.tag == "missiingItems")
                {
                    if (operateTooltip.activeSelf == false)
                    {
                        promptScript.ShowPrompt = true;
                    }

                    else
                    {
                        promptScript.ShowPrompt = false;
                    }

                    currentController = hit.collider.GetComponent<HouseOutlineController>();

                    if (prevController != currentController)
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
                }

                else if (hit.collider.CompareTag("newspaper"))
                {

                    if (lightOn == true)
                    {
                        if (operateTooltip.activeSelf == false && isReadingNews == false)
                        {
                            promptScript.ShowPrompt = true;
                        }

                        else
                        {
                            promptScript.ShowPrompt = false;
                        }
                        

                        currentController = hit.collider.GetComponent<HouseOutlineController>();

                        if (prevController != currentController)
                        {
                            HideOutline();
                            ShowOutline();
                        }

                        prevController = currentController;

                        if (Input.GetKeyDown(KeyCode.E))
                        {

                            if (lightOn == true && !isReadingNews)
                            {
                                promptScript.ShowPrompt = false;
                                hit.collider.SendMessage("readNewspaper",
                                SendMessageOptions.DontRequireReceiver);
                                isReadingNews = !isReadingNews;
                            }

                            else if (isReadingNews)
                            {
                                hit.collider.SendMessage("stopReadNewspaper",
                               SendMessageOptions.DontRequireReceiver);
                            }

                        }

                    }

                }

                else
                {
                    HideOutline();
                    promptScript.ShowPrompt = false;
                }
            }

            else
            {
                HideOutline();
                promptScript.ShowPrompt = false;
            }
        }
    }

    private void ShowOutline()
    {
        
        if (currentController != null)
        {
            currentController.ShowOutline();
        }
    }

    private void HideOutline()
    {
        
        if (prevController != null)
        {
            prevController.HideObject();
            prevController = null;
        }
    }
}
