using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A script for missing items used only
/// </summary>
public class MissingItemScript : MonoBehaviour
{
    public GameObject pillows; //For long couch asset use only
    private HouseOutlineController MissingItemController; //For highlight use

    private MeshRenderer _renderer; //Get the renderer of the missing item

    public static int itemCount = 0; //Count the item that already put back

    /// <summary>
    /// AudioSource and AudioClip
    /// </summary>
    public AudioSource soundSource;
    public AudioClip putBackSound;

    /// <summary>
    /// Use these to know which item the player put back
    /// </summary>
    public GameObject[] missingItems; 
    public GameObject[] inventoryItems;

    // Start is called before the first frame update
    void Start()
    {
        MissingItemController = GetComponent<HouseOutlineController>();

        _renderer = gameObject.GetComponent<MeshRenderer>();
    }

    /// <summary>
    /// A function to do the operation for the missing item
    /// If the item is put back, the related inventory will hide.
    /// And change the tag to Untagged to avoid them be highlight again.
    /// </summary>
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
    }
}
