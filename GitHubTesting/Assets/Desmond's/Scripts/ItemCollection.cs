using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollection : MonoBehaviour
{
    public OutlineController outlineRef;

    // public bool Gun;
    // public bool Keycard;
    // public bool item3;
    // public bool item4;

    public enum Items {Flashlight, Gun, Keycard, Item3, Item4}
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
                    case Items.Item3:
                    {
                        Debug.Log("Store Shit1");
                        break;
                    }
                    case Items.Item4:
                    {
                        Debug.Log("Store Shit2");
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
