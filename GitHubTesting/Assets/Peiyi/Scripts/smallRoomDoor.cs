﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEditor;

public class smallRoomDoor : MonoBehaviour
{
    public Animator _anim;

    private bool _isOpen = false;
    private bool _isLocked = true;

    GameObject key;

    public bool getKey; //Get Small Room Key


    public GameObject keyPreview;

    public TextMeshProUGUI operateTooltip;

    /// <summary>
    /// Variable for sound source and audioclip
    /// </summary>
    [SerializeField] private AudioSource soundSource;
    [SerializeField] private AudioClip doorLocked;
    [SerializeField] private AudioClip unlockDoor;
    [SerializeField] private AudioClip openDoor;
    [SerializeField] private AudioClip closeDoor;


    /// <summary>
    /// Assigned key object through find the object name in hierachy
    /// 
    /// </summary>
    private void Start()
    {
        key = GameObject.Find("SmallRoomKey");
        getKey = false;
    }


    /// <summary>
    /// Check whether players got the small room key or not
    /// If yes, getKey = true
    /// </summary>
    private void Update()
    {
        if (key.gameObject.activeSelf == false && getKey != true)
        {
            getKey = true;
        }
    }

    /// <summary>
    /// This is a function to play the Small Room door animation
    /// It will be called if player is facing the door the press E
    /// </summary>
    public void Operate()
    {

        if (_isLocked == false)
        {
            _isOpen = !_isOpen;
            _anim.SetBool("open", _isOpen);
            if(_isOpen == true)
            {
                soundSource.PlayOneShot(openDoor);
            }
            else if (_isOpen == false)
            {
                soundSource.PlayOneShot(closeDoor);
            }
        }

        else if (_isLocked == true)
        {
            if (getKey == true)
            {
                _isOpen = !_isOpen;
                _anim.SetBool("open", _isOpen);
                _isLocked = false;
                keyPreview.SetActive(false);
                operateTooltip.text = "Door is unlocked successfully!";
                operateTooltip.gameObject.SetActive(true);
                Debug.Log("unlock");

                soundSource.PlayOneShot(unlockDoor);
            }

            else
            {
                operateTooltip.text = "Cannot open the door.\nPlease try it again when key found";
                operateTooltip.gameObject.SetActive(true);
                Debug.Log("lock");
                soundSource.PlayOneShot(doorLocked);
            }
            StartCoroutine(Wait());
        }
    }

    /// <summary>
    /// Wait for 2 seconds for hiding the tooltip
    /// </summary>
    /// <returns></returns>
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(2);
        operateTooltip.gameObject.SetActive(false);
    }
}
