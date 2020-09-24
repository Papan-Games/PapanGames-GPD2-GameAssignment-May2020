using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Broadcast SOUL_PICKEDUP game event then destroy object upon trigger collision
/// </summary>
public class Soul : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Messenger.Broadcast(GameEvent.SOUL_PICKEDUP);
        Destroy(gameObject);
    }
}
