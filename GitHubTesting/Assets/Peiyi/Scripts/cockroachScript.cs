using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class cockroachScript : MonoBehaviour
{
    public Animator _anim;
    [SerializeField] bool _isAlive;

    [SerializeField]GameObject Newspaper;
    public bool _gotNewspaper;

    public GameObject newspaperPreview;
    public bool _usedNewspaper;

    public TextMeshProUGUI operateTooltip;
    //public string tooltipText;
    //public TextMeshProUGUI operateTooltip;

    // Start is called before the first frame update
    void Start()
    {
        //_anim = GetComponent<Animator>();
        Newspaper = GameObject.Find("Newspaper");
        _isAlive = true;
        _gotNewspaper = false;
        _usedNewspaper = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Newspaper == null && _gotNewspaper != true)
        {
            _gotNewspaper = true;
        }
    }

    //public void cockroachDie()
    //{
    //    if(_gotNewspaper && _isAlive)
    //    {
    //        if(Input.GetKeyDown(KeyCode.E))
    //        {
    //            _anim.SetTrigger("die");
    //            this.GetComponent<BoxCollider>().enabled = false;
    //        }
    //    }
        
    //}

    /// <summary>
    /// A function for operate the animation of the cockroach
    /// and the operateTooltip
    /// </summary>
    public void Operate()
    {
        if (_isAlive == true)
        {
            if (_gotNewspaper == false)
            {
                _anim.SetTrigger("move");
                operateTooltip.gameObject.SetActive(true);
                operateTooltip.text = "There is a cockroach on your key!\nYou should find a way to kill cockroach and get your key.";
                StartCoroutine(Wait());
            }

            else if(_gotNewspaper == true)
            {
                //Destroy(this.gameObject);
                _anim.SetTrigger("die");
                this.GetComponent<BoxCollider>().enabled = false;
                newspaperPreview.SetActive(false);
                _isAlive = false;
                operateTooltip.text = "Cockroach is killed!\n You can get your key now.";
                operateTooltip.gameObject.SetActive(true);
                StartCoroutine(Wait());
            }

        }

        else
        {
            operateTooltip.text = "Cockroach is killed!\n Go back your room after collected the key.";
            operateTooltip.gameObject.SetActive(true);
            StartCoroutine(Wait());
        }

    }

    /// <summary>
    /// When the operateTooltip is SetActive(true),
    /// it will become SetActive(false) automatically 
    /// after 2 seconds
    /// </summary>
    /// <returns></returns>
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(2);
        operateTooltip.gameObject.SetActive(false);
    }

    //void ShowTooltip()
    //{
    //    if (_isAlive == true)
    //    {
    //        operateTooltip.text = "Press 'E' to interact.";
    //        operateTooltip.gameObject.SetActive(true);
    //    }
    //}

    //void HideTooltip()
    //{
    //    operateTooltip.gameObject.SetActive(false);
    //}
}
