using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class newspaper : MonoBehaviour
{
    public GameObject newspaperPanel;
    public GameObject newspaperAsset;
    bool isReading;

    // Start is called before the first frame update
    void Start()
    {
        newspaperPanel.gameObject.SetActive(false);
        isReading = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isReading)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Destroy(newspaperAsset.gameObject);
                newspaperPanel.gameObject.SetActive(false);
                Debug.Log("123135456");
            }
        }
    }

    void readNewspaper()
    {

        newspaperPanel.gameObject.SetActive(true);
        Debug.Log("reading");
        isReading = true;
    }
}
