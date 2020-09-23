using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/// <summary>
/// This is a script for the character room door
/// </summary>
public class LockedRoomTooltip : MonoBehaviour
{
    public GameObject key;
    bool _gotKey;

    public GameObject keyPreview;
    bool _usedKeyOpen;

    // Start is called before the first frame update
    void Start()
    {
        _gotKey = false;
        _usedKeyOpen = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (key.gameObject.activeSelf == false)
        {
            _gotKey = true;
        }

        if(keyPreview.gameObject.activeSelf == false)
        {
            _usedKeyOpen = true;
        }
    }
}
