using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cockroachScript : MonoBehaviour
{
    public Animator _anim;
    [SerializeField] bool _isAlive;

    [SerializeField]GameObject Newspaper;
    [SerializeField] bool _gotNewspaper;
    // Start is called before the first frame update
    void Start()
    {
        _anim = GetComponent<Animator>();
        Newspaper = GameObject.Find("Newspaper");
        _isAlive = true;
        _gotNewspaper = false;
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
                Debug.Log("Moving");
            }

            else if(_gotNewspaper == true)
            {
                Destroy(this.gameObject);
                Debug.Log("die");
                _isAlive = false;
            }
            Debug.Log("haha");
        }
    }
}
