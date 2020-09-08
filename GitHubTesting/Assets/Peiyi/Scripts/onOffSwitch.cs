﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class onOffSwitch : MonoBehaviour
{
    public bool _isOnLight;
    public GameObject[] lights;

    public TextMeshProUGUI interactTooltip;

        // Start is called before the first frame update
    void Start()
    {
       

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Operate()
    {
        if(this.gameObject.transform.rotation.eulerAngles.z == 180f)
        {
            _isOnLight = true;
        }
        else if(this.gameObject.transform.rotation.eulerAngles.z == 0f)
        {
            _isOnLight = false;

        }

        if (!_isOnLight)
        {
            
            Vector3 temp = this.gameObject.transform.rotation.eulerAngles;
            temp.z = 180.0f;
            this.gameObject.transform.rotation = Quaternion.Euler(temp);
            _isOnLight = true;

            for(int i = 0; i < lights.Length; i++)
            {
                lights[i].gameObject.SetActive(true);
            }
        }

        else if (_isOnLight)
        {
            Vector3 temp = this.gameObject.transform.rotation.eulerAngles;
            temp.z = 0f;
            this.gameObject.transform.rotation = Quaternion.Euler(temp);
            _isOnLight = false;
            for (int i = 0; i < lights.Length; i++)
            {
                lights[i].gameObject.SetActive(false);
            }
        }
    }

    public void ShowTooltip()
    {
        if (_isOnLight)
        {
            interactTooltip.text = "Press 'E' to off the light.";
            interactTooltip.gameObject.SetActive(true);
        }

        else
        {
            interactTooltip.text = "Press 'E' to on the light.";
            interactTooltip.gameObject.SetActive(true);
        }
    }

    public void HideTooltip()
    {
        interactTooltip.gameObject.SetActive(false);
    }


}
