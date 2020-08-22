using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MasterRoomDoor : MonoBehaviour
{
    public GameObject panel = null;
    public string OpenText = "Press 'E' to open it";
    public string CloseText = "Press 'E' to close it";

    //private bool _isInsideTrigger = false;
    public Animator _anim;

    private bool _isOpen = false;
    private bool _isLocked = true;

    //[SerializeField] GameObject Key_SmallR;
    public GameObject Key_MasterR;
    //[SerializeField] private bool smallRoom = false;
    [SerializeField] private bool masterRoom = false;

    [SerializeField] bool gotMKey = false; //Got Master Room key
    //[SerializeField] bool gotSKey = false; //Got Small Room Key

    Pickup reference;

    private void Start()
    {
        Key_MasterR = GameObject.Find("MasterRoomKey");
        //Key_MasterR = GameObject.Find("MasterRoomKey");

        reference = GetComponent<Pickup>();

        if (this.gameObject == GameObject.Find("F2_MasterRoom"))
        {
            masterRoom = true;
        }

        //else if(this.gameObject == GameObject.Find("F2_MasterRoom"))
        //{
        //    masterRoom = true;
        //}
    }

    ///// <summary>
    ///// If inside door trigger volume
    ///// show tool tip panel
    ///// </summary>
    ///// <param name="other"></param>
    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.tag == "Player")
    //    {
    //        if (!_isLocked)
    //        {
    //            //pop up normal open door text
    //            _isInsideTrigger = true;
    //            panel.SetActive(true);
    //        }

    //        else if (_isLocked)
    //        {
    //            //remind player to find key
    //            _isInsideTrigger = true;
    //            panel.SetActive(true);
    //        }
    //    }
    //}

    ///// <summary>
    ///// If outside door trigger volume
    ///// hide tool tip panel
    ///// </summary>
    ///// <param name="other"></param>
    //private void OnTriggerExit(Collider other)
    //{
    //    if (other.tag == "Player")
    //    {
    //        _isInsideTrigger = false;
    //        panel.SetActive(false);
    //    }
    //}

    //private bool IsOpenDoorActive
    //{
    //    get
    //    {
    //        return panel.activeInHierarchy;
    //    }
    //}

    /// <summary>
    /// When inside trigger volume,
    /// if the door is locked,
    /// players have to get the key to unlock it
    /// 
    /// if the door is unlocked,
    /// press key 'E' to open or close door
    /// </summary>
    private void Update()
    {
        if (Key_MasterR == null && gotMKey != true)
        {
            gotMKey = true;
        }
        //if (Key_MasterR == null && gotMKey != true)
        //{
        //    gotMKey = true;
        //}

        //if (_isInsideTrigger == true)
        //{
        //    if (Input.GetKeyDown(KeyCode.E))
        //    {

        //        if (_isLocked == false)
        //        {
        //            _isOpen = !_isOpen;
        //            _anim.SetBool("open", _isOpen);
        //            Debug.Log("Open");
        //        }

        //        else if (_isLocked == true)
        //        {
        //            if (masterRoom == true && gotMKey == true)
        //            {
        //                _isOpen = !_isOpen;
        //                _anim.SetBool("open", _isOpen);
        //                Debug.Log("Open with key");
        //                _isLocked = false;
        //            }

        //        }
        //    }
        //}


    }

    public void Operate()
    {


        //if (_isInsideTrigger == true)
        //{
        //if (Input.GetKeyDown(KeyCode.E))
        //{

        if (_isLocked == false)
        {
            _isOpen = !_isOpen;
            _anim.SetBool("open", _isOpen);
            Debug.Log("Open");
        }

        else if (_isLocked == true)
        {
            if (masterRoom == true && gotMKey == true)
            {
                _isOpen = !_isOpen;
                _anim.SetBool("open", _isOpen);
                Debug.Log("Open with key");
                _isLocked = false;
            }
            



        }

        Debug.Log("Hei");
        //}
        //}
    }    
}
