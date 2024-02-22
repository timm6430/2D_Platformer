using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class ItemDatabase : ScriptableObject 
{
    [SerializeField] Item[] items;

    public Item GetItemReference (string itemID)
    {
        foreach (Item item in items)
        {
            if (item.ID == itemID)
            {
                return item;
            }
        }
        return null;
    }

    public Item GetItemCopy (string itemID)
    {
        Item item = GetItemReference(itemID);
        if (item == null)
        {
            return null;
        }
        return item.GetCopy();
    }
}

