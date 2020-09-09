using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HouseOutlineController : MonoBehaviour
{
    //private MeshRenderer _meshRenderer;

    //public float maxOutlineWidth;

    //public Color OutlineColor;

    //// Start is called before the first frame update
    //void Start()
    //{
    //    _meshRenderer = GetComponent<MeshRenderer>();
    //}

    //// Update is called once per frame
    //void Update()
    //{

    //}

    //public void ShowOutline()
    //{
    //    _meshRenderer.material.SetFloat("_Outline", maxOutlineWidth);
    //    _meshRenderer.material.SetColor("_OutlineColor", OutlineColor);
    //}

    //public void HideOutline()
    //{
    //    _meshRenderer.material.SetFloat("_Outline", 0f);
    //}

    private MeshRenderer _renderer;
    public bool showingOutline;
    public float maxOutlineWidth;
    public Color OutlineColor;

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

    
}
