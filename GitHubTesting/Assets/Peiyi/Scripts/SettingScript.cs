using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class SettingScript : MonoBehaviour
{
    public Button muteUnmuteButton;
    //public Sprite muteSprite;
    //public Sprite unmuteSprite;
    public TextMeshProUGUI MuteUnmuteText;

    public GameObject SettingPopup;
    public GameObject confirmPopup;
    //public AudioSource soundSource;
    public Slider volomeSlider;

    bool isPause;

    public static float soundVolume;

    // Start is called before the first frame update
    void Start()
    {
        isPause = false;
        Time.timeScale = 1;
        SettingPopup.SetActive(false);
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
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(isPause == false)
            {
                SettingPopup.SetActive(true);
                OnClickPause();
                isPause = true;
            }

            else
            {
                CloseMenu();
                isPause = false;
            }
        }

        
    }

    //public void AdjustVolume()
    //{

    //}

    //Pause the game
    public void OnClickPause()
    {
        if (Time.timeScale != 0)
        {
            Time.timeScale = 0;
            SettingPopup.SetActive(true);
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
    public void CloseMenu()
    {
        //MenuOption.gameObject.SetActive(false);
        SettingPopup.SetActive(false);
        confirmPopup.SetActive(false);
        Time.timeScale = 1;

    }

    //On click the main menu button, then return to main menu scene
    public void OnClickMainMenu()
    {
        SceneManager.LoadScene(0);
    }

        
}
