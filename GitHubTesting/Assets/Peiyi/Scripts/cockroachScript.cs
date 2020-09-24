using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


/// <summary>
/// This is a script for cockroach operation
/// if player press on it
/// </summary>
public class cockroachScript : MonoBehaviour
{
    public Animator _anim; //Variable to get animator
    bool _isAlive; //Checking whether cockroach is alive

    public GameObject Newspaper; //Newspaper asset 
    bool _gotNewspaper; //Checking whether the player has read the newspaper or not

    public GameObject newspaperPreview; //The inventory newspaper slot, use this to check is player get the newspaper

    public TextMeshProUGUI operateTooltip; //Attached to operate tooltip

    public Animator _anim2; //For newspaper roll use
    public GameObject newspaperRoll; //Newspaper roll asset

    //Sound source
    public AudioSource soundSource;
    public AudioClip cockroachMove;
    public AudioClip newspaperHit;

    // Start is called before the first frame update
    void Start()
    {
        Newspaper = GameObject.Find("Newspaper");
        _isAlive = true;
        _gotNewspaper = false;
    }

    // Update is called once per frame
    void Update()
    {
        //If newspaper asset is not active, _gotNewspaper = true
        if (Newspaper.activeSelf == false)
        {
            _gotNewspaper = true;
        }
    }

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

                soundSource.PlayOneShot(cockroachMove);
            }

            else if(_gotNewspaper == true)
            {
                newspaperRoll.gameObject.SetActive(true);
                _anim2.SetTrigger("useNewspaper");
                soundSource.PlayOneShot(newspaperHit);
                StartCoroutine(afterNewspaperHit());
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

    IEnumerator afterNewspaperHit()
    {
        yield return new WaitForSeconds(2);
        _anim.SetTrigger("die");
        newspaperPreview.SetActive(false);
        _isAlive = false;
        operateTooltip.text = "Cockroach is killed!\n You can get your key now.";
        operateTooltip.gameObject.SetActive(true);
        StartCoroutine(Wait());
    }
}
