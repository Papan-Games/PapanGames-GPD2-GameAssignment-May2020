using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class onOffWallLightSwitch : MonoBehaviour
{
    public GameObject wallLight;
    bool _isOnLight;

    public TextMeshProUGUI interactTooltip;

    // Start is called before the first frame update
    void Start()
    {
        wallLight.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Operate()
    {
        if(wallLight.gameObject.activeSelf == false)
        {
            _isOnLight = false;
        }
        
        else if (wallLight.gameObject.activeSelf == true)
        {
            _isOnLight = true;
        }

        if (!_isOnLight)
        {
            Vector3 temp = this.gameObject.transform.rotation.eulerAngles;
            temp.z = 180.0f;
            this.gameObject.transform.rotation = Quaternion.Euler(temp);
            _isOnLight = true;
            //On light here
            wallLight.gameObject.SetActive(true);


        }

        else if (_isOnLight)
        {
            Vector3 temp = this.gameObject.transform.rotation.eulerAngles;
            temp.z = 0f;
            this.gameObject.transform.rotation = Quaternion.Euler(temp);
            _isOnLight = false;
            //Off Light here

            wallLight.gameObject.SetActive(false);
        }
    }

    public void ShowTooltip()
    {
        if (_isOnLight)
        {
            interactTooltip.text = "Press 'E' to off the wall light.";
            interactTooltip.gameObject.SetActive(true);
        }

        else
        {
            interactTooltip.text = "Press 'E' to on the wall light.";
            interactTooltip.gameObject.SetActive(true);
        }
    }
}
