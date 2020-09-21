using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnSouls : MonoBehaviour
{
    [SerializeField] bool SpaceStationScene;
    [SerializeField] bool Level4Scene;

    public Light ContainerLight;
    public GameObject Soul1;
    public GameObject Soul2;

    public KeyPrompt promptScript;

    public Collider TriggerArea;

    public string curiousText;
    public string returnText;
    public ForcePanelText TextGUIScript;
    public float waitTime;
    public float waitTime2;
    private int beforeIntensity = 2;
    private int afterIntensity = 5;

    // Start is called before the first frame update
    void Start()
    {
        Soul1.SetActive(false);
        Soul2.SetActive(false);
        if(SceneManager.GetActiveScene().name == "SpaceStation")
        {
            SpaceStationScene = true;
            Level4Scene = false;
        }
        else
        {
            Level4Scene = true;
            SpaceStationScene = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other) 
    {
        if(other.CompareTag("Player"))
        {
            // Prompt "E" button UI prompt
            promptScript.ShowPrompt = true;
            if(Input.GetKey(KeyCode.E))
            {
                if(SpaceStationScene)
                {
                    // Show UI for store soul hint
                    StartCoroutine(TextGUIScript.TypeText(curiousText, waitTime));
                }
                else
                {
                    // Store Souls
                    Soul1.SetActive(true);
                    Soul2.SetActive(true);
                    ContainerLight.intensity = afterIntensity;
                    TriggerArea.enabled = false;
                    promptScript.ShowPrompt = false;
                    StartCoroutine(TextGUIScript.TypeText(returnText, waitTime2));
                }
            }
        }
    }

    private void OnTriggerExit(Collider other) 
    {
        promptScript.ShowPrompt = false;
    }

    

}
