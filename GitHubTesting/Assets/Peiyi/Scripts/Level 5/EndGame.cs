using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class EndGame : MonoBehaviour
{
    public Animator _anim;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (MissingItemScript.itemCount == 3)
        {
            _anim.SetTrigger("Start");
            StartCoroutine(loadLevel(6));
        }
    }

    IEnumerator loadLevel(int levelIndex)
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(levelIndex);
    }
}
