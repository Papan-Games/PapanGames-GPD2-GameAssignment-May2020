using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEditor;

public class DrawerOpen : MonoBehaviour
{
    public Animator _anim;
    //public string OpenText = "Press '1' to open/close Drawer 1\n'2' to open/close Drawer 2\n'3' to open/close Drawer 3";
    //public string CloseText = "Press '1' to open/close Drawer 1\n'2' to open/close Drawer 2\n'3' to open/close Drawer 3";
    private bool _isOpen = false;
    bool firstTime;
    GameObject drawer_3;
    public TextMeshProUGUI tooltip;

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
        tooltip.gameObject.SetActive(true);
        _isOpen = !_isOpen;
        _anim.SetBool("DrawerOpen", _isOpen);

        if (this.gameObject == drawer_3)
        {
            if (firstTime)
            {
                tooltip.text = "Key Found! But there is a cockroach on it.\nI should use somrthing to kill it.";
                tooltip.gameObject.SetActive(true);
                firstTime = false;
                StartCoroutine(Wait());
            }

            else
            {
                tooltip.gameObject.SetActive(false);

            }

        }

    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(2);
        tooltip.gameObject.SetActive(false);
    }
}
