using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuOptions : MonoBehaviour
{
    public GameObject Instruction;

    // Start is called before the first frame update
    void Start()
    {
        Instruction.SetActive(false);
        Cursor.lockState = CursorLockMode.None;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void onPlayButton()
    {
        StartCoroutine(loadLevel(1));
    }

    IEnumerator loadLevel(int levelIndex)
    {
        Instruction.SetActive(true);
        Instruction.gameObject.transform.GetChild(1).gameObject.SetActive(false);
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene(levelIndex);
    }

    public void onQuitButton()
    {
        Application.Quit();
    }
}
