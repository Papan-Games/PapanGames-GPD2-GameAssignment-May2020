using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemBar : MonoBehaviour
{
    public static ItemBar instance {get; private set;}

    public GameObject Selected;
    public GameObject Next;
    public GameObject Previous;

    private int currentIndex;
    private int nextIndex;
    private int previousIndex;

    private void Awake() 
    {

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
        currentIndex = 0;
        nextIndex = currentIndex + 1;
        previousIndex = currentIndex - 1;
        Next.SetActive(false);
        Previous.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.mouseScrollDelta.y < 0) // Negative Scroll , Down Scroll
        {
            if(InventoryManager.instance.PlayerInventoryList.Count > 1)
            {
                UpdateIndexes(+1);
                Selected.GetComponentInChildren<Image>().sprite = InventoryManager.instance.imageList[currentIndex].sprite;
                Next.GetComponentInChildren<Image>().sprite = InventoryManager.instance.imageList[nextIndex].sprite;
                Previous.GetComponentInChildren<Image>().sprite = InventoryManager.instance.imageList[previousIndex].sprite;
            }
        }
        if(Input.mouseScrollDelta.y > 0) // Positive Scroll , Up Scroll
        {
            if(InventoryManager.instance.PlayerInventoryList.Count > 1)
            {
                UpdateIndexes(+1);
                Selected.GetComponentInChildren<Image>().sprite = InventoryManager.instance.imageList[currentIndex].sprite;
                Next.GetComponentInChildren<Image>().sprite = InventoryManager.instance.imageList[nextIndex].sprite;
                Previous.GetComponentInChildren<Image>().sprite = InventoryManager.instance.imageList[previousIndex].sprite;
            }
        }


    }

    public void AddItemToBar(Image itemReference)
    {
        if(InventoryManager.instance.PlayerInventoryList.Count == 1)
        {
            Selected.GetComponentInChildren<Image>().sprite = itemReference.sprite;
        }
        else
        {
            if (!Previous.activeSelf && !Next.activeSelf)
            {
                Next.SetActive(true);
                Previous.SetActive(true);
            }
            Previous.GetComponentInChildren<Image>().sprite = Selected.GetComponentInChildren<Image>().sprite;
            Selected.GetComponentInChildren<Image>().sprite = itemReference.sprite;
        }
    }

    private void UpdateIndexes(int num)
    {
        if (num > 0)
        {
            currentIndex++;
            if(currentIndex > InventoryManager.instance.PlayerInventoryList.Count - 1) //inventory Size
            {
                currentIndex = 0;
            }
            nextIndex = currentIndex + 1;
            previousIndex = currentIndex - 1;
            if(nextIndex > InventoryManager.instance.PlayerInventoryList.Count - 1) // inventory Size
            {
                nextIndex = 0;
            }
            if(previousIndex < 0) // minimum
            {
                previousIndex = InventoryManager.instance.PlayerInventoryList.Count - 1; 
            }
        }
        else
        {
            currentIndex--;
            if(currentIndex < 0)
            {
                currentIndex = InventoryManager.instance.PlayerInventoryList.Count - 1;
            }
            nextIndex = currentIndex + 1;
            previousIndex = currentIndex - 1;
            if(nextIndex > InventoryManager.instance.PlayerInventoryList.Count - 1) // inventory Size
            {
                nextIndex = 0;
            }
            if(previousIndex < 0) // minimum
            {
                previousIndex = InventoryManager.instance.PlayerInventoryList.Count - 1; 
            }
        }
        
    }
}
