using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using TMPro;

public class DoorOpen : MonoBehaviour
{
    public GameObject panel = null;
    //private bool _isInsideTrigger = false;
    public Animator _anim;
    private bool _isOpen = false;

    public TextMeshProUGUI interactTooltip;

    /// <summary>
    /// This is a function that play the door close/open animation
    /// </summary>
    public void Operate()
    {
        _isOpen = !_isOpen;
        _anim.SetBool("open", _isOpen);

    }

    void ShowTooltip()
    {
        if (_isOpen)
        {
            interactTooltip.text = "Press 'E' to close.";
            interactTooltip.gameObject.SetActive(true);
        }

        else
        {
            interactTooltip.text = "Press 'E' to open.";
            interactTooltip.gameObject.SetActive(true);
        }
    }

    void HideTooltip()
    {
        interactTooltip.gameObject.SetActive(false);
    }
}
