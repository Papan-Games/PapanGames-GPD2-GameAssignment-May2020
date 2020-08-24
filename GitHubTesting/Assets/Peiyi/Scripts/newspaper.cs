using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class newspaper : MonoBehaviour
{
    public GameObject newspaperPanel;
    public GameObject newspaperAsset;
    bool isReading;

    public bool livingRoomWithLight;
    public GameObject livingRoomSwitchObject;

    // Start is called before the first frame update
    void Start()
    {
        newspaperPanel.gameObject.SetActive(false);
        isReading = false;
        livingRoomWithLight = false;
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
            }
        }
        Vector3 temp = livingRoomSwitchObject.transform.rotation.eulerAngles;
        if(temp.z == 180f)
        {
            livingRoomWithLight = true;
        }
        else if (temp.z == 0f)
        {

            livingRoomWithLight = false;
        }
    }

    void readNewspaper()
    {
        if (livingRoomWithLight == true)
        {
            newspaperPanel.gameObject.SetActive(true);
            Debug.Log("reading");
            isReading = true;
        }
    }
}
