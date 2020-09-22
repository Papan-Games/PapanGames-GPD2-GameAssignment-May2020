using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SettingScript : MonoBehaviour
{
    public Button muteUnmuteButton;
    //public Sprite muteSprite;
    //public Sprite unmuteSprite;
    public Text MuteUnmuteText;

    public GameObject OptionMenu;
    //public AudioSource soundSource;
    public Slider volomeSlider;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        OptionMenu.SetActive(false);
        //script = GameObject.Find("MenuOptions").GetComponent<MenuButtons>();
        string mute = PlayerPrefs.GetString("Mute", "false");
        if (mute == "true")
        {
            AudioListener.pause = true;
            //muteUnmuteButton.image.sprite = unmuteSprite;
            MuteUnmuteText.text = "Unmute";
        }

        else
        {
            AudioListener.pause = false;
            //muteUnmuteButton.image.sprite = muteSprite;
            MuteUnmuteText.text = "Mute";
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    //Pause the game
    public void OnClickPause()
    {
        if (Time.timeScale != 0)
        {
            Time.timeScale = 0;
            OptionMenu.SetActive(true);
        }

    }

    //Mute or unmute the game
    public void OnClickMuteUnmute()
    {
        if (!AudioListener.pause)
        {
            AudioListener.pause = true;
            //muteUnmuteButton.image.sprite = unmuteSprite;
            MuteUnmuteText.text = "Unmute";
            PlayerPrefs.SetString("Mute", "true");
        }

        else
        {
            AudioListener.pause = false;
            //muteUnmuteButton.image.sprite = muteSprite;
            MuteUnmuteText.text = "Mute";
            PlayerPrefs.SetString("Mute", "false");
        }
    }

    //Close the menu panel
    public void OnClickCloseMenu()
    {
        //MenuOption.gameObject.SetActive(false);
        OptionMenu.SetActive(false);
        Time.timeScale = 1;

    }

    //On click the main menu button, then return to main menu scene
    public void OnClickMainMenu()
    {
        SceneManager.LoadScene("0");
    }

        
}
