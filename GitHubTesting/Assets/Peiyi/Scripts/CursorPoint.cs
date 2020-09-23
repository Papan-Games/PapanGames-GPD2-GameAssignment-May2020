using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A script for cheking the cursor locked state in House Environment scenes
/// </summary>
public class CursorPoint : MonoBehaviour
{
    private Camera _camera;

    /// <summary>
    /// The popup panel that need cursor point
    /// </summary>
    public GameObject settingPopup;
    public GameObject bedQuestion;

    // Start is called before the first frame update
    void Start()
    {
        _camera = GetComponent<Camera>();
        Cursor.lockState = CursorLockMode.Locked; //To lock the cursor in the middle
        Cursor.visible = false; //Unable to see the mouse cursor
    }

    // Update is called once per frame
    void Update()
    {
        //If any popup panel with button is active, unable the locked cursor situation,
        //else locked the cursor in the middle
        if (settingPopup.activeSelf == true || bedQuestion.activeSelf == true)
        {
            Cursor.lockState = CursorLockMode.None; //Unabe the locked cursor situation
            Cursor.visible = true; //Show mouse cursor
        }

        else
        {
            if (settingPopup.activeSelf == false || bedQuestion.activeSelf == false)
            {
                Cursor.lockState = CursorLockMode.Locked; //To lock the cursor in the middle
                Cursor.visible = false; //Unable to see the mouse cursor
            }
        }   
    }
}
