using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReactiveTarget : MonoBehaviour
{
    private GameObject crawler;
    private GameObject soul;
    public int health;
    public float thrust;
    private bool isAlive;

    Animator anim;
    private float followDist = 12;
    private float attackDist = 3;
    private Transform playerPos;
    private float waitTime;
    private float startWaitTime;

    public AudioSource audioSource;
    public AudioClip crawlerHurt;

    void Start()
    {
        // Get player's transform position
        playerPos = GameObject.FindGameObjectWithTag("Player").transform;

        anim = GetComponent<Animator>();
        crawler = gameObject.transform.GetChild(0).gameObject;

        soul = gameObject.transform.GetChild(1).gameObject;
        soul.SetActive(false);

        // Cooldown between each attack
        startWaitTime = 1.5f;
        waitTime = 0;

        // Crawler alive state
        isAlive = true;
    }

    void Update()
    {
        if (isAlive)
        {
            // Calculate the distance between crawler and player
            float dist = Vector3.Distance(transform.position, playerPos.position);

            Ray ray = new Ray(transform.position, transform.forward);
            RaycastHit hit;

            if (Physics.SphereCast(ray, 5.0f, out hit))
            {
                // Change animator boolean depending on within or outside follow distance
                if (dist <= followDist)
                {
                    anim.SetBool("isFollowing", true);
                }
                else
                {
                    anim.SetBool("isFollowing", false);
                }

                // Trigger animator attack when in attack distance
                if (dist <= attackDist)
                {
                    if (waitTime <= 0)
                    {
                        anim.SetTrigger("isAttacking");

                        Messenger.Broadcast(GameEvent.PLAYER_HURT);
                        waitTime = startWaitTime;
                    }
                    else
                    {
                        waitTime -= Time.deltaTime;
                    }
                }
            }
        }
    }

    /// <summary>
    /// Function to be called when receive gun bullet hit
    /// </summary>
    public void ReactToHit()
    {
        if (health > 1)
        {
            TakeDamage();
        }
        else
        {
            StartCoroutine(Die());
        }
    }

    /// <summary>
    /// Crawler health is minus by 1 each time the function is ran
    /// </summary>
    private void TakeDamage()
    {
        audioSource.PlayOneShot(crawlerHurt);
        health--;
    }

    /// <summary>
    /// Change crawler alive state to false and set animator isDead boolean to true
    /// Disable crawler colliders and enable soul collider
    /// Destroy crawler object after 1 second
    /// </summary>
    IEnumerator Die()
    {
        isAlive = false;
        anim.SetBool("isDead", true);
        foreach(Collider collider in GetComponents<Collider>())
        {
            collider.enabled = false;
        }
        soul.SetActive(true);
        yield return new WaitForSeconds(1f);
        Destroy(crawler);
    }
}
