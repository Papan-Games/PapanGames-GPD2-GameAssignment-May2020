using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissingItemScript : MonoBehaviour
{
    public GameObject pillows;
    private HouseOutlineController MissingItemController;

    private MeshRenderer _renderer;

    public static int itemCount = 0;

    public AudioSource soundSource;
    public AudioClip putBackSound;

    public GameObject[] missingItems;
    public GameObject[] inventoryItems;

    // Start is called before the first frame update
    void Start()
    {
        MissingItemController = GetComponent<HouseOutlineController>();

        _renderer = gameObject.GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Operate()
    {
        for(int i = 0; i < missingItems.Length; i++)
        {
            if(this.gameObject == missingItems[i])
            {
                inventoryItems[i].SetActive(false);
            }
        }
        MissingItemController.ShowObject();
        this.gameObject.tag = "Untagged";
        if(this.gameObject.name == "LongCouch")
        {
            pillows.SetActive(true);
        }
        _renderer.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.On;
        soundSource.PlayOneShot(putBackSound);
        itemCount++;
        Debug.Log(itemCount);
    }
}
