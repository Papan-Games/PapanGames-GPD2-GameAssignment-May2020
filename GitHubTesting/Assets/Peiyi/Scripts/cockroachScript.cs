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

    public TextMeshProUGUI tooltip;

    // Start is called before the first frame update
    void Start()
    {
        _anim = GetComponent<Animator>();
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

    public void cockroachDie()
    {
        if(_gotNewspaper && _isAlive)
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
                _anim.SetTrigger("die");
                this.GetComponent<BoxCollider>().enabled = false;
            }
        }
        
    }

    public void Operate()
    {
        if (_isAlive == true)
        {
            if (_gotNewspaper == false)
            {
                _anim.SetTrigger("move");
                tooltip.text = "There is a cockroach on your key!\nYou should find a way to kill cockroach and get your key.";
                tooltip.gameObject.SetActive(true);
            }

            else if(_gotNewspaper == true)
            {
                Destroy(this.gameObject);
                Destroy(newspaperPreview);
                _isAlive = false;
                tooltip.text = "Cockroach is killed!\n You can get your key now.";
                tooltip.gameObject.SetActive(true);
            }
        }
    }
}
