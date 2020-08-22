using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreemanTrigger : MonoBehaviour
{
    public GameObject canvas;
    public bool canTalk;

    void Start()
    {
        canvas.SetActive(false);
        canTalk = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            canvas.SetActive(true);
            canTalk = true;
            Messenger.Broadcast(GameEvent.TREEMAN_IN_RANGE);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            canvas.SetActive(false);
            canTalk = false;
            Messenger.Broadcast(GameEvent.TREEMAN_NOT_IN_RANGE);
        }
    }
}
