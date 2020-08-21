using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class DoorOpen : MonoBehaviour
{
    public GameObject panel = null;
    private bool _isInsideTrigger = false;
    public Animator _anim;
    public string OpenText = "Press 'E' to open it";
    public string CloseText = "Press 'E' to close it";
    private bool _isOpen = false;


    //private Animator anim;
    //private bool doorOpen;

    //private void Start()
    //{
    //    doorOpen = false;
    //    anim = GetComponent<Animator>();
    //}

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.gameObject.CompareTag("Player"))
    //    {
    //        doorOpen = true;
    //        Doors("open");
    //    }
    //}

    //private void OnTriggerExit(Collider other)
    //{
    //    if(doorOpen)
    //    {
    //        doorOpen = false;
    //        Doors("close");
    //    }
    //}

    //void Doors (string direction)
    //{
    //    anim.SetTrigger(direction); 
    //}

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            _isInsideTrigger = true;
            panel.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            _isInsideTrigger = false;
            panel.SetActive(false);
        }
    }

    private bool IsOpenDoorActive
    {
        get
        {
            return panel.activeInHierarchy;
        }
    }

    private void Update()
    {
        if (_isInsideTrigger == true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                _isOpen = !_isOpen;
                _anim.SetBool("open", _isOpen);
            }
        }
    }
}
