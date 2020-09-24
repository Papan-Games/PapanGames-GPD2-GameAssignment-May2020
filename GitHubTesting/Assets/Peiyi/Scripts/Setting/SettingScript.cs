using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

/// <summary>
/// A script for the setting popup
/// If the popup is shown, game pause.
/// Else, game play.
/// Player can adjust game volume and mute or unmute game.
/// </summary>
public class SettingScript : MonoBehaviour
{
    public Button muteUnmuteButton;
    public TextMeshProUGUI MuteUnmuteText;

    public GameObject SettingPopup;
    public Slider volumeSlider;
    public static bool isMute;

    public float soundVolume;
    string newVolume = "VOLUME_SLIDER";


    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        SettingPopup.SetActive(false);
        string mute = PlayerPrefs.GetString("Mute", "false");
        volumeSlider.value = PlayerPrefs.GetFloat(newVolume, 1);

        // Get boolean using PlayerPrefs
        isMute = PlayerPrefs.GetInt("isMute") == 1 ? true : false;
        if (isMute == false)
        {
            AudioListener.volume = 0;
            MuteUnmuteText.text = "Unmute";
            PlayerPrefs.SetString("Mute", "true");
            //Save boolean using PlayerPrefs
            PlayerPrefs.SetInt("isMute", isMute ? 1 : 0);
            isMute = true;
        }

        else
        {
            AudioListener.volume = volumeSlider.value;
            MuteUnmuteText.text = "Mute";
            PlayerPrefs.SetString("Mute", "false");
            PlayerPrefs.SetInt("isMute", isMute ? 1 : 0);
            isMute = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(isMute)
        {
            volumeSlider.interactable = false;
        }
        else
        {
            volumeSlider.interactable = true;
        }
    }

    //Adjust the game volume
    public void AdjustVolume(float _volume)
    {
        AudioListener.volume = _volume;
        PlayerPrefs.SetFloat("VOLUME_SLIDER", _volume);
    }

    //Pause the game, for InGamePopup script use
    public void OnClickPause()
    {
        if (Time.timeScale != 0)
        {
            Time.timeScale = 0;
        }

    }

    //Mute or unmute the game
    public void OnClickMuteUnmute()
    {
        if (!isMute)
        {
            AudioListener.volume = 0; ;
            MuteUnmuteText.text = "Unmute";
            PlayerPrefs.SetString("Mute", "true");
            PlayerPrefs.SetInt("isMute", isMute ? 1 : 0);
            isMute = true;
        }

        else
        {
            AudioListener.volume = volumeSlider.value;
            MuteUnmuteText.text = "Mute";
            PlayerPrefs.SetString("Mute", "false");
            PlayerPrefs.SetInt("isMute", isMute ? 1 : 0);
            isMute = false;
        }
    }

    //Close the menu panel
    public void CloseMenu()
    {
        SettingPopup.SetActive(false);
        Time.timeScale = 1;

    }

    //On click the main menu button, then return to main menu scene
    public void OnClickMainMenu()
    {
        SceneManager.LoadScene(0);
    }


}
