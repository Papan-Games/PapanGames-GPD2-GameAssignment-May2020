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
        //_isGotKey = GetComponent<SpecialDoor>();
        key_M_get = false;
        key_S_get = false;
    }
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.E))
        //{
        //Vector3 point = new Vector3(_camera.pixelWidth / 2, _camera.
        //pixelHeight / 2, 0);
        //Ray ray = _camera.ScreenPointToRay(point);
        RaycastHit hit;
        if (Physics.Raycast(_camera.transform.position, _camera.transform.forward, out hit, 3f))
        {

            if (hit.collider.tag == "smallRoomKey" && hit.collider.tag != "cockroach")
            {

                Debug.Log("Press E to collect");
                if (Input.GetKeyDown(KeyCode.E))
                {
                    Debug.Log("Get Small Room key");
                    Destroy(GameObject.Find("SmallRoomKey"));
                    key_S_get = true;
                }
            }

            //else
            //{
            //    Debug.Log("Failed to get key");
            //}

            if (hit.collider.tag == "masterRoomKey")
            {
                Debug.Log("Press E to collect");
                if (Input.GetKeyDown(KeyCode.E))
                {
                    Debug.Log("Get Master Room key");
                    Destroy(GameObject.Find("MasterRoomKey"));
                    key_M_get = true;
                }
            }

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

            //if (hit.collider.tag == "cockroachKiller")
            //{
            //    Debug.Log("Press E to collect");
            //    if (Input.GetKeyDown(KeyCode.E))
            //    {
            //        Debug.Log("Get cockroach killer");
            //        Destroy(GameObject.Find("CockroachKiller"));
            //    }
            //}


            //Debug.Log("halo");
        }

        if (Physics.Raycast(_camera.transform.position, _camera.transform.forward, out hit, 8f))
        {
            if (hit.collider.tag == "cockroachKiller")
            {
                Debug.Log("Press E to collect");
                if (Input.GetKeyDown(KeyCode.E))
                {
                    Debug.Log("Get cockroach killer");
                    Destroy(GameObject.Find("CockroachKiller"));
                }
            }


            //Debug.Log("halo");
        }
        //}
        Debug.DrawLine(_camera.transform.position, _camera.transform.forward * 3f);

        //RaycastHit hit;
        //if (Physics.Raycast(_camera.transform.position, _camera.transform.forward, out hit, 10f))
        //{

        //    if (hit.collider.tag == "smallRoomKey")
        //    {
        //        Debug.Log("Press R to get key");
        //        if (Input.GetKeyDown(KeyCode.R))
        //        {
        //            Debug.Log("Get Small Room key");
        //            Destroy(GameObject.Find("SmallRoomKey"));
        //            key_S_get = true;
        //        }
        //    }

        //    else if (hit.collider.tag == "cockroach")
        //    {

        //        Debug.Log("I should kill the cockroach first");
        //        Debug.Log("Failed to get key");
        //    }


        //    //Debug.Log("halo");
        //}

    }


}
