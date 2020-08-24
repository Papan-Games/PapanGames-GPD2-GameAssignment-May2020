using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class DoorOpen : MonoBehaviour
{
    public GameObject panel = null;
    //private bool _isInsideTrigger = false;
    public Animator _anim;
    public string OpenText = "Press 'E' to open it";
    public string CloseText = "Press 'E' to close it";
    private bool _isOpen = false;

   
    /// <summary>
    /// This is a function that play the door close/open animation
    /// </summary>
    public void Operate()
    {
        _isOpen = !_isOpen;
        _anim.SetBool("open", _isOpen);

        Debug.Log("door open");
    }
}
