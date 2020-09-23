using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuOptions : MonoBehaviour
{
    //public GameObject controlIntructionPanel;
    // Start is called before the first frame update
    void Start()
    {
        //controlIntructionPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void onPlayButton()
    {
        SceneManager.LoadScene("FirstLevel_Peiyi");
    }

    public void onQuitButton()
    {
        Application.Quit();
    }
}
