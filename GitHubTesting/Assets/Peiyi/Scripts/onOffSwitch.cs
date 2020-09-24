using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/// <summary>
/// This is a script for checking the light condition and do the light operation
/// </summary>
public class onOffSwitch : MonoBehaviour
{
    public bool _isOnLight; //For checking is on the light
    public GameObject[] lights; //The light asset that affect by the switch itself

    /// <summary>
    /// Variable for sound source and audio clip
    /// </summary>
    public AudioSource soundSource;
    public AudioClip onOffLight;

    
    /// <summary>
    /// A function for lights operation.
    /// When the switch z rotation is 180f, that means the light is on.
    /// Else if the switch z rotation is 0f, the light is off.
    /// </summary>
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

            soundSource.PlayOneShot(onOffLight);
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
            soundSource.PlayOneShot(onOffLight);
        }
    }
}
