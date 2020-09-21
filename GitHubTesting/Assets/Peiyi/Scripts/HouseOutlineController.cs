using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

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

    public void ShowOutline()
    {
        showingOutline = true;
        foreach (var mat in _renderer.materials)
        {
            mat.SetFloat("_Outline", maxOutlineWidth);
            mat.SetColor("_OutlineColor", OutlineColor);
        }
    }

    public void HideOutline()
    {
        showingOutline = false;
        foreach (var mat in _renderer.materials)
        {
            mat.SetFloat("_Outline", 0f);
            mat.SetColor("_OutlineColor", Color.black);
        }
    }

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
    
    public void ShowObject()
    {
        foreach (var mat in _renderer.materials)
        {
            //mat.SetFloat("_MainColor", 255f);
            mat.SetColor("_OutlineColor", ObjectOutlineColor);
            mat.SetColor("_Color", ObjectMainColor);
            ObjectMainColor.a = 1;
            ObjectOutlineColor.a = 1;
        }
    }
}
