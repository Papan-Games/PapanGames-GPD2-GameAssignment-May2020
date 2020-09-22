using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI soulText;
    private int soulCollected;

    [SerializeField] private GameObject blood;
    [SerializeField] private Sprite[] bloodSprite;
    private int playerHurtIntensity;

    [SerializeField] private GameObject blackout;
    private Animator blackoutAnim;

    private AudioSource audioSource;
    public AudioClip playerHurt;

    private void Awake()
    {
        Messenger.AddListener(GameEvent.SOUL_PICKEDUP, AddSoulPoint);
        Messenger.AddListener(GameEvent.PLAYER_HURT, PlayerHurt);
    }

    private void OnDestroy()
    {
        Messenger.RemoveListener(GameEvent.SOUL_PICKEDUP, AddSoulPoint);
        Messenger.RemoveListener(GameEvent.PLAYER_HURT, PlayerHurt);
    }

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        soulCollected = 0;
        soulText.SetText(soulCollected.ToString());

        playerHurtIntensity = 0;
        DisplayBlood(playerHurtIntensity);

        blackoutAnim = blackout.GetComponent<Animator>();
        blackoutAnim.SetBool("isDead", false);
    }

    private void AddSoulPoint()
    {
        soulCollected++;
        soulText.SetText(soulCollected.ToString());

        if (soulCollected >= 5)
        {
            Messenger.Broadcast(GameEvent.SOUL_COLLECTED_ALL);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            PlayerHurt();
        }
    }

    private void PlayerHurt()
    {
        audioSource.PlayOneShot(playerHurt);
        playerHurtIntensity++;
        DisplayBlood(playerHurtIntensity);
        Debug.Log(playerHurtIntensity);
    }

    private void DisplayBlood(int intensity)
    {
        if (intensity <= 3)
        {
            switch (intensity)
            {
                case 0:
                    blood.SetActive(false);
                    break;

                case 1:
                    blood.SetActive(true);
                    blood.GetComponent<Image>().sprite = bloodSprite[intensity - 1];
                    break;

                case 2:
                    blood.SetActive(true);
                    blood.GetComponent<Image>().sprite = bloodSprite[intensity - 1];
                    break;

                case 3:
                    blood.SetActive(true);
                    blood.GetComponent<Image>().sprite = bloodSprite[intensity - 1];
                    break;

                default:
                    break;
            }
        }
        else
        {
            StartCoroutine(RevivePlayer());
        }
    }

    public IEnumerator RevivePlayer()
    {
        blackoutAnim.SetBool("isDead", true);

        yield return new WaitForSeconds(1.0f);
        Messenger.Broadcast(GameEvent.PLAYER_DEAD);

        yield return new WaitForSeconds(1.0f);
        playerHurtIntensity = 0;
        DisplayBlood(playerHurtIntensity);
        blackoutAnim.SetBool("isDead", false);
        Messenger.Broadcast(GameEvent.PLAYER_REVIVED);
    }
}
