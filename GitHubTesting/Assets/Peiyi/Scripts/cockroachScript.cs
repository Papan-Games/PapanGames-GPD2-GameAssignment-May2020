using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cockroachScript : MonoBehaviour
{
    public Animator _anim;
    // Start is called before the first frame update
    void Start()
    {
        _anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void cockroachDie()
    {
        _anim.SetTrigger("die");
    }

    public void Operate()
    {
        _anim.SetTrigger("move");
    }
}
