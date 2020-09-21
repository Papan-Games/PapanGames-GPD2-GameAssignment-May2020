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

    void Start()
    {
        playerPos = GameObject.FindGameObjectWithTag("Player").transform;
        anim = GetComponent<Animator>();
        crawler = gameObject.transform.GetChild(0).gameObject;

        soul = gameObject.transform.GetChild(1).gameObject;
        soul.SetActive(false);

        startWaitTime = 1.5f;
        waitTime = 0;

        isAlive = true;
    }

    void Update()
    {
        if (isAlive)
        {
            float dist = Vector3.Distance(transform.position, playerPos.position);

            Ray ray = new Ray(transform.position, transform.forward);
            RaycastHit hit;

            if (Physics.SphereCast(ray, 5.0f, out hit))
            {
                if (dist <= followDist)
                {
                    anim.SetBool("isFollowing", true);
                }
                else
                {
                    anim.SetBool("isFollowing", false);
                }

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

    private void TakeDamage()
    {
        //play FX
        health--;
    }

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
