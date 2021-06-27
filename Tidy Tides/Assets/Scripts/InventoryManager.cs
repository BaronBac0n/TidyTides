using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//TODO no two items in the same slot

public class InventoryManager : MonoBehaviour
{
    public InventorySlot[] slots;

    [HideInInspector]
    public GameObject dragging;

    public GameObject itemToAdd;

    public Image tickImage;
    public Image crossImage;

    #region Singleton
    public static InventoryManager instance;

    void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one instance of InventoryManager found");
            return;
        }
        instance = this;
    }
    #endregion

    void Start()
    {


    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            AddNewItem(itemToAdd);
        }
    }

    public void AddNewItem(GameObject newItem)
    {
        if (CheckForEmptySlot() >= 0)
        {
            print("Slot " + CheckForEmptySlot() + " is the first empty slot");
            GameObject clone = Instantiate(itemToAdd, this.transform);
            slots[CheckForEmptySlot()].contents = clone;
        }
        else
        {
            print("inventory is full");
        }
    }

    public int CheckForEmptySlot() //checks for the first empty slot
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i].contents == null)
            {
                return i;
            }
        }
        return -1;
    }

    public IEnumerator Flash(GameObject obj)
    {
        for (int i = 0; i < 5; i++)
        {
            obj.SetActive(false);
            yield return new WaitForSeconds(.1f);
            obj.SetActive(true);
            yield return new WaitForSeconds(.1f);
        }
        obj.SetActive(false);
    }
}
