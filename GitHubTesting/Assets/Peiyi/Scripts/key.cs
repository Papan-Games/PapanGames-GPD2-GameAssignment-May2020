using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/// <summary>
/// A script for key operation.
/// Play the pick up key sound.
/// </summary>
public class key : MonoBehaviour
{
    public bool getKey; // Get room key

    /// <summary>
    /// Variable for sound source and audioclip
    /// </summary>
    public AudioSource soundSource;
    public AudioClip collectSound;

    // Start is called before the first frame update
    void Start()
    {
        getKey = false;
    }

    /// <summary>
    /// A function for key operate.
    /// </summary>
    void Operate()
    {
        GameObject.Find("SmallRoomKey").gameObject.SetActive(false);
        getKey = true;
        soundSource.PlayOneShot(collectSound);
    }
}
