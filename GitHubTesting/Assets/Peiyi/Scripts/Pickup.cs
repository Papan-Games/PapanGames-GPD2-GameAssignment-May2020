using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    private Camera _camera;

    //public bool key_M_get; //Get master room key
    public bool key_S_get; // Get small room key


    void Start()
    {
        _camera = GetComponent<Camera>();
        //_isGotKey = GetComponent<SpecialDoor>();
        //key_M_get = false;
        key_S_get = false;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            //Vector3 point = new Vector3(_camera.pixelWidth / 2, _camera.
            //pixelHeight / 2, 0);
            //Ray ray = _camera.ScreenPointToRay(point);
            RaycastHit hit;
            if (Physics.Raycast(_camera.transform.position, _camera.transform.forward, out hit, 10f))
            {
               
                if (hit.collider.tag == "smallRoomKey");
                {
                    Debug.Log("Get Small Room key");
                    Destroy(GameObject.Find("SmallRoomKey"));
                    key_S_get = true;
                }

                //Debug.Log("halo");
            }
        }
    }


}
