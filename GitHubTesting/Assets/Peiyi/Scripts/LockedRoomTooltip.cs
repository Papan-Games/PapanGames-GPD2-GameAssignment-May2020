using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LockedRoomTooltip : MonoBehaviour
{
    public GameObject key;
    bool _gotKey;

    public GameObject keyPreview;
    bool _usedKeyOpen;

    public TextMeshProUGUI interactTooltip;
    public bool canInteract;
    public string OpenText;

    // Start is called before the first frame update
    void Start()
    {
        _gotKey = false;

        _usedKeyOpen = false;

        interactTooltip.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (key == null)
        {
            _gotKey = true;
        }

        if(keyPreview == null)
        {
            _usedKeyOpen = true;
        }
    }

    void ShowTooltip()
    {
       
        if (_gotKey == true && _usedKeyOpen == false)
        {
            interactTooltip.text = "Press 'E' to use the key to unlock the door.";
        }


        else
        {
            interactTooltip.text = "Press 'E' to interact.";
        }



        interactTooltip.gameObject.SetActive(true);
    }

    void HideTooltip()
    {
        interactTooltip.gameObject.SetActive(false);
    }


}
