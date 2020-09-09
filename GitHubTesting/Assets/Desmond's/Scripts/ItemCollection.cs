using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollection : MonoBehaviour
{
    public OutlineController outlineRef;


    public enum Items {Flashlight, Gun, Keycard, TV, Chair, WashingMachine}
    public Items item;

    public KeyPrompt promptScript;
    private bool turnOffprompt;
    private void Start() 
    {
        turnOffprompt = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(outlineRef.showingOutline)
        {
            promptScript.ShowPrompt = true;
            turnOffprompt = true;
            if(Input.GetKey(KeyCode.E))
            {
                promptScript.ShowPrompt = false;
                switch(item)
                {
                    case Items.Flashlight:
                    {
                        InventoryManager.instance.GetFlashlight();
                        this.gameObject.SetActive(false);
                        Debug.Log("Store Flashlight");
                        break;
                    }
                    case Items.Gun:
                    {
                        InventoryManager.instance.GetGun();
                        this.gameObject.SetActive(false);
                        Debug.Log("Store Gun");
                        break;
                    }
                    case Items.Keycard:
                    {
                        InventoryManager.instance.GetKeycard();
                        this.gameObject.SetActive(false);
                        Debug.Log("Store Card");
                        break;
                    }
                    case Items.TV:
                    {
                        InventoryManager.instance.GetTV();
                        this.gameObject.SetActive(false);
                        Debug.Log("Store TV");
                        break;
                    }
                    case Items.Chair:
                    {
                        InventoryManager.instance.GetChair();
                        this.gameObject.SetActive(false);
                        Debug.Log("Store Chair");
                        break;
                    }
                    case Items.WashingMachine:
                    {
                        InventoryManager.instance.GetWashingMachine();
                        this.gameObject.SetActive(false);
                        Debug.Log("Store Washing Machine");
                        break;
                    }
                    default:
                        break;
                }
            }
        }
        else if (turnOffprompt)
        {
            promptScript.ShowPrompt = false;
            turnOffprompt = false;
        }
    }
}
