using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReactiveTarget : MonoBehaviour
{
    private GameObject crawler;
    private GameObject soul;
    public int health;
    public float thrust;

    Animator anim;
    private float followDist = 12;
    private float attackDist = 3;
    private Transform playerPos;

    void Start()
    {
        playerPos = GameObject.FindGameObjectWithTag("Player").transform;
        anim = GetComponent<Animator>();
        crawler = gameObject.transform.GetChild(0).gameObject;
        soul = gameObject.transform.GetChild(1).gameObject;
        soul.SetActive(false);
    }

    void Update()
    {
        float dist = Vector3.Distance(transform.position, playerPos.position);
        Debug.Log(dist);

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
                anim.SetTrigger("isAttacking");
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
        this.transform.Translate(0, thrust, 0, Space.Self);
        health--;
    }

    IEnumerator Die()
    {
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
