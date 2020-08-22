using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    [SerializeField] private bool canAim;
    public GameObject charCam;

    public float sensitivity = 1.0f;
    private float horizontalRotate = 5.0f;
    private float verticalRotate = 5.0f;

    private float maxVert = 85.0f;
    private float minVert = -85.0f;
    private float Xaxis = 0;


    public enum RotationAxes
    {
        MouseXandY = 0,
        MouseX = 1,
        MouseY = 2
    }

    public RotationAxes axes = RotationAxes.MouseXandY;     // Defaulted to Both Axes

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

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        canAim = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.P))
        {
            ShowCursor();
        }

        if (canAim == true)
        {
            Aiming();
        }
    }

    void ShowCursor()
    {
        if (canAim == true)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            canAim = false;
            Time.timeScale = 0;
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            canAim = true;
            Time.timeScale = 1;
        }
    }

    void Aiming()
    {
        if (axes == RotationAxes.MouseX)
        {
            this.gameObject.transform.Rotate(0, Input.GetAxis("Mouse X") * sensitivity * horizontalRotate, 0);
        }
        else if (axes == RotationAxes.MouseY)
        {
            Xaxis -= Input.GetAxis("Mouse Y") * sensitivity * verticalRotate;
            Xaxis = Mathf.Clamp(Xaxis, minVert, maxVert);

            float Yaxis = charCam.transform.localEulerAngles.y;
            charCam.transform.localEulerAngles = new Vector3(Xaxis, Yaxis, 0);
        }
        else
        {
            Xaxis -= Input.GetAxis("Mouse Y") * sensitivity * verticalRotate;
            Xaxis = Mathf.Clamp(Xaxis, minVert, maxVert);

            float delta = Input.GetAxis("Mouse X") * sensitivity * horizontalRotate;
            float Yaxis = transform.localEulerAngles.y + delta;
            transform.localEulerAngles = new Vector3(0, Yaxis, 0);
            charCam.transform.localEulerAngles = new Vector3(Xaxis, 0, 0);
        }
    }

    private void DialogueStarted()
    {
        canAim = false;
    }

    private void DialogueEnded()
    {
        canAim = true;
    }
}

