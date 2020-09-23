using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;

/// <summary>
/// Attach this script to player.
/// A script for checking if player point to the highlight item.
/// If yes, player will see the key prompt.
/// If player press 'E', will operate sth
/// </summary>
public class HouseOutlineLookAt : MonoBehaviour
{
    public Camera _camera;
    public float distance; //Distance between the raycast with the gameobjects

    //Take HouseOutlingController script reference
    private HouseOutlineController prevController;
    private HouseOutlineController currentController;

    //This is the GameObject variable for operate text
    public GameObject operateTooltip;

    //Take KeyPrompt script reference
    public KeyPrompt promptScript;

    public GameObject livingRoomLight; //Attach One of the living light GameObject into this variable
    bool lightOn; //Check if the living ight is on
    bool isReadingNews; //For checking if is reading news

    // Start is called before the first frame update
    void Start()
    {
        isReadingNews = false;
    }

    // Update is called once per frame
    void Update()
    {
        //If living room light is on, the boolean lightOn = true
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

    /// <summary>
    /// A function to check is it the raycast has hit the colliders of the interactable item
    /// If yes, the prompt key will show.
    /// It will only check if there is no any popup panel show
    /// </summary>
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

    //Call the HouseOutlineController' function to show the object outline
    private void ShowOutline()
    {
        if (currentController != null)
        {
            currentController.ShowOutline();
        }
    }

    //Call the HouseOutlineController' function to hide the object outline
    private void HideOutline()
    {
        if (prevController != null)
        {
            prevController.HideObject();
            prevController = null;
        }
    }
}
