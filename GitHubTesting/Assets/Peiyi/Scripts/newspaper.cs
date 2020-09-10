using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class newspaper : MonoBehaviour
{
    public Camera _camera;

    public GameObject newspaperPanel;
    public GameObject newspaperAsset;
    public bool isReading;

    public bool livingRoomWithLight;
    public GameObject livingRoomSwitchObject;

    public TextMeshProUGUI interactTooltip;

    /// <summary>
    /// Variable for sound source and audioclip
    /// </summary>
    [SerializeField] private AudioSource soundSource;
    [SerializeField] private AudioClip reading;
    [SerializeField] private AudioClip collectSound;

    // Start is called before the first frame update
    void Start()
    {
        newspaperPanel.gameObject.SetActive(false);
        isReading = false;
        livingRoomWithLight = false;
    }

    // Update is called once per frame
    void Update()
    {
        checkingIsLight();
    }

    void checkingIsLight()
    {
        Vector3 temp = livingRoomSwitchObject.transform.rotation.eulerAngles;
        if (temp.z == 180f)
        {
            livingRoomWithLight = true;
        }
        else if (temp.z == 0f)
        {
            livingRoomWithLight = false;
        }
        //readingNewspaper.isLight = livingRoomWithLight;
    }

    void readNewspaper()
    {
        if (livingRoomWithLight == true && !isReading)
        {
            newspaperPanel.gameObject.SetActive(true);
            Debug.Log("reading");
            isReading = true;
            soundSource.PlayOneShot(reading);
        }
    }

    void stopReadNewspaper()
    {
        if (isReading)
        {
            newspaperAsset.gameObject.SetActive(false);
            newspaperPanel.gameObject.SetActive(false);
            soundSource.PlayOneShot(collectSound);
        }
    }

    void ShowTooltip()
    {
        if (livingRoomWithLight == true)
        {
            interactTooltip.text = "Press 'E' to interact.";
            interactTooltip.gameObject.SetActive(true);
        }
    }

    

}
