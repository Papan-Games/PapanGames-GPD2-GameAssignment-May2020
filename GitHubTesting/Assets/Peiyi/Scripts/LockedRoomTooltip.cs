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

    public TextMeshProUGUI tooltip;
    public bool canInteract;
    public string OpenText;

    // Start is called before the first frame update
    void Start()
    {

        //key = GameObject.Find("SmallRoomKey");
        _gotKey = false;

        //keyPreview = GameObject.Find("KeyPreview");
        _usedKeyOpen = false;

        tooltip.gameObject.SetActive(false);
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

    void showTooltipText()
    {
        if (_gotKey == true && _usedKeyOpen == true)
        {
            tooltip.text = "The door is unlocked.\nPress 'E' to open/close the door" + OpenText;
        }

        else if (_gotKey == false && _usedKeyOpen == false)
        {
            tooltip.text = "Press 'E' to interact" + OpenText;
        }

        else if (_gotKey == true && _usedKeyOpen == false)
        {
            tooltip.text = "Press 'E' to use the key to unlock the door" +OpenText;
        }

        
        tooltip.gameObject.SetActive(true);
    }
}
