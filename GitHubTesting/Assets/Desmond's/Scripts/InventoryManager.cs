using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager instance {get; private set;}

    public bool flashlight; 
    public bool gun; 
    public bool keycard; 
    public bool TV;
    public bool Chair;
    public bool washingMachine;
    public int soulsAmt;

    public AudioSource itemPickup;
    public AudioClip pickupSFX;


    public GameObject ChairPreview;
    public GameObject CouchPreview;
    public GameObject WashingMachinePreview;

    public GameObject PlayersFlashlight;
    public GameObject PlayersGun;


    private void Awake() 
    {
        if (instance == null)
        {
            instance = this;
            //DontDestroyOnLoad(gameObject);
        }
        else if (instance != null || instance != this)
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        flashlight = false;
        gun = false;
        TV = false;
        keycard = false;
        Chair = false;
        washingMachine = false;
        PlayersFlashlight.SetActive(false);
        PlayersGun.SetActive(false);
       
    }

    public void GetFlashlight()
    {
        if (!flashlight)
        {
            flashlight = true;
            PlayersFlashlight.SetActive(true);
            itemPickup.PlayOneShot(pickupSFX);
        }
    }

    public void GetGun()
    {
        if (!gun)
        {
            gun = true;
            PlayersGun.SetActive(true);
            itemPickup.PlayOneShot(pickupSFX);
        }
    }

    public void GetKeycard()
    {
        if (!keycard)
        {
            keycard = true;
            itemPickup.PlayOneShot(pickupSFX);
        }
    }

    public void GetTV()
    {
        if(!TV)
        {
            TV = true;
            itemPickup.PlayOneShot(pickupSFX);
            CouchPreview.SetActive(true);
        }
    }
    
    public void GetChair()
    {
        if(!Chair)
        {
            Chair = true;
            itemPickup.PlayOneShot(pickupSFX);
            ChairPreview.SetActive(true);
        }
    }

    public void GetWashingMachine()
    {
        if(!washingMachine)
        {
            washingMachine = true;
            itemPickup.PlayOneShot(pickupSFX);
            WashingMachinePreview.SetActive(true);
        }
    }

    public void AddSouls()
    {
        soulsAmt++;
    }

    public int GetSouls()
    {
        return soulsAmt;
    }

}
