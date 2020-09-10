using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class onOffFanSwitch : MonoBehaviour
{
    bool _isOnFan;
    public GameObject Fan;
    public Animator _anim;

    public TextMeshProUGUI interactTooltip;

    /// <summary>
    /// Variable for sound source and audio clip
    /// </summary>
    [SerializeField] private AudioSource soundSource;
    [SerializeField] private AudioClip onOffFan;
    [SerializeField] private AudioClip fanMoving;

    public AudioSource fan;


    // Start is called before the first frame update
    void Start()
    {
        _isOnFan = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Operate()
    {
        if (this.gameObject.transform.rotation.eulerAngles.z == 180f)
        {
            _isOnFan = true;
        }
        else if (this.gameObject.transform.rotation.eulerAngles.z == 0f)
        {
            _isOnFan = false;

        }

        if (!_isOnFan)
        {
            Vector3 temp = this.gameObject.transform.rotation.eulerAngles;
            temp.z = 180.0f;
            this.gameObject.transform.rotation = Quaternion.Euler(temp);
            _isOnFan = true;

            //On fan here
            _anim.SetBool("onFan", _isOnFan);
            soundSource.PlayOneShot(onOffFan);
            fan.Play();
        }

        else if (_isOnFan)
        {
            Vector3 temp = this.gameObject.transform.rotation.eulerAngles;
            temp.z = 0f;
            this.gameObject.transform.rotation = Quaternion.Euler(temp);
            _isOnFan = false;

            //Off fan here
            _anim.SetBool("onFan", _isOnFan);
            soundSource.PlayOneShot(onOffFan);
            fan.Stop();
        }
    }

    public void ShowTooltip()
    {
        if (_isOnFan)
        {
            interactTooltip.text = "Press 'E' to off the fan.";
            interactTooltip.gameObject.SetActive(true);
        }

        else
        {
            interactTooltip.text = "Press 'E' to on the fan.";
            interactTooltip.gameObject.SetActive(true);
        }
    }
}
