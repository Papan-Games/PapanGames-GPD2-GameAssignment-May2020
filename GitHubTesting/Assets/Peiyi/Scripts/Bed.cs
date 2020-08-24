using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Bed : MonoBehaviour
{
    public GameObject questionPanel;
    bool isOpen;

    public Button yes;
    public Button no;
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
                SceneManager.LoadScene("SpaceStation");
            }

            else if (Input.GetKeyDown(KeyCode.N))
            {
                questionPanel.SetActive(false);
                isOpen = false;
            }
        }
    }

    public void interactBed()
    {
        //Ask player whether to sleep or not
        if (isOpen == false)
        {
            questionPanel.SetActive(true);
            isOpen = true;
        }
    }

    public void yesButton()
    {
        
            if (Input.GetKeyDown(KeyCode.Y))
            {
                SceneManager.LoadScene("SpaceStation");
            }

            
        
    }

    public void noButton()
    {
        
            questionPanel.SetActive(false);
            isOpen = false;
        
    }

}
