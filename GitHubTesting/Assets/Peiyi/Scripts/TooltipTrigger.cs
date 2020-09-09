using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;

public class TooltipTrigger : MonoBehaviour
{
    //public GameObject canvas;
    public TextMeshProUGUI tooltip;
    public bool canInteract;
    public string OpenText;

    
    void Start()
    {
        //tooltip.gameObject.SetActive(false);
        canInteract = false;

    }

    private void Update()
    {
        

    }


    void showToolTipText()
    {
        
        tooltip.gameObject.SetActive(true);
        tooltip.text = "Press 'E' to " + OpenText;
        canInteract = true;
    }

    void hidetooltip()
    {
        tooltip.gameObject.SetActive(false);
        tooltip.text = "";
    }
    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.CompareTag("Player"))
    //    {
    //        tooltip.gameObject.SetActive(true);
    //        tooltip.text = "Press 'E' to " + OpenText;
    //        canInteract = true;
    //        Debug.Log("yes");
    //        //Messenger.Broadcast(GameEvent.TOOLTIP_IN_RANGE);
    //    }
    //}

    //private void OnTriggerExit(Collider other)
    //{
    //    if (other.CompareTag("Player"))
    //    {
    //        tooltip.gameObject.SetActive(false);
    //        canInteract = false;
    //        //Messenger.Broadcast(GameEvent.TOOLTIP_NOT_IN_RANGE);
    //    }
    //}

    //void showInteractWord()
    //{
    //    //tooltip.gameObject.SetActive(true);
    //    tooltip.text = "Press 'E' to interact";
    //}

    //void showOpenWord()
    //{
    //    //tooltip.gameObject.SetActive(true);
    //    tooltip.text = "Press 'E' to open";
    //}

    //void showUseWord()
    //{
    //    //tooltip.gameObject.SetActive(true);
    //    tooltip.text = "Press 'E' to use";
    //}

    //void closeTooltip()
    //{
    //    tooltip.gameObject.SetActive(false);
    //}
}
