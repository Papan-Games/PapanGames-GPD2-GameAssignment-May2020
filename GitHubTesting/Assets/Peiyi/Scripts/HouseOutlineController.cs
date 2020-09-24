using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/// <summary>
/// A script that attached to the item that can be highighted if player point to it
/// </summary>
public class HouseOutlineController : MonoBehaviour
{
    private MeshRenderer _renderer;
    public bool showingOutline;
    public float maxOutlineWidth;
    public Color OutlineColor;

    public Color ObjectMainColor;
    public Color ObjectOutlineColor;
    bool showedItem;

    // Start is called before the first frame update
    void Start()
    {
        showingOutline = false;
        _renderer = gameObject.GetComponent<MeshRenderer>();
    }

    /// <summary>
    /// A function to show the outline color if pointed to the item that can interact
    /// </summary>
    public void ShowOutline()
    {
        showingOutline = true;
        foreach (var mat in _renderer.materials)
        {
            mat.SetFloat("_Outline", maxOutlineWidth);
            mat.SetColor("_OutlineColor", OutlineColor);
        }
    }

    //public void HideOutline()
    //{
    //    showingOutline = false;
    //    foreach (var mat in _renderer.materials)
    //    {
    //        mat.SetFloat("_Outline", 0f);
    //        mat.SetColor("_OutlineColor", Color.black);
    //    }
    //}

    /// <summary>
    /// Use to hide the oobject or hide the outline
    /// If the pointed item is missing item,
    /// hide the object with outline alpha = 0,
    /// to avoid the outline still visible.
    /// </summary>
    public void HideObject()
    {
        showingOutline = false;
        foreach (var mat in _renderer.materials)
        {
            mat.SetFloat("_Outline", 0f);
            mat.SetColor("_OutlineColor", ObjectOutlineColor);
            if (this.gameObject.tag == "missiingItems")
            {
                ObjectOutlineColor.a = 0;
            }
            else
            {
                ObjectOutlineColor.a = 1;
            }
        }
    }
    
    /// <summary>
    /// This function only worked in Level 5
    /// Use to show the missing item from transparent
    /// </summary>
    public void ShowObject()
    {
        foreach (var mat in _renderer.materials)
        {
            mat.SetColor("_OutlineColor", ObjectOutlineColor);
            mat.SetColor("_Color", ObjectMainColor);
            ObjectMainColor.a = 1;
            ObjectOutlineColor.a = 1;
        }
    }
}
