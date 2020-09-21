using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StartingText : MonoBehaviour
{
    public GameObject dialogueText;
    [SerializeField] TextMeshProUGUI dialogue;
    public string[] Sentences;
    //public string secondSentence;
    [SerializeField] float typeInterval;
    [SerializeField] float TimeWait;
    bool typing;
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
