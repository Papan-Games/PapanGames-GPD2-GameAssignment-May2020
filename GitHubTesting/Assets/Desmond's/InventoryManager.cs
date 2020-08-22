using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager instance {get; private set;}

    public bool gun;
    public bool keycard;
    public bool item3;
    public bool item4;
    public int soulsAmt;

    public GameObject PlayersGun;

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

    public void GetGun()
    {
        if (!gun)
        {
            gun = true;
            PlayerPrefs.SetString("Gun", "True");
            PlayersGun.SetActive(true);
        }
    }

    public void GetKeycard()
    {
        if (!keycard)
        {
            keycard = true;
            PlayerPrefs.SetString("Keycard", "True");
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
