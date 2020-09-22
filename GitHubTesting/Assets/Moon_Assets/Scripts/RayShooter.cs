using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    void Update()
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

    private void DialogueStarted()
    {
        canShoot = false;
    }

    private void DialogueEnded()
    {
        canShoot = true;
    }
}
