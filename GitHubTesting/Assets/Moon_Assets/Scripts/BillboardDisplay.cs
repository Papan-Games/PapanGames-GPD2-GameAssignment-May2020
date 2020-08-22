using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BillboardDisplay : MonoBehaviour
{
    public Camera mainCamera;

    void Update()
    {
        transform.LookAt(transform.position + mainCamera.transform.rotation * -Vector3.back,
            mainCamera.transform.rotation * -Vector3.down);
    }
}
