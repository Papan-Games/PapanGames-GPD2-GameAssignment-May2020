using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// This is a script for Main Menu used
/// </summary>
public class MenuOptions : MonoBehaviour
{
    public GameObject Instruction; //Intruction page

    // Start is called before the first frame update
    void Start()
    {
        Instruction.SetActive(false);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    /// <summary>
    /// This is a function for the play button.
    /// If the button is pressed, load next scene
    /// </summary>
    public void onPlayButton()
    {
        StartCoroutine(loadLevel(1));
    }

    /// <summary>
    /// Before go to the next scene, show the intruction page first
    /// </summary>
    /// <param name="levelIndex"></param>
    /// <returns></returns>
    IEnumerator loadLevel(int levelIndex)
    {
        Instruction.SetActive(true);
        Instruction.gameObject.transform.GetChild(1).gameObject.SetActive(false);
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene(levelIndex);
    }

    /// <summary>
    /// Pressed this to quit game
    /// </summary>
    public void onQuitButton()
    {
        Application.Quit();
    }
}
