using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class StartingDialogue : MonoBehaviour
{
    public GameObject startingPanel;
    public GameObject secondPanel;

    /// <summary>
    /// Variable for sound source and audio clip
    /// </summary>
    [SerializeField] AudioSource soundSource;
    [SerializeField] AudioClip panelSound;

    void Start()
    {
        startingPanel.SetActive(true);
        secondPanel.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (startingPanel.activeSelf == true)
            {
                startingPanel.SetActive(false);
                secondPanel.SetActive(true);
                soundSource.PlayOneShot(panelSound);
            }

            else if (secondPanel.activeSelf == true)
            {
                secondPanel.SetActive(false);
                this.gameObject.SetActive(false);
                soundSource.PlayOneShot(panelSound);
            }

        }

        
    }

    
}
