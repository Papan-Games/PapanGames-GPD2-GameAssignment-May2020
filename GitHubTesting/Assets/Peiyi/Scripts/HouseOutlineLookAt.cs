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


    public GameObject operateTooltip;
    public TextMeshProUGUI interactTooltip;

    public KeyPrompt promptScript;
    //private bool turnOffprompt;

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
        
        Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if(Physics.Raycast(ray, out hit, distance))
        {
            if(hit.collider.CompareTag("Doors") || hit.collider.CompareTag("cockroach") ||
               hit.collider.CompareTag("smallRoomKey") || hit.collider.CompareTag("Interactable") ||
               hit.collider.CompareTag("bed") || hit.collider.CompareTag("powerSwitch") ||
               hit.collider.CompareTag("cailingFanSwitch") || hit.collider.tag == "missiingItems")
            {
                if (operateTooltip.activeSelf == false)
                {
                    promptScript.ShowPrompt = true;
                    //turnOffprompt = true;
                }

                else
                {
                    promptScript.ShowPrompt = false;
                    //turnOffprompt = false;
                }

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

                //hit.collider.SendMessage("ShowTooltip",
                //SendMessageOptions.DontRequireReceiver);
            }

            else if (hit.collider.CompareTag("newspaper"))
            {

                if (lightOn == true)
                {
                    if (operateTooltip.activeSelf == false && isReadingNews == false)
                    {
                        promptScript.ShowPrompt = true;
                        //turnOffprompt = true;
                    }

                    else
                    {
                        promptScript.ShowPrompt = false;
                        //turnOffprompt = false;
                    }
                    //if (operateTooltip.gameObject.activeSelf == false)
                    //{
                    //    promptScript.ShowPrompt = true;
                    //    turnOffprompt = true;
                    //}

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
                    //hit.collider.SendMessage("ShowTooltip",
                    //SendMessageOptions.DontRequireReceiver);
                }

            }

            else
            {
                HideOutline();
                //HideTooltip();
                promptScript.ShowPrompt = false;
                //turnOffprompt = false;
            }
        }

        else
        {
            HideOutline();
            // HideTooltip();
            promptScript.ShowPrompt = false;
            //turnOffprompt = false;
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

    //public void HideTooltip()
    //{
    //    interactTooltip.gameObject.SetActive(false);
    //}
}
