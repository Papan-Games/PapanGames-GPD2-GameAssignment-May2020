using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEditor;

public class smallRoomDoor : MonoBehaviour
{
    public Animator _anim;

    private bool _isOpen = false;
    private bool _isLocked = true;

    [SerializeField] GameObject Key_SmallR;

    public bool gotSKey; //Got Small Room Key

    Pickup reference;

    public GameObject keyPreview;

    public TextMeshProUGUI operateTooltip;


    /// <summary>
    /// Assigned Key_SmallR object through find the object name in hierachy
    /// 
    /// </summary>
    private void Start()
    {
        Key_SmallR = GameObject.Find("SmallRoomKey");
        gotSKey = false;
    }


    /// <summary>
    /// Check whether players got the small room key or not
    /// If yes, gotSKey = true
    /// </summary>
    private void Update()
    {
        if (Key_SmallR == null && gotSKey != true)
        {
            gotSKey = true;
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
        }

        else if (_isLocked == true)
        {
            if (gotSKey == true)
            {
                _isOpen = !_isOpen;
                _anim.SetBool("open", _isOpen);
                _isLocked = false;
                keyPreview.SetActive(false);
                operateTooltip.text = "Door is unlocked successfully!";
                operateTooltip.gameObject.SetActive(true);
                Debug.Log("unlock");
            }

            else
            {
                operateTooltip.text = "Cannot open the door.\nPlease try it again when key found";
                operateTooltip.gameObject.SetActive(true);
                Debug.Log("lock");
            }
            //operateTooltip.gameObject.SetActive(false);
            StartCoroutine(Wait());

        }


    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(2);
        operateTooltip.gameObject.SetActive(false);
    }
}
