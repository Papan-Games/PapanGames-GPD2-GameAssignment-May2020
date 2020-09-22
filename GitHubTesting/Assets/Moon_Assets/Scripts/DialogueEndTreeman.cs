using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class DialogueEndTreeman : MonoBehaviour
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
        Messenger.AddListener(GameEvent.FINAL_DIALOGUE_START, StartDialogue);
    }

    private void OnDestroy()
    {
        Messenger.RemoveListener(GameEvent.FINAL_DIALOGUE_START, StartDialogue);
    }

    void Start()
    {
        continueText.SetActive(false);
        started = false;
        textBG.SetActive(false);
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
        textBG.SetActive(true);
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
            textBG.SetActive(false);
            Messenger.Broadcast(GameEvent.FINAL_DIALOGUE_END);
            StartCoroutine(LoadNextLevel());
        }
    }

    IEnumerator LoadNextLevel()
    {
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene("2nd SpaceStation");
    }
}
