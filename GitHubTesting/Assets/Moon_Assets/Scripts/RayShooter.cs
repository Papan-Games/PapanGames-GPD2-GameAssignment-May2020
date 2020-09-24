using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class RayShooter : MonoBehaviour
{
    private bool canShoot;

    private Camera mainCamera;

    private AudioSource audioSource;
    public AudioClip shotCrawler;
    public AudioClip bulletThud;

    private void Awake()
    {
        Messenger.AddListener(GameEvent.DIALOGUE_START, DialogueStarted);
        Messenger.AddListener(GameEvent.DIALOGUE_END, DialogueEnded);
        Messenger.AddListener(GameEvent.FINAL_DIALOGUE_START, DialogueStarted);
        Messenger.AddListener(GameEvent.FINAL_DIALOGUE_END, DialogueEnded);
    }

    private void OnDestroy()
    {
        Messenger.RemoveListener(GameEvent.DIALOGUE_START, DialogueStarted);
        Messenger.RemoveListener(GameEvent.DIALOGUE_END, DialogueEnded);
        Messenger.RemoveListener(GameEvent.FINAL_DIALOGUE_START, DialogueStarted);
        Messenger.RemoveListener(GameEvent.FINAL_DIALOGUE_END, DialogueEnded);
    }

    void Start()
    {
        mainCamera = GetComponent<Camera>();
        audioSource = GetComponent<AudioSource>();

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        canShoot = true;
    }

    /// <summary>
    /// Shoot bullet upon left mouse click, play specific FX depending on target hit
    /// Crawler will reach to hit if shot by the bullet
    /// Gun bullet is drawn if hit anything else except the crawler
    /// </summary>
    void Update()
    {
        if (!EventSystem.current.IsPointerOverGameObject())
        {
            if (canShoot && Input.GetMouseButtonDown(0))
            {
                Vector3 point = new Vector3(mainCamera.pixelWidth / 2, mainCamera.pixelHeight / 2, 0);
                Ray ray = mainCamera.ScreenPointToRay(point);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit))
                {
                    GameObject hitObject = hit.transform.gameObject;
                    ReactiveTarget target = hitObject.GetComponent<ReactiveTarget>();
                    if (target != null)
                    {
                        audioSource.PlayOneShot(shotCrawler);
                        target.ReactToHit();
                    }
                    else
                    {
                        audioSource.PlayOneShot(bulletThud);
                        StartCoroutine(GunBullet(hit.point));
                    }
                }
            }
        }
    }

    /// <summary>
    /// Sphere primitive with specific scale and colour is created as the gun bullet on the hit point
    /// Primitive is destroyed after 0.2f seconds
    /// </summary>
    IEnumerator GunBullet(Vector3 pos)
    {
        GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        sphere.transform.position = pos;

        Vector3 scale = new Vector3(0.15f, 0.15f, 0.15f);
        sphere.transform.localScale = scale;

        MeshRenderer renderer = sphere.GetComponent<MeshRenderer>();
        renderer.material.color = Color.yellow;

        yield return new WaitForSeconds(0.2f);
        Destroy(sphere);
    }

    /// <summary>
    /// Disable player's shooting ability
    /// </summary>
    private void DialogueStarted()
    {
        canShoot = false;
    }

    /// <summary>
    /// Enable player's shooting ability
    /// </summary>
    private void DialogueEnded()
    {
        canShoot = true;
    }
}
