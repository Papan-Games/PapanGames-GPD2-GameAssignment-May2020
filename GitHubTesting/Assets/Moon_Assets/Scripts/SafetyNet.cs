using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafetyNet : MonoBehaviour
{
    public UIController uIController;

    /// <summary>
    /// Player instant die if fall out of the world
    /// </summary>
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            uIController.StartCoroutine(uIController.RevivePlayer());
        }
    }
}
