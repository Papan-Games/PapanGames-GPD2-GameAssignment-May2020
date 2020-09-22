using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorPoint : MonoBehaviour
{
    private Camera _camera;

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
        if (settingPopup.activeSelf == true || bedQuestion.activeSelf == true)
        {
            Cursor.lockState = CursorLockMode.None; //To lock the cursor in the middle
            Cursor.visible = true; //Unable to see the mouse cursor
        }

        else
        {
            Cursor.lockState = CursorLockMode.Locked; //To lock the cursor in the middle
            Cursor.visible = false; //Unable to see the mouse cursor
        }   
    }
}
