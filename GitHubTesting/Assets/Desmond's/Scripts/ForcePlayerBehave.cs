using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForcePlayerBehave : MonoBehaviour
{
    public GameObject ForcePanel;

    public bool requireFlashlight;
    public bool requireGun;
    public bool requireKeycard;

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
        if (requireFlashlight)
        {
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

        else if (requireGun)
        {
            if(!InventoryManager.instance.gun)
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

        else if (requireKeycard)
        {
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

        else
        {
            result = true;
        }
    }
}
