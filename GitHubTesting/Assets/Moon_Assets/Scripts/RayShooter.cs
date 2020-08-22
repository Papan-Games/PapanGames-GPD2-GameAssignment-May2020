using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayShooter : MonoBehaviour
{
    private bool canShoot;

    private Camera mainCamera;

    private void Awake()
    {
        Messenger.AddListener(GameEvent.DIALOGUE_START, DialogueStarted);
        Messenger.AddListener(GameEvent.DIALOGUE_END, DialogueEnded);
    }

    private void OnDestroy()
    {
        Messenger.RemoveListener(GameEvent.DIALOGUE_START, DialogueStarted);
        Messenger.RemoveListener(GameEvent.DIALOGUE_END, DialogueEnded);
    }

    void Start()
    {
        mainCamera = GetComponent<Camera>();

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
                StartCoroutine(GunBullet(hit.point));
            }
        }
    }

    IEnumerator GunBullet(Vector3 pos)
    {
        GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        sphere.transform.position = pos;
        yield return new WaitForSeconds(0.3f);
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
