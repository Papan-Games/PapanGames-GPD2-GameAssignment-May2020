using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangingPage : MonoBehaviour
{
    public GameObject endingDialogue;
    public GameObject[] creditPages;
    public float TimeWait;
    bool showing;
    int i;

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

    public IEnumerator CheckPage(GameObject page)
    {
        if (!showing)
        {
            showing = true;
            //i++;
        }
        else
        {
            yield break;
        }
    }

    public IEnumerator ShowPage(GameObject page, float waitTime)
    {
        if (!showing)
        {
            //showing = true;
            creditPages[i].SetActive(true);
            //yield return new WaitForSeconds(waitTime);
            //i++;



            StartCoroutine(CheckPage(page));
            yield return new WaitForSeconds(waitTime);
            //ClearText();
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

    public void NextPage()
    {
        if (i < creditPages.Length)
        {
            StartCoroutine(ShowPage(creditPages[i], TimeWait));
        }
    }

    IEnumerator loadLevel(int levelIndex)
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(levelIndex);
    }

    //public void ClearText()
    //{
    //    dialogue.text = "";
    //}

    //public IEnumerator ShowPage(float waitTime)
    //{
    //    //if (!showing)
    //    //{
    //        showing = true;
    //        _anim.SetTrigger("Start");
    //        creditPages[i].SetActive(true);
    //        yield return new WaitForSeconds(waitTime);
    //        creditPages[i].SetActive(false);
    //        i++;
    //    //}
    //    //else
    //    //{
    //       // yield break;
    //    //}
    //}

    //public void NextPage()
    //{
    //    if(i < creditPages.Length)
    //    {
    //        StartCoroutine(ShowPage(TimeWait));
    //    }
    //}
}
