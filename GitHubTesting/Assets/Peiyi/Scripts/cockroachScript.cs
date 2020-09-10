using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


/// <summary>
/// This is a sript for showing the tooltip of the cockroach when point to it
/// The tooltip text will change according to the condition
/// </summary>
public class cockroachScript : MonoBehaviour
{
    public Animator _anim; //Variable to get animator
    bool _isAlive; //Checking whether cockroach is alive

    public GameObject Newspaper; //Newspaper asset 
    bool _gotNewspaper; //Checking whether the player has read the newspaper or not

    public GameObject newspaperPreview; //The inventory newspaper slot, use this to check is player get the newspaper
    bool _usedNewspaper; //Checking whether players have used newspaper to kill cockroach or not

    public TextMeshProUGUI operateTooltip; //Attached to operate tooltip
    public TextMeshProUGUI interactTooltip; //Attached to interactable items' tooltip

    public Animator _anim2; //For newspaper roll use
    public GameObject newspaperRoll;

    //Sound source
    [SerializeField] private AudioSource soundSource;
    [SerializeField] private AudioClip cockroachMove;
    [SerializeField] private AudioClip cockroachDie;
    [SerializeField] private AudioClip newspaperHit;

    // Start is called before the first frame update
    void Start()
    {
        Newspaper = GameObject.Find("Newspaper");
        _isAlive = true;
        _gotNewspaper = false;
        _usedNewspaper = false;


    }

    // Update is called once per frame
    void Update()
    {

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
                ////if ()
                ////{
                //    _anim.SetTrigger("die");
                //    newspaperPreview.SetActive(false);
                //    _isAlive = false;
                //    operateTooltip.text = "Cockroach is killed!\n You can get your key now.";
                //    operateTooltip.gameObject.SetActive(true);
                //    StartCoroutine(Wait());
                //    _usedNewspaper = true;

                //    soundSource.PlayOneShot(cockroachDie);
                ////}
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
        _usedNewspaper = true;
        soundSource.PlayOneShot(cockroachDie);
    }

    /// <summary>
    /// Function that changing the tooltip when cursor point to cockroach
    /// </summary>
    void ShowTooltip()
    {

        if (_gotNewspaper == true && _usedNewspaper == true)
        {
            interactTooltip.text = "The cockrach is die.";
        }

        else if (_gotNewspaper == false && _usedNewspaper == false)
        {
            interactTooltip.text = "Press 'E' to interact.";
        }

        else if (_gotNewspaper == true && _usedNewspaper == false)
        {
            interactTooltip.text = "Press 'E' to use the newspaper to kill the cockroach.";
        }


        interactTooltip.gameObject.SetActive(true);
    }
}
