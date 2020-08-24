using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawerOpen : MonoBehaviour
{
    public Animator _anim;
    //public string OpenText = "Press '1' to open/close Drawer 1\n'2' to open/close Drawer 2\n'3' to open/close Drawer 3";
    //public string CloseText = "Press '1' to open/close Drawer 1\n'2' to open/close Drawer 2\n'3' to open/close Drawer 3";
    private bool _isOpen = false;
    bool firstTime = false;
    GameObject drawer_3;

    void Start()
    {
        _isOpen = false;
        firstTime = true;
        drawer_3 = GameObject.Find("ThirdDrawer");
    }

    /// <summary>
    /// This is a function to play the Drawer open/close Animations
    /// </summary>
    public void interact()
    {
        if (this.gameObject.name == "ThirdDrawer")
        {
            if (firstTime)
            {
                Debug.Log("Key Found!");
                firstTime = false;
            }

        }
        _isOpen = !_isOpen;
        _anim.SetBool("DrawerOpen", _isOpen);

    }
}
