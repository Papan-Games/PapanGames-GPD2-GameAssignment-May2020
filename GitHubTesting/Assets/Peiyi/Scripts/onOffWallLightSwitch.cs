using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/// <summary>
/// This is a script for checking the light condition and do the light operation
/// This is only for the light beside the stair case.
/// </summary>
public class onOffWallLightSwitch : MonoBehaviour
{
    public GameObject wallLight; //The wall lamp
    bool _isOnLight; //Use for checking the light condition

    /// <summary>
    /// Variable for sound source and audio clip
    /// </summary>
    public AudioSource soundSource;
    public AudioClip onOffWallLight;

    // Start is called before the first frame update
    void Start()
    {
        wallLight.gameObject.SetActive(false);
    }

    /// <summary>
    /// A function for wall lamp operation.
    /// </summary>
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
            soundSource.PlayOneShot(onOffWallLight);

        }

        else if (_isOnLight)
        {
            Vector3 temp = this.gameObject.transform.rotation.eulerAngles;
            temp.z = 0f;
            this.gameObject.transform.rotation = Quaternion.Euler(temp);
            _isOnLight = false;

            //Off Light here
            wallLight.gameObject.SetActive(false);
            soundSource.PlayOneShot(onOffWallLight);
        }
    }
}
