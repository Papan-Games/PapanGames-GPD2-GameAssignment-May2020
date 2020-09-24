using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// This is a script for Level 1 inventory system
/// </summary>
public class Inventory : MonoBehaviour
{
    /// <summary>
    /// Use these image to show the inventory item
    /// </summary>
    public Image newspaperPreview;
    public Image keyPreview;

    // Start is called before the first frame update
    void Start()
    {
        keyPreview.gameObject.SetActive(false);
        newspaperPreview.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //If key asset is not active, key preview will be show in inventory
        if (key.getKey == true)
        {
            keyPreview.gameObject.SetActive(true);
        }

        //If newspaper asset is not active, newspaper preview will be show in inventory
        if (newspaper.getNewspaper == true)
        {
            newspaperPreview.gameObject.SetActive(true);
        }
    }
}
