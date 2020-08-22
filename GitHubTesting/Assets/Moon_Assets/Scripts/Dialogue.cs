﻿using System.Collections;
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
    }

    void Update()
    {
        if (textDisplay.text == sentences[index])
        {
            continueText.SetActive(true);
        }

        if (started && !typing && Input.GetKeyDown(KeyCode.Mouse0))
        {
            NextSentence();
        }
    }

    private void StartDialogue()
    {
        started = true;
        StartCoroutine(Type());
    }

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
            Messenger.Broadcast(GameEvent.DIALOGUE_END);
        }
    }
}
