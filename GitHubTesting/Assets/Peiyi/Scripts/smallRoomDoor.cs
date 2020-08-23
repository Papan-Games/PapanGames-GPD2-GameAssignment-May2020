using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class smallRoomDoor : MonoBehaviour
{
    //public GameObject panel = null;
    //public string OpenText = "Press 'E' to open it";
    //public string CloseText = "Press 'E' to close it";

    public Animator _anim;

    private bool _isOpen = false;
    private bool _isLocked = true;

    [SerializeField] GameObject Key_SmallR;
    [SerializeField] private bool smallRoom = false;

    [SerializeField] bool gotSKey = false; //Got Small Room Key

    Pickup reference;

    /// <summary>
    /// Assigned Key_SmallR object through find the object name in hierachy
    /// 
    /// </summary>
    private void Start()
    {
        Key_SmallR = GameObject.Find("SmallRoomKey");
    }

    //private bool IsOpenDoorActive
    //{
    //    get
    //    {
    //        return panel.activeInHierarchy;
    //    }
    //}

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
                Debug.Log("Open");
            }

            else if (_isLocked == true)
            {
                if (gotSKey == true)
                {
                    _isOpen = !_isOpen;
                    _anim.SetBool("open", _isOpen);
                    Debug.Log("Open with key");
                    _isLocked = false;
                }

            }
            
        
    }
}
