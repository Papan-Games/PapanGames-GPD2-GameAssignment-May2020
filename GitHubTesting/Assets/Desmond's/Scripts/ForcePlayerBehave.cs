using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForcePlayerBehave : MonoBehaviour
{
    public GameObject ForcePanel;
    public ForcePanelText TextGUIscript;
    public bool Door1;
    public bool Door2;
    public bool Door3;
    public bool Door4;
    public bool checking;
    public float waitTime;
    // public bool requireChair;
    // public bool requireKeycard;


    private bool result;
    // Start is called before the first frame update
    void Start()
    {
        result = false;
        checking = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool runCoroutine()
    {
        if(!checking)
        {
            checking = true;
            StartCoroutine(checkValid());
            return result;
        }
        else
        {
            return false;
        }
    }
    private IEnumerator checkValid()
    {

        if (Door1)
        {
            // Need Flashlight
            if(!InventoryManager.instance.flashlight)
            {
                result = false;
                StartCoroutine(TextGUIscript.TypeText(TextGUIscript.missingLevelItem, waitTime));

            }
            else
            {
                result = true;
            }
            checking = false;
            yield return result;
        }

        else if (Door2)
        {
            // Chair and TV
            if(!InventoryManager.instance.Chair || !InventoryManager.instance.TV)
            {
                result = false;
                StartCoroutine(TextGUIscript.TypeText(TextGUIscript.missingFurniture, waitTime));

            }
            else
            {
                result = true;
            }
            checking = false;
            yield return result;
        }

        else if (Door3)
        {
            // Gun & Washing Machine
            if(!InventoryManager.instance.gun || !InventoryManager.instance.washingMachine)
            {
                result = false;
                if(!InventoryManager.instance.gun)
                {
                    StartCoroutine(TextGUIscript.TypeText(TextGUIscript.missingLevelItem, waitTime));
                }
                else
                {
                    StartCoroutine(TextGUIscript.TypeText(TextGUIscript.missingFurniture, waitTime));
                }
            }
            else
            {
                result = true;
            }
            checking = false;
            yield return result;
        }

        else if (Door4)
        {
            // Keycard
            if(!InventoryManager.instance.keycard)
            {
                result = false;
                StartCoroutine(TextGUIscript.TypeText(TextGUIscript.missingLevelItem, waitTime));
            }
            else
            {
                result = true;
                StartCoroutine(TextGUIscript.TypeText(TextGUIscript.portalText, waitTime));
            }
            checking = false;
            yield return result;
        }

        
    }
}
