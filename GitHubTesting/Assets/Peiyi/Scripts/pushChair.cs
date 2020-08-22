using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class pushChair : MonoBehaviour
{
    public GameObject panel = null;
    private bool _isInsideTrigger = false;
    public Animator _anim;
    public string OpenText = "Press 'Mouse Left Button' to push the chair inside\n'Mouse Right Button' to push the chair outside";
    public string CloseText = "Press 'Mouse Left Button' to push back the chair inside\n'Mouse Right Button' to push back the chair outside";
    private bool isPushInside = false;
    private bool isPushOutside = false;

    /// <summary>
    /// If inside chair trigger volume
    /// show tool tip panel
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            _isInsideTrigger = true;
            panel.SetActive(true);
        }
    }

    /// <summary>
    /// If outside chair trigger volume
    /// hide tool tip panel
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            _isInsideTrigger = false;
            panel.SetActive(false);
        }
    }

    private bool IsOpenDoorActive
    {
        get
        {
            return panel.activeInHierarchy;
        }
    }

    /// <summary>
    /// if inside trigger volume
    /// press key 'Left Mouse Button'/'Right Mouse Button' to push or push back the chairs
    /// 
    /// Players can only push 1 chair
    /// </summary>
    private void Update()
    {
        if (_isInsideTrigger == true)
        {
            if (Input.GetMouseButtonDown(0))
            {
                isPushInside = !isPushInside;
                _anim.SetBool("isPushInside", isPushInside);
            }

            else if (Input.GetMouseButtonDown(1))
            {
                isPushOutside = !isPushOutside;
                _anim.SetBool("isPushOutside", isPushOutside);
            }
        }
    }

}
