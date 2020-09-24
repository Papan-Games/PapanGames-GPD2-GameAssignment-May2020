using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PortalToHome : MonoBehaviour
{
    public Collider TriggerArea1;
    public Collider TriggerArea2;

    public Collider SelfTriggerArea;
    public GameObject Portal2;

    public string portalSentence;

    public ForcePanelText typewriterScript;

    int iterator = 0;
    int iterator2 = 0;
    // Start is called before the first frame update
    void Start()
    {

        SelfTriggerArea.enabled = !enabled;
        Portal2.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (iterator2 == 0)
        {
            InventoryManager.instance.GetFlashlight();
            InventoryManager.instance.GetGun();
            InventoryManager.instance.GetTV();
            InventoryManager.instance.GetChair();
            InventoryManager.instance.GetWashingMachine();
            iterator2++;
        }

        if (!TriggerArea1.enabled && iterator == 0)
        {
            if(!TriggerArea2.enabled)
            {
                SelfTriggerArea.enabled = enabled;
                iterator++;
            }
        }
    }

    
    private void OnTriggerEnter(Collider other) 
    {
        if (other.CompareTag("Player"))
        {
            Portal2.SetActive(true);
            StartCoroutine(typewriterScript.TypeText(portalSentence, 5.0f));
        }
    }

}
