using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// A script for changing pages of the credit pages after the ending dialogue end.
/// </summary>
public class ChangingPage : MonoBehaviour
{
    public GameObject endingDialogue; //A variable for ending dialogue
    public GameObject[] creditPages; //array of Credit pages
    public float TimeWait; //The time wait for go to the next page
    bool showing; //Check is the credit page is showing
    int i; //The count for the credit page

    // Start is called before the first frame update
    void Start()
    {
        showing = false;
        i = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(endingDialogue.activeSelf == false)
        {
            NextPage();
        }

        if(i == creditPages.Length)
        {
            StartCoroutine(loadLevel(0));
        }
    }

    /// <summary>
    /// Check is it the page is showing
    /// </summary>
    /// <param name="page"></param>
    /// <returns></returns>
    public IEnumerator CheckPage(GameObject page)
    {
        if (!showing)
        {
            showing = true;
        }

        else
        {
            yield break;
        }
    }

    /// <summary>
    /// Use to do the change page operation
    /// </summary>
    /// <param name="page"></param>
    /// <param name="waitTime"></param>
    /// <returns></returns>
    public IEnumerator ShowPage(GameObject page, float waitTime)
    {
        if (!showing)
        {
            creditPages[i].SetActive(true);
            StartCoroutine(CheckPage(page));
            yield return new WaitForSeconds(waitTime);
            showing = false;
            creditPages[i].SetActive(false);
            i++;
            NextPage();
        }

        else
        {
            yield break;
        }
    }

    /// <summary>
    /// Wait for a specific time, then go next page
    /// </summary>
    public void NextPage()
    {
        if (i < creditPages.Length)
        {
            StartCoroutine(ShowPage(creditPages[i], TimeWait));
        }
    }

    /// <summary>
    /// If all the pages is shown, go back Main Menu
    /// </summary>
    /// <param name="levelIndex"></param>
    /// <returns></returns>
    IEnumerator loadLevel(int levelIndex)
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(levelIndex);
    }
}
