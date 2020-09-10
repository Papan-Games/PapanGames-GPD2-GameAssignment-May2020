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

    public Button yes;
    public Button no;

    public TextMeshProUGUI interactTooltip;

    /// <summary>
    /// Variable for sound source and audio clip
    /// </summary>
    [SerializeField] private AudioSource soundSource;
    [SerializeField] private AudioClip panelSound; //Open or close panel use
    [SerializeField] private AudioClip yesSound;

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
        if(questionPanel.activeSelf == true)
        {
            if (Input.GetKeyDown(KeyCode.Y))
            {
                GameObject.Find("Inventory").gameObject.SetActive(false);
                soundSource.PlayOneShot(yesSound);
                questionPanel.SetActive(false);
                _anim.SetTrigger("Start");
                StartCoroutine(loadLevel(2));
            }

            else if (Input.GetKeyDown(KeyCode.N))
            {
                questionPanel.SetActive(false);
                isOpen = false;
                soundSource.PlayOneShot(panelSound);
            }
        }
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

    //public void yesButton()
    //{

    //    if (Input.GetKeyDown(KeyCode.Y))
    //    {
    //        GameObject.Find("Inventory").gameObject.SetActive(false);
    //        soundSource.PlayOneShot(panelSound);

    //        SceneManager.LoadScene("SpaceStation");
    //    }

            
        
    //}

    public void noButton()
    {
        
            questionPanel.SetActive(false);
            isOpen = false;
        
    }

    void ShowTooltip()
    {
        interactTooltip.text = "Press 'E' to interact.";
        interactTooltip.gameObject.SetActive(true);

    }

    void HideTooltip()
    {
        interactTooltip.gameObject.SetActive(false);
    }

    IEnumerator loadLevel(int levelIndex)
    {
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene(levelIndex);
    }

}
