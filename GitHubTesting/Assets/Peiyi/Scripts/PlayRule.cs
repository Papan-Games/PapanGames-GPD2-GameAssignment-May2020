using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayRule : MonoBehaviour
{
    //public GameObject panel;
    public TextMeshProUGUI myText;
    public string OpenText;
    public bool isFirst;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            myText.gameObject.SetActive(true);
            myText.text = OpenText;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            myText.gameObject.SetActive(false);
            //Messenger.Broadcast(GameEvent.TOOLTIP_NOT_IN_RANGE);
        }
    }
}
