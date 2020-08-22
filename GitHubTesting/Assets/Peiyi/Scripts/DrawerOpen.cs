using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawerOpen : MonoBehaviour
{
    public GameObject panel = null;
    //private bool _isInsideTrigger = false;
    public Animator _anim;
    public string OpenText = "Press '1' to open/close Drawer 1\n'2' to open/close Drawer 2\n'3' to open/close Drawer 3";
    public string CloseText = "Press '1' to open/close Drawer 1\n'2' to open/close Drawer 2\n'3' to open/close Drawer 3";
    //private bool _isOpen_1st = false;
    //private bool _isOpen_2nd = false;
    //private bool _isOpen_3rd = false;
    private bool _isOpen = false;


    ///// <summary>
    ///// If inside drawer trigger volume
    ///// show tool tip panel
    ///// </summary>
    ///// <param name="other"></param>
    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.tag == "Player")
    //    {
    //        _isInsideTrigger = true;
    //        panel.SetActive(true);
    //    }
    //}

    ///// <summary>
    ///// If outside drawer trigger volume
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
    /// if inside trigger volume
    /// press key '1'/ '2' / '3' 
    /// to open or close the drawer 1/2/3
    /// 
    /// The others drawer able to open only if the current drawer is closed
    /// </summary>
    private void Update()
    {
        //if (_isInsideTrigger == true)
        //{
        //    if (Input.GetKeyDown(KeyCode.Alpha1))
        //    {
        //        _isOpen_1st = !_isOpen_1st;
        //        _anim.SetBool("firstDrawerOpen", _isOpen_1st);
        //    }

        //    else if (Input.GetKeyDown(KeyCode.Alpha2))
        //    {
        //        _isOpen_2nd = !_isOpen_2nd;
        //        _anim.SetBool("secondDrawerOpen", _isOpen_2nd);
        //    }

        //    else if (Input.GetKeyDown(KeyCode.Alpha3))
        //    {
        //        _isOpen_3rd = !_isOpen_3rd;
        //        _anim.SetBool("thirdDrawerOpen", _isOpen_3rd);
        //    }

            
        //}
    }


    /// <summary>
    /// This is a function to play the Drawer open/close Animations
    /// </summary>
    public void interact()
    {
        _isOpen = !_isOpen;
        _anim.SetBool("DrawerOpen", _isOpen);

    }
}
