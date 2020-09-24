using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogue : MonoBehaviour
{
    public TextMeshProUGUI textDisplay;
    public string[] sentences;
    private int index;

    public float typingSpeed;
    private bool typing;

    public GameObject continueText;
    private bool started;

    public GameObject textBG;

    private void Awake()
    {
        Messenger.AddListener(GameEvent.DIALOGUE_START, StartDialogue);
    }

    private void OnDestroy()
    {
        Messenger.RemoveListener(GameEvent.DIALOGUE_START, StartDialogue);
    }

    void Start()
    {
        continueText.SetActive(false);
        started = false;
        textBG.SetActive(false);
    }

    void Update()
    {
        // Set active click to continue text when each sentence is finished typing
        if (textDisplay.text == sentences[index])
        {
            continueText.SetActive(true);
        }
        // Next sentence will run if the player click left mouse button with condition of completion of previous sentence
        if (started && !typing && Input.GetKeyDown(KeyCode.Mouse0))
        {
            NextSentence();
        }
    }

    /// <summary>
    /// Start running the dialogue when receive DIALOGUE_START game event broadcast
    /// </summary>
    private void StartDialogue()
    {
        textBG.SetActive(true);
        started = true;
        StartCoroutine(Type());
    }

    /// <summary>
    /// Add a delay in between each letter for typewriter effect
    /// </summary>
    /// <returns>Typing speed is the delay in between and the value is specified through inspector</returns>
    IEnumerator Type()
    {
        foreach(char letter in sentences[index].ToCharArray())
        {
            continueText.SetActive(false);
            typing = true;
            textDisplay.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
        typing = false;
    }

    /// <summary>
    /// Next sentence will continue displaying until the index runs out
    /// </summary>
    private void NextSentence()
    {
        continueText.SetActive(false);

        if (index < sentences.Length - 1)
        {
            index++;
            textDisplay.text = "";
            StartCoroutine(Type());
        }
        else
        {
            textDisplay.text = "";
            continueText.SetActive(false);
            textBG.SetActive(false);
            Messenger.Broadcast(GameEvent.DIALOGUE_END);
        }
    }
}
