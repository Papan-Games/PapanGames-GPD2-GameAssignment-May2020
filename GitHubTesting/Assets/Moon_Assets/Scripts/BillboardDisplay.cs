using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Make the world space UI to constantly face towards the camera no matter when viewed from which angle
/// </summary>
public class BillboardDisplay : MonoBehaviour
{
    public Camera mainCamera;
    void Update()
    {
        transform.LookAt(transform.position + mainCamera.transform.rotation * -Vector3.back,
            mainCamera.transform.rotation * -Vector3.down);
    }
}
