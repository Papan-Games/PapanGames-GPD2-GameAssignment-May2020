using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

/// <summary>
/// A script to play the fade in fade out scene when the player complete the game.
/// And will load to next scene
/// </summary>
public class EndGame : MonoBehaviour
{
    public Animator _anim; //The animator to play fade in fade out

    // Update is called once per frame
    void Update()
    {
        if (MissingItemScript.itemCount == 3)
        {
            _anim.SetTrigger("Start");
            StartCoroutine(loadLevel(6));
        }
    }

    /// <summary>
    /// Go to next scene
    /// </summary>
    /// <param name="levelIndex"></param>
    /// <returns></returns>
    IEnumerator loadLevel(int levelIndex)
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(levelIndex);
    }
}
