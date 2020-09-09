using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class cockroachToolTip : MonoBehaviour
{
    public GameObject newspaper;
    bool _gotNewspaper;

    public GameObject newspaperPreview;
    bool _usedNewspaper;

    public TextMeshProUGUI interactTooltip;
    public string OpenText;

    // Start is called before the first frame update
    void Start()
    {

        //newspaper = GameObject.Find("SmallRoomKey");
        _gotNewspaper = false;

        //newspaperPreview = GameObject.Find("newspaperPreview");
        _usedNewspaper = false;

        interactTooltip.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (newspaper == null)
        {
            _gotNewspaper = true;
        }

        if (newspaperPreview == null)
        {
            _usedNewspaper = true;
        }
    }

    void ShowTooltip()
    {
        if (_gotNewspaper == true && _usedNewspaper == true)
        {
            interactTooltip.text = "The cockrach is die.\nPress 'E' to pick up your key." + OpenText;
        }

        else if (_gotNewspaper == false && _usedNewspaper == false)
        {
            interactTooltip.text = "Press 'E' to interact" + OpenText;
        }

        else if (_gotNewspaper == true && _usedNewspaper == false)
        {
            interactTooltip.text = "Press 'E' to use the newspaper to kill the cockroach" + OpenText;
        }


        interactTooltip.gameObject.SetActive(true);
    }

    void HideTooltip()
    {
        interactTooltip.gameObject.SetActive(false);
    }
}
