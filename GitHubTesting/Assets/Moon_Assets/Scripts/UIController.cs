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

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        // Initialize collected soul
        soulCollected = 0;
        soulText.SetText(soulCollected.ToString());

        // Initialize player hurt intensity
        playerHurtIntensity = 0;
        DisplayBlood(playerHurtIntensity);

        blackoutAnim = blackout.GetComponent<Animator>();
        blackoutAnim.SetBool("isDead", false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            PlayerHurt();
        }
    }

    /// <summary>
    /// Increase collected soul value upon game event of colliding with soul trigger box
    /// Broadcast soul collection completion when at 5 souls
    /// </summary>
    private void AddSoulPoint()
    {
        soulCollected++;
        soulText.SetText(soulCollected.ToString());

        if (soulCollected >= 5)
        {
            Messenger.Broadcast(GameEvent.SOUL_COLLECTED_ALL);
        }
    }

    /// <summary>
    /// Increase player hurt intensity upon receiving game event of taking damage from crawler
    /// Player player hurt audio
    /// Update blood splatter UI
    /// </summary>
    private void PlayerHurt()
    {
        audioSource.PlayOneShot(playerHurt);
        playerHurtIntensity++;
        DisplayBlood(playerHurtIntensity);
        Debug.Log(playerHurtIntensity);
    }

    /// <summary>
    /// Changes blood splatter UI depending on player hurt intensity
    /// </summary>
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
            // Player dies after hurt intensity is more than 3, initiate revival function
            StartCoroutine(RevivePlayer());
        }
    }

    /// <summary>
    /// Play blackout animation
    /// Broadcast game event PLAYER_DEAD after 1 second to disable player movement
    /// Reset player hurt intensity and blood splatter, then play blackout animation backwards
    /// Broadcast game event PLAYER_REVIVED to enable back player movement
    /// </summary>
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
