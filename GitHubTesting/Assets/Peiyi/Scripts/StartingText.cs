using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/// <summary>
/// A script for typing the starting scene dialogue
/// </summary>
public class StartingText : MonoBehaviour
{
    public GameObject dialogueText; //Attach the dialogue text mesh pro to it
    public TextMeshProUGUI dialogue; //The dialogue text mesh pro
    public string[] Sentences; //The array for storing the sentences
    public float typeInterval; //The typing speed
    public float TimeWait; //The waiting time to type the next sentence
    bool typing; //Checking whether the sentence is typing
    int i;


    // Start is called before the first frame update
    void Start()
    {
        dialogue.gameObject.SetActive(true);
        i = 0;
        StartCoroutine(TypeText(Sentences[i], TimeWait));
        
    }

    // Update is called once per frame
    void Update()
    {
        if(i == Sentences.Length)
        {
            dialogueText.SetActive(false);
        }
    }

    /// <summary>
    /// A function to do the typewritter effect
    /// </summary>
    /// <param name="sentence"></param>
    /// <returns></returns>
    public IEnumerator ShowText(string sentence)
    {
        if (!typing)
        {
            typing = true;
            foreach (char letter in sentence.ToCharArray())
            {
                // adjust waitforseconds time of checkvalid coroutine in ForcePlayerBehave for different texts.
                dialogue.text += letter;
                yield return new WaitForSeconds(typeInterval);
            }
        }
        else
        {
            yield break;
        }
    }

    /// <summary>
    /// A function to type the sentence
    /// </summary>
    /// <param name="sentence"></param>
    /// <param name="waitTime"></param>
    /// <returns></returns>
    public IEnumerator TypeText(string sentence, float waitTime)
    {
        if (!typing)
        {
            StartCoroutine(ShowText(sentence));
            yield return new WaitForSeconds(waitTime);
            ClearText();
            typing = false;
            i++;
            NextSentence();
        }
        else
        {
            yield break;
        }
    }

    /// <summary>
    /// Wait for some time and go to next sentence
    /// </summary>
    public void NextSentence()
    {
        if (i < Sentences.Length)
        {
            StartCoroutine(TypeText(Sentences[i], TimeWait));
        }
    }

    public void ClearText()
    {
        dialogue.text = "";
    }
}
