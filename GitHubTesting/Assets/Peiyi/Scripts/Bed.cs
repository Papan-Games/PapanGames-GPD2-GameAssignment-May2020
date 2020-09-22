using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class Bed : MonoBehaviour
{
    public GameObject questionPanel;
    bool isOpen;

    public GameObject Inventory, keyPrompt;

    /// <summary>
    /// Variable for sound source and audio clip
    /// </summary>
    public AudioSource soundSource;
    public AudioClip panelSound; //Open or close panel use
    public AudioClip yesSound;

    public Animator _anim;

    // Start is called before the first frame update
    void Start()
    {
        questionPanel.SetActive(false);
        isOpen = false;
    }

    // Update is called once per frame
    void Update()
    {
       
    }

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

    public void yesButton()
    {
        Inventory.SetActive(false);
        keyPrompt.SetActive(false);
        soundSource.PlayOneShot(yesSound);
        questionPanel.SetActive(false);
        _anim.SetTrigger("Start");
        StartCoroutine(loadLevel(2));
        Debug.Log("Hello");
    }

    public void noButton()
    {
        questionPanel.SetActive(false);
        isOpen = false;
        soundSource.PlayOneShot(panelSound);
    }

    IEnumerator loadLevel(int levelIndex)
    {
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene(levelIndex);
    }

}
