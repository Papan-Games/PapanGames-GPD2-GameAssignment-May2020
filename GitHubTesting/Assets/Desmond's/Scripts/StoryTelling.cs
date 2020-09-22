using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryTelling : MonoBehaviour
{
    // Start is called before the first frame update

    bool shown;
    public string story;
    [SerializeField] float waitTime;
    public ForcePanelText scriptRef;

    void Start()
    {
        shown = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            StartCoroutine(scriptRef.TypeText(story, waitTime));
        }
    }
}
