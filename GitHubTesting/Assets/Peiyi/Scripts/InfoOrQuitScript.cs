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
        if (Input.GetKeyDown(KeyCode.Escape))
        {

            Application.Quit();

        }
    }

    private void OnGUI()
    {
        //Draw a box to tell players press esc to exit
        GUILayout.BeginArea(new Rect(25, 25, 250, 250));
        GUILayout.Box("Press 'Esc' key to exit\nPress 'WSAD' keys/'Arrow' keys to move\nMove mouse to look around");
        GUILayout.EndArea();
    }
}
