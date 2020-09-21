using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public GameObject Newspaper;
    public GameObject Key_SmallR;

    public Image newspaperPreview;
    public Image keyPreview;

    // Start is called before the first frame update
    void Start()
    {

        keyPreview.gameObject.SetActive(false);
        newspaperPreview.gameObject.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        if (Key_SmallR.activeSelf == false)
        {
            keyPreview.gameObject.SetActive(true);
        }


        if (Newspaper.activeSelf == false)
        {
            newspaperPreview.gameObject.SetActive(true);
        }

        
    }
}
