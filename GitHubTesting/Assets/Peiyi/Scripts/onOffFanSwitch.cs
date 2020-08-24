using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onOffFanSwitch : MonoBehaviour
{
    bool _isOnFan;
    public GameObject Fan;
    public Animator _anim;

    // Start is called before the first frame update
    void Start()
    {
        _isOnFan = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void onOffFan()
    {
        if (!_isOnFan)
        {
            Vector3 temp = this.gameObject.transform.rotation.eulerAngles;
            temp.z = 180.0f;
            this.gameObject.transform.rotation = Quaternion.Euler(temp);
            _isOnFan = true;

            //On fan here
            _anim.SetBool("onFan", _isOnFan);
        }

        else if (_isOnFan)
        {
            Vector3 temp = this.gameObject.transform.rotation.eulerAngles;
            temp.z = 0f;
            this.gameObject.transform.rotation = Quaternion.Euler(temp);
            _isOnFan = false;

            //Off fan here
            _anim.SetBool("onFan", _isOnFan);
        }
    }
}
