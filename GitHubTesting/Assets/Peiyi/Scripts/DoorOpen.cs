﻿using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using TMPro;

public class DoorOpen : MonoBehaviour
{
    public Animator _anim;
    private bool _isOpen = false;


    /// <summary>
    /// Variable for sound source and audio clip
    /// </summary>
    public AudioSource soundSource;
    public AudioClip openDoor;
    public AudioClip closeDoor;

    /// <summary>
    /// This is a function that play the door close/open animation
    /// </summary>
    public void Operate()
    {
        _isOpen = !_isOpen;
        _anim.SetBool("open", _isOpen);
        if(_isOpen == true)
        {
            soundSource.PlayOneShot(openDoor);
        }
        else if(_isOpen == false)
        {
            soundSource.PlayOneShot(closeDoor);
        }
    }
}
