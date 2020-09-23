using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGamePopup : MonoBehaviour
{
    public GameObject SettingPopup;
    bool isPause;

    // Update is called once per frame
    void Update()
    {
        if(SettingPopup.activeSelf)
        {
            isPause = true;
        }
        else
        {
            isPause = false;
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPause == false)
            {
                
                SettingPopup.SetActive(true);
                GetComponent<SettingScript>().OnClickPause();
                isPause = true;
            }

            else
            {
                GetComponent<SettingScript>().CloseMenu();
                isPause = false;
            }
        }
    }
}
