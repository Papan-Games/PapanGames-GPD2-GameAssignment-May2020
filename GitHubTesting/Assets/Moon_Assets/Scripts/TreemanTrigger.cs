using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreemanTrigger : MonoBehaviour
{
    public GameObject canvas;
    public bool canTalk;

    public OutlineTreeman outlineTreeman;

    void Start()
    {
        canvas.SetActive(false);
        canTalk = false;
    }

    /// <summary>
    /// Check when player is in trigger box
    /// Enable world space talk canvas, set true canTalk, show Treeman outline
    /// </summary>
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            canvas.SetActive(true);
            canTalk = true;
            Messenger.Broadcast(GameEvent.TREEMAN_IN_RANGE);
            outlineTreeman.ShowOutline();
        }
    }

    /// <summary>
    /// Check when player is out of the trigger box
    /// Disable world space talk canvas, set false canTalk, hide Treeman outline
    /// </summary>
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            canvas.SetActive(false);
            canTalk = false;
            Messenger.Broadcast(GameEvent.TREEMAN_NOT_IN_RANGE);
            outlineTreeman.HideOutline();
        }
    }
}
