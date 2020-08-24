using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class Pickup : MonoBehaviour
{
    private Camera _camera;

    public bool key_M_get; //Get master room key
    public bool key_S_get; // Get small room key


    void Start()
    {
        _camera = GetComponent<Camera>();
        key_M_get = false;
        key_S_get = false;
    }

    /// <summary>
    /// When mouse cursor point to the picked up items,
    /// show tooltip.
    /// If key 'E' is pressed,
    /// collect the items
    /// </summary>
    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(_camera.transform.position, _camera.transform.forward, out hit, 5f))
        {

            if (hit.collider.tag == "smallRoomKey")
            {
                
                if (Input.GetKeyDown(KeyCode.E))
                {
                    Destroy(GameObject.Find("SmallRoomKey"));
                    key_S_get = true;

                }
            }

            if (hit.collider.tag == "newspaper")
            {
                if (Input.GetKeyUp(KeyCode.E))
                {
                    if (GameObject.FindGameObjectWithTag("newspaper").activeSelf == true)
                    {
                        hit.collider.SendMessage("readNewspaper",
                        SendMessageOptions.DontRequireReceiver);
                    }
                }
            }
        }

    }


}
