using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI soulText;
    private int soulCollected;

    private void Awake()
    {
        Messenger.AddListener(GameEvent.SOUL_PICKEDUP, AddSoulPoint);
    }

    private void OnDestroy()
    {
        Messenger.RemoveListener(GameEvent.SOUL_PICKEDUP, AddSoulPoint);
    }

    // Start is called before the first frame update
    void Start()
    {
        soulCollected = 0;
        soulText.SetText(soulCollected.ToString());
    }

    private void AddSoulPoint()
    {
        soulCollected++;
        soulText.SetText(soulCollected.ToString());

        if (soulCollected >= 5)
        {
            Messenger.Broadcast(GameEvent.SOUL_COLLECTED_ALL);
        }
    }
}
