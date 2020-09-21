using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class key : MonoBehaviour
{
    public bool getKey; // Get room key
    public TextMeshProUGUI interactTooltip;

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

    // Update is called once per frame
    void Update()
    {
        
    }

    void Operate()
    {
        GameObject.Find("SmallRoomKey").gameObject.SetActive(false);
        getKey = true;
        soundSource.PlayOneShot(collectSound);
    }

    void ShowTooltip()
    {
        
        interactTooltip.text = "Press 'E' to pick up your key.";
        interactTooltip.gameObject.SetActive(true);
        
    }
}
