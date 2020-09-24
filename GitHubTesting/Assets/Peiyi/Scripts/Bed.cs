using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

/// <summary>
/// A script for bed operation.
/// When operate, bed question pop up.
/// If player press 'Yes', load next scene,
/// if press 'No', close the question popup.
/// </summary>

public class Bed : MonoBehaviour
{
    public GameObject questionPanel;
    
    /// <summary>
    /// Use for checking whether the question panel is open or not
    /// </summary>
    bool isOpen;

    /// <summary>
    /// Variables for the inventory gameobject and keyprompt gameobject
    /// </summary>
    public GameObject Inventory, keyPrompt;

    /// <summary>
    /// Variable for sound source and audio clip
    /// </summary>
    public AudioSource soundSource;
    public AudioClip panelSound; //Panel sound
    public AudioClip yesSound; //Load scene sound

    public Animator _anim; //The animator for play fade in fade out scene

    // Start is called before the first frame update
    void Start()
    {
        questionPanel.SetActive(false);
        isOpen = false;
    }

    /// <summary>
    /// Function for bed operation
    /// </summary>
    public void Operate()
    {
        //Ask player whether to sleep or not
        if (isOpen == false)
        {
            questionPanel.SetActive(true);
            isOpen = true;
            soundSource.PlayOneShot(panelSound);
        }
    }

    /// <summary>
    /// A function for operate Yes button
    /// to load next scene
    /// </summary>
    public void yesButton()
    {
        Inventory.SetActive(false);
        keyPrompt.SetActive(false);
        soundSource.PlayOneShot(yesSound);
        questionPanel.SetActive(false);
        _anim.SetTrigger("Start");
        StartCoroutine(loadLevel(2));
    }

    /// <summary>
    /// A function for No button on the bed question
    /// to close the question panel
    /// </summary>
    public void noButton()
    {
        questionPanel.SetActive(false);
        isOpen = false;
        soundSource.PlayOneShot(panelSound);
    }

    /// <summary>
    /// Wait 5 seconds then load next scene
    /// </summary>
    /// <param name="levelIndex"></param>
    /// <returns></returns>
    IEnumerator loadLevel(int levelIndex)
    {
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene(levelIndex);
    }

}
