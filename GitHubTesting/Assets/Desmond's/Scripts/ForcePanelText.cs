using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ForcePanelText : MonoBehaviour
{
    public string missingFurniture;
    public string missingLevelItem;
    public string portalText;
    public string startText;
    public TextMeshProUGUI textDisplay;
    public float typeInterval;
    public AudioSource jokeAudio;
    public AudioClip jokeClip;

    public bool typing;
    // Start is called before the first frame update
    void Start()
    {
        typing = false;
        StartCoroutine(TypeText(startText, 7f));
        jokeAudio.PlayOneShot(jokeClip);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator ShowText(string sentence)
    {
        if(!typing)
        {
            typing = true;
            foreach (char letter in sentence.ToCharArray())
            {
                // adjust waitforseconds time of checkvalid coroutine in ForcePlayerBehave for different texts.
                textDisplay.text += letter;
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
        if(!typing)
        {
            StartCoroutine(ShowText(sentence));
            yield return new WaitForSeconds(waitTime);
            ClearText();
            typing = false;
        }
        else
        {
            yield break;
        }
    }

    public void ClearText()
    {
        textDisplay.text = "";
    }
}
