using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Siren : MonoBehaviour
{
    [SerializeField] private float spinSpeed = 750.0f;

    void FixedUpdate()
    {
        transform.Rotate(0, spinSpeed * Time.fixedDeltaTime, 0, Space.Self);
    }
}
