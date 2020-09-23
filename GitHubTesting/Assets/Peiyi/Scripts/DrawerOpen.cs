using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEditor;

/// <summary>
/// This is a script for drawers operation.
/// If the third drawer is first time to open,
/// will show operate text that remind players that key found
/// </summary>
public class DrawerOpen : MonoBehaviour
{
    /// <summary>
    /// Variable for attaching the drawers animator
    /// </summary>
    public Animator _anim;

    /// <summary>
    /// Variable for checking if drawer is opened
    /// </summary>
    private bool _isOpen = false;

    /// <summary>
    /// Variable for checking is it the first time 
    /// to open the third drawer
    /// </summary>
    public bool firstTime;

    /// <summary>
    /// Variable for the third drawer
    /// </summary>
    GameObject drawer_3;

    /// <summary>
    /// Variable for attaching the operate text
    /// </summary>
    public TextMeshProUGUI operateTooltip;

    /// <summary>
    /// Variable for sound source and audio clip
    /// </summary>
    public AudioSource soundSource;
    public AudioClip drawerOpen;
    public AudioClip drawerClose;

    void Start()
    {
        _isOpen = false;
        firstTime = true;
        drawer_3 = GameObject.Find("ThirdDrawer");
    }

    /// <summary>
    /// This is a function to play the Drawer open/close Animations
    /// When Third Drawer is first time to open,
    /// a operateTooltip will be showed
    /// </summary>
    public void Operate()
    {
        operateTooltip.gameObject.SetActive(true);
        _isOpen = !_isOpen;
        _anim.SetBool("DrawerOpen", _isOpen);
        if(_isOpen == true)
        {
            soundSource.PlayOneShot(drawerOpen);
        }

        else if(_isOpen == false)
        {
            soundSource.PlayOneShot(drawerClose);
        }

        if (this.gameObject == drawer_3)
        {
            if (firstTime)
            {
                operateTooltip.text = "Key Found! But there is a cockroach on it.\nI should use somrthing to kill it.";
                operateTooltip.gameObject.SetActive(true);
                firstTime = false;
                StartCoroutine(Wait());
            }

            else
            {
                operateTooltip.gameObject.SetActive(false);
            }
        }

        else
        {
            operateTooltip.gameObject.SetActive(false);
        }
    }

    /// <summary>
    /// When the operateTooltip is SetActive(true),
    /// it will become SetActive(false) automatically 
    /// after 2 seconds
    /// </summary>
    /// <returns></returns>
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(2);
        operateTooltip.gameObject.SetActive(false);
    }
}
