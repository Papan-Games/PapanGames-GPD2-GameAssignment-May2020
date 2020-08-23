using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onOffWallLightSwitch : MonoBehaviour
{
    public GameObject wallLight;
    bool _isOnLight;

    // Start is called before the first frame update
    void Start()
    {
        wallLight.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void onOffLight()
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
            Debug.Log("Onwor");
            //On light here
            wallLight.gameObject.SetActive(true);


        }

        else if (_isOnLight)
        {
            Vector3 temp = this.gameObject.transform.rotation.eulerAngles;
            temp.z = 0f;
            this.gameObject.transform.rotation = Quaternion.Euler(temp);
            _isOnLight = false;
            Debug.Log("Offwor");
            //Off Light here

            wallLight.gameObject.SetActive(false);
        }
    }
}
