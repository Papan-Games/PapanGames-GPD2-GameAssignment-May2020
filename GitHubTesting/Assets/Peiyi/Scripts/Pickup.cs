﻿using System.Collections;
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
        if (Physics.Raycast(_camera.transform.position, _camera.transform.forward, out hit, 3f))
        {

            if (hit.collider.tag == "smallRoomKey" && hit.collider.tag != "cockroach")
            {
                //Show tooltip
                Debug.Log("Press E to collect");
                if (Input.GetKeyDown(KeyCode.E))
                {
                    Debug.Log("Get Small Room key");
                    Destroy(GameObject.Find("SmallRoomKey"));
                    key_S_get = true;

                    //show in inventory
                }
            }

            //if (hit.collider.tag == "masterRoomKey")
            //{
            //    Debug.Log("Press E to collect");
            //    if (Input.GetKeyDown(KeyCode.E))
            //    {
            //        Debug.Log("Get Master Room key");
            //        Destroy(GameObject.Find("MasterRoomKey"));
            //        key_M_get = true;

            //        //show in inventory
            //    }
            //}

            if (hit.collider.tag == "newspaper")
            {
                Debug.Log("Press E to collect");
                if (Input.GetKeyUp(KeyCode.E))
                {
                    if (GameObject.FindGameObjectWithTag("newspaper").activeSelf == true)
                    {
                        hit.collider.SendMessage("readNewspaper",
                        SendMessageOptions.DontRequireReceiver);
                        Debug.Log("is reading news");
                    }
                }
            }
        }

        //if (Physics.Raycast(_camera.transform.position, _camera.transform.forward, out hit, 8f))
        //{
        //    if (hit.collider.tag == "cockroachKiller")
        //    {
        //        Debug.Log("Press E to collect");
        //        if (Input.GetKeyDown(KeyCode.E))
        //        {
        //            Debug.Log("Get cockroach killer");
        //            Destroy(GameObject.Find("CockroachKiller"));
        //        }
        //    }
        //}
        
        Debug.DrawLine(_camera.transform.position, _camera.transform.forward * 3f);
    }


}
