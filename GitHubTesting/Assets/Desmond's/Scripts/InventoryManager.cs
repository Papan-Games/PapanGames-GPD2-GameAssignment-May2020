using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager instance {get; private set;}

    // Items in ItemList need to be in sequence as the arrangement they are used in is also the ItemID
    public bool flashlight; // ID 0
    public bool gun; // ID 1
    public bool keycard; // ID 2
    public bool item3;
    public bool item4;
    public int soulsAmt;

    // Use simple boolean checks for simple items without the need to equip
    public bool simpleItem;
    public bool HouseItem;
    // array size subject to change

    [SerializeField] public List<GameObject> itemList = new List<GameObject>();
    [SerializeField] public List<Image> imageList = new List<Image>();
    [SerializeField] public List<GameObject> PlayerInventoryList = new List<GameObject>();

    public GameObject PlayersFlashlight;
    public GameObject PlayersGun;

    // Itembar UI elements
    public ItemBar barScriptRef;

    private void Awake() 
    {
        // Delete DeleteAll() when testing between scenes
        PlayerPrefs.DeleteAll();

        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (instance != null || instance != this)
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        if(PlayerPrefs.HasKey("Flashlight"))
        {
            flashlight = true;
            PlayersFlashlight.SetActive(true);
        }
        else 
        {
            flashlight = false;
            PlayersFlashlight.SetActive(false);
        }

        if(PlayerPrefs.HasKey("Gun"))
        {
            gun = true;
            PlayersGun.SetActive(true);
        }
        else 
        {
            gun = false;
            PlayersGun.SetActive(false);
        }

        if(PlayerPrefs.HasKey("Keycard"))
        {
            keycard = true;
        }
        else
        {
            keycard = false;
        }

        if(PlayerPrefs.HasKey("item3"))
        {
            item3 = true;
        }
        else
        {
            item3 = false;
        }

        if(PlayerPrefs.HasKey("item4"))
        {
            item4 = true;
        }
        else
        {
            item4 = false;
        }

        soulsAmt = PlayerPrefs.GetInt("soulsAmt", 0);

    }

    public void GetFlashlight()
    {
        if (!flashlight)
        {
            flashlight = true;
            PlayerPrefs.SetString("Flashlight", "True");
            PlayersFlashlight.SetActive(true);
            PlayerInventoryList.Add(itemList[0]);   // Add Flashlight Gameobject to Inventory List following index
            barScriptRef.AddItemToBar(imageList[0]);
        }
    }

    public void GetGun()
    {
        if (!gun)
        {
            gun = true;
            PlayerPrefs.SetString("Gun", "True");
            PlayersGun.SetActive(true);
            PlayerInventoryList.Add(itemList[1]);   // Add Gun Gameobject to Inventory List
            barScriptRef.AddItemToBar(imageList[1]);
        }
    }

    public void GetKeycard()
    {
        if (!keycard)
        {
            keycard = true;
            PlayerPrefs.SetString("Keycard", "True");
            PlayerInventoryList.Add(itemList[2]);   // Add Gun Gameobject to Inventory List
            barScriptRef.AddItemToBar(imageList[2]);
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
