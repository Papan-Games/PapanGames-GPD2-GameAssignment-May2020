using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForcePlayerBehave : MonoBehaviour
{
    public GameObject ForcePanel;

    public bool Door1;
    public bool Door2;
    public bool Door3;
    public bool Door4;
    // public bool requireChair;
    // public bool requireKeycard;


    private bool result;
    // Start is called before the first frame update
    void Start()
    {
        result = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool runCoroutine()
    {
        StartCoroutine(checkValid());
        return result;
    }
    private IEnumerator checkValid()
    {
        if (Door1)
        {
            // Need Flashlight
            if(!InventoryManager.instance.flashlight)
            {
                result = false;
                ForcePanel.SetActive(true);
                yield return new WaitForSeconds(5);
                ForcePanel.SetActive(false);
            }
            else
            {
                result = true;
            }
            yield return result;
        }

        else if (Door2)
        {
            // Chair and TV
            if(!InventoryManager.instance.Chair || !InventoryManager.instance.TV)
            {
                result = false;
                ForcePanel.SetActive(true);
                yield return new WaitForSeconds(5);
                ForcePanel.SetActive(false);
            }
            else
            {
                result = true;
            }
            yield return result;
        }

        else if (Door3)
        {
            // Gun & Washing Machine
            if(!InventoryManager.instance.gun || !InventoryManager.instance.washingMachine)
            {
                result = false;
                ForcePanel.SetActive(true);
                yield return new WaitForSeconds(5);
                ForcePanel.SetActive(false);
            }
            else
            {
                result = true;
            }
            yield return result;
        }

        else if (Door4)
        {
            // Keycard
            if(!InventoryManager.instance.keycard)
            {
                result = false;
                ForcePanel.SetActive(true);
                yield return new WaitForSeconds(5);
                ForcePanel.SetActive(false);
            }
            else
            {
                result = true;
            }
            yield return result;
        }

        // if (requireFlashlight)
        // {
        //     if(!InventoryManager.instance.flashlight)
        //     {
        //         result = false;
        //         ForcePanel.SetActive(true);
        //         yield return new WaitForSeconds(5);
        //         ForcePanel.SetActive(false);
        //     }
        //     else
        //     {
        //         result = true;
        //     }
        //     yield return result;
        // }

        // else if (requireGun)
        // {
        //     if(!InventoryManager.instance.gun)
        //     {
        //         result = false;
        //         ForcePanel.SetActive(true);
        //         yield return new WaitForSeconds(5);
        //         ForcePanel.SetActive(false);
        //     }
        //     else
        //     {
        //         result = true;
        //     }
        //     yield return result;
        // }

        // else if (requireTV)
        // {
        //     if(!InventoryManager.instance.TV)
        //     {
        //         result = false;
        //         ForcePanel.SetActive(true);
        //         yield return new WaitForSeconds(5);
        //         ForcePanel.SetActive(false);
        //     }
        //     else
        //     {
        //         result = true;
        //     }
        //     yield return result;
        // }

        // else if (requireKeycard)
        // {
        //     if(!InventoryManager.instance.keycard)
        //     {
        //         result = false;
        //         ForcePanel.SetActive(true);
        //         yield return new WaitForSeconds(5);
        //         ForcePanel.SetActive(false);
        //     }
        //     else
        //     {
        //         result = true;
        //     }
        //     yield return result;
        // }

        // else
        // {
        //     result = true;
        // }
    }
}
