using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/// <summary>
/// This is a script for operation of the ceiling fans
/// When the switch is on, the fan animation will play, 
/// and the sound will play
/// </summary>
public class onOffFanSwitch : MonoBehaviour
{
    bool _isOnFan;
    public Animator _anim;

    /// <summary>
    /// Variable for sound source and audio clip
    /// </summary>
    public AudioSource soundSource;
    public AudioClip onOffFan;
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

    /// <summary>
    /// A function to do the fan operation.
    /// If on fan, fan animation play and fan moving sound play.
    /// If off, the fan animation will stop and the moving sound stop also.
    /// </summary>
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
}
