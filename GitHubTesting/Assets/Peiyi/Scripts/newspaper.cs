using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class newspaper : MonoBehaviour
{
    public GameObject newspaperPanel;
    public GameObject newspaperAsset;

    // Start is called before the first frame update
    void Start()
    {
        newspaperPanel.gameObject.SetActive(false);    
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void readNewspaper()
    {
        newspaperPanel.gameObject.SetActive(true);
        newspaperAsset.gameObject.SetActive(false);
        Debug.Log("reading");
    }

    void closePanel()
    {
    }
}
