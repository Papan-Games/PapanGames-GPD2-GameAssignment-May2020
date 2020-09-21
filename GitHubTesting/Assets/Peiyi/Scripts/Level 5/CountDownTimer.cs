using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CountDownTimer : MonoBehaviour
{
    public GameObject StartingDialogue;
    float currentTime = 0f;
    float startingTime = 120f;

    public TextMeshProUGUI countdownText;

    // Start is called before the first frame update
    void Start()
    {
        currentTime = startingTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (StartingDialogue.activeSelf == false)
        {
            countdownText.gameObject.SetActive(true);
            currentTime -= 1 * Time.deltaTime;
            countdownText.text = currentTime.ToString("0");

            if (currentTime > 3)
            {
                countdownText.color = Color.white;
            }
            else if (currentTime <= 3)
            {
                countdownText.color = Color.red;
            }


            if (currentTime <= 0)
            {
                currentTime = 0;
            }
        }
    }
}
