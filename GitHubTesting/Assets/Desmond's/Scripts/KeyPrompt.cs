using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyPrompt : MonoBehaviour
{
    // Start is called before the first frame update
    
    public GameObject Pressed;
    public GameObject NotPressed;

    public bool ShowPrompt;
    private bool showingPrompt;
    void Start()
    {
        ShowPrompt = false;
        showingPrompt = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(ShowPrompt)
        {
            if (!showingPrompt)
            {
                StartCoroutine(PromptKeyE());
            }
        }
        else if (Pressed.activeSelf || NotPressed.activeSelf)
        {
            Pressed.SetActive(false);
            NotPressed.SetActive(false);
        }
    }

    IEnumerator PromptKeyE()
    {
        showingPrompt = true;
        Pressed.SetActive(true);
        NotPressed.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        NotPressed.SetActive(false);
        yield return new WaitForSeconds(0.5f);
        showingPrompt = false;
    }
}
