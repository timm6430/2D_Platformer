using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HotBar : MonoBehaviour
{
    public List<Item> items;
    [SerializeField] Transform itemsParent;
    public ItemSlots[] itemSlots;
    KeyCode[] hotbarKeys = new KeyCode[] {KeyCode.Alpha1, KeyCode.Alpha2, KeyCode.Alpha3, KeyCode.Alpha4, KeyCode.Alpha5};
    public FloatValue playerHealth;
    [SerializeField] ItemSaveManager itemSaveManager;
    [SerializeField] KeyCode hotBarSaveKeycode = KeyCode.V;
    [SerializeField] KeyCode hotBarLoadKeycode = KeyCode.L;

    private void Update() 
    {
        for (int i = 0; i < itemSlots.Length; i++)
        {
            if (Input.GetKeyDown(hotbarKeys[i])) 
            {
              Consume(i);
              RefreshUI();
            }
        }
        if (Input.GetKeyDown(hotBarSaveKeycode))
        {
            itemSaveManager.SaveHotBar(this);
        }
        if (Input.GetKeyDown(hotBarLoadKeycode))
        {
            itemSaveManager.LoadHotBar(this);
        }
    }
    private void OnValidate() 
    {
        if (itemsParent != null)
        {
            itemSlots = itemsParent.GetComponentsInChildren<ItemSlots>();
        }
        RefreshUI();
    }

    private void RefreshUI ()
    {
        int i = 0;
        for (; i < items.Count && i < itemSlots.Length; i++)
        {
            itemSlots[i].Item = items[i];
        }

        for (; i < itemSlots.Length; i++)
        {
            itemSlots[i].Item = null;
        }
    }

    public bool AddItem (Item item)
    {
        for (int i = 0; i < itemSlots.Length; i++)
        {
            if (items.Count < 5)
            {
                if (itemSlots[i].Item == null)
                {
                    itemSlots[i].Item = item;
                    items.Add(item);
                    return true;
                }
            }
        }
        return false;
    }

    public bool RemoveItem (Item item)
    {
        for (int i = 0; i < itemSlots.Length; i++)
        {
            if (itemSlots[i].Item == item)
            {
                itemSlots[i].Item = null;
                items.Remove(item);
                return true;
            }
        }
        return false;
    }

    public Item RemoveItem (string itemID)
    {
        for (int i = 0; i < itemSlots.Length; i++)
        {
            Item item = itemSlots[i].Item;
            if (item != null && item.ID == itemID)
            {
                itemSlots[i].Item = null;
                return item;
            }
        }
        return null;
    }

    public bool IsFull ()
    {
        for (int i = 0; i < itemSlots.Length; i++)
        {
            if (itemSlots[i].Item == null)
            {
                return false;
            }
        }
        return true;
    }

    public void Consume (int i)
    {
        if (itemSlots[i].Item is Item)
        {
          Debug.Log(itemSlots[i].Item.ItemName);
          if (itemSlots[i].Item.ItemName == "Health Potion" &&
           playerHealth.runtimeValue < 5)
          {
            itemSlots[i].Item.Use();
            RemoveItem (itemSlots[i].Item);
            itemSlots[i].Clear();
            RefreshUI();
          }
          else if (itemSlots[i].Item.ItemName != "Health Potion")
          {
            itemSlots[i].Item.Use();
            RemoveItem (itemSlots[i].Item);
            itemSlots[i].Clear();
            RefreshUI();
          }
            
        }
    }
}
