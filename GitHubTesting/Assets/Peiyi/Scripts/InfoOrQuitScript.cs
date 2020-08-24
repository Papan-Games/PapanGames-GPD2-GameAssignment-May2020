using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoOrQuitScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Press Esc button, exit game
        //if (Input.GetKeyDown(KeyCode.Escape))
        //{

        //    Application.Quit();

        //}
    }

    private void OnGUI()
    {
        //Draw a box to tell players press esc to exit
        GUILayout.BeginArea(new Rect(25, 25, 400, 400));
        GUILayout.Box("\nPress 'WSAD' keys/'Arrow' keys to move\nPress 'Spacebar' to jump\nMove mouse to look around\nPress 'E' to interact doors, drawers, switch and so on");
        GUILayout.EndArea();
    }
}
