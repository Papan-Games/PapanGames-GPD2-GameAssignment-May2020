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

    void Start()
    {
        anim = GetComponent<Animator>();
        crawler = gameObject.transform.GetChild(0).gameObject;
        soul = gameObject.transform.GetChild(1).gameObject;
        soul.SetActive(false);
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
