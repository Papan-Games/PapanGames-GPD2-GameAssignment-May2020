using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

/// <summary>
/// This is a script to do the newspaper operation and checking its condition
/// If the living light is on, player able to read the newspaper.
/// </summary>
public class newspaper : MonoBehaviour
{
    /// <summary>
    /// These are the variables for newspaper asset, newspaper popup image and checking condition if is reading
    /// </summary>
    public GameObject newspaperPanel; //Newspaper popup image
    public GameObject newspaperAsset; //Newspaper asset
    public bool isReading; //Use to check if player is reading newspaper when newspaper popup image is active
    public static bool getNewspaper; //Checking player get newspaper ot not

    /// <summary>
    /// These are the variable for checking the living room light on/off condition
    /// </summary>
    public bool livingRoomWithLight;
    public GameObject livingRoomSwitchObject;

    /// <summary>
    /// Variable for sound source and audioclip
    /// </summary>
    public AudioSource soundSource;
    public AudioClip reading;
    public AudioClip collectSound;

    // Start is called before the first frame update
    void Start()
    {
        newspaperPanel.gameObject.SetActive(false);
        isReading = false;
        livingRoomWithLight = false;
        getNewspaper = false;
    }

    // Update is called once per frame
    void Update()
    {
        checkingIsLight();
    }

    /// <summary>
    /// A function to check whether the living room light is on
    /// </summary>
    void checkingIsLight()
    {
        Vector3 temp = livingRoomSwitchObject.transform.rotation.eulerAngles;
        if (temp.z == 180f)
        {
            livingRoomWithLight = true;
        }
        else if (temp.z == 0f)
        {
            livingRoomWithLight = false;
        }
    }

    /// <summary>
    /// A function for operate newspaper pick up sound and show the newspaper popup image
    /// if living room light is on and is not reading the newspaper
    /// </summary>
    void readNewspaper()
    {
        if (livingRoomWithLight == true && !isReading)
        {
            newspaperPanel.gameObject.SetActive(true);
            isReading = true;
            soundSource.PlayOneShot(reading);
        }
    }

    /// <summary>
    /// A function fot put down the newspaper and play the sound effect
    /// </summary>
    void stopReadNewspaper()
    {
        if (isReading)
        {
            newspaperAsset.gameObject.SetActive(false);
            newspaperPanel.gameObject.SetActive(false);
            soundSource.PlayOneShot(collectSound);
            getNewspaper = true;
        }
    }
}
