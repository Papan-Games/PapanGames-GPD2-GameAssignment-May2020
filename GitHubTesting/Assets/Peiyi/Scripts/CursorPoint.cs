using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorPoint : MonoBehaviour
{
    private Camera _camera;
    GUIStyle myStyle;

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
        RaycastHit hit;
        Ray ray = new Ray(transform.position, transform.forward);

        if (Physics.Raycast(_camera.transform.position, _camera.transform.forward, out hit, 5f))
        {
            if (hit.collider.tag == "tooltipTrigger")
            {
                myStyle.normal.textColor = Color.Lerp(Color.green, Color.green, Mathf.PingPong(Time.time, 1));
            }

            else
            {
                myStyle.normal.textColor = Color.Lerp(Color.red, Color.black, Mathf.PingPong(Time.time, 1));
            }
            
        }
    }

    private void OnGUI()
    {
        int size = 12;
        float posX = _camera.pixelWidth / 2 - size / 4;
        float posY = _camera.pixelHeight / 2 - size / 2;

        //Parameter to change font size
        GUIStyle myStyle = new GUIStyle();
        myStyle.fontSize = 40; 

        //able to keep changing the cursor point color gradiently between black and red
        myStyle.normal.textColor = Color.Lerp(Color.red, Color.black, Mathf.PingPong(Time.time, 1)); 

        //Assign cursor point as "*" and change the font size here
        GUI.Label(new Rect(posX, posY, size, size), "*", myStyle);
    }
}
