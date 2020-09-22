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

    // [SerializeField] public List<GameObject> itemList = new List<GameObject>();
    // [SerializeField] public List<Image> imageList = new List<Image>();
    // [SerializeField] public List<GameObject> PlayerInventoryList = new List<GameObject>();

    public GameObject PlayersFlashlight;
    public GameObject PlayersGun;

    // Itembar UI elements
    // public ItemBar barScriptRef;

    private void Awake() 
    {
        // Delete DeleteAll() when testing between scenes
        PlayerPrefs.DeleteAll();

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
        // if(PlayerPrefs.HasKey("Flashlight"))
        // {
        //     flashlight = true;
        //     PlayersFlashlight.SetActive(true);
        // }
        // else 
        // {
        //     flashlight = false;
        //     PlayersFlashlight.SetActive(false);
        // }

        // if(PlayerPrefs.HasKey("Gun"))
        // {
        //     gun = true;
        //     PlayersGun.SetActive(true);
        // }
        // else 
        // {
        //     gun = false;
        //     PlayersGun.SetActive(false);
        // }

        // if(PlayerPrefs.HasKey("Keycard"))
        // {
        //     keycard = true;
        // }
        // else
        // {
        //     keycard = false;
        // }

        // if(PlayerPrefs.HasKey("TV"))
        // {
        //     TV = true;
        // }
        // else
        // {
        //     TV = false;
        // }

        // if(PlayerPrefs.HasKey("item4"))
        // {
        //     item4 = true;
        // }
        // else
        // {
        //     item4 = false;
        // }

        // soulsAmt = PlayerPrefs.GetInt("soulsAmt", 0);

    }

    public void GetFlashlight()
    {
        if (!flashlight)
        {
            flashlight = true;
            PlayersFlashlight.SetActive(true);
            itemPickup.PlayOneShot(pickupSFX);
            // PlayerPrefs.SetString("Flashlight", "True");
            // PlayerInventoryList.Add(itemList[0]);   // Add Flashlight Gameobject to Inventory List following index
            // barScriptRef.AddItemToBar(imageList[0]);
        }
    }

    public void GetGun()
    {
        if (!gun)
        {
            gun = true;
            PlayersGun.SetActive(true);
            itemPickup.PlayOneShot(pickupSFX);
            // PlayerPrefs.SetString("Gun", "True");
            // PlayerInventoryList.Add(itemList[1]);   // Add Gun Gameobject to Inventory List
            // barScriptRef.AddItemToBar(imageList[1]);
        }
    }

    public void GetKeycard()
    {
        if (!keycard)
        {
            keycard = true;
            itemPickup.PlayOneShot(pickupSFX);
            // PlayerPrefs.SetString("Keycard", "True");
            // PlayerInventoryList.Add(itemList[2]);   // Add Gun Gameobject to Inventory List
            // barScriptRef.AddItemToBar(imageList[2]);
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
