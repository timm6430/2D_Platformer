using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSaveManager : MonoBehaviour
{
    [SerializeField] ItemDatabase itemDatabase;
    private const string HotBarFileName = "HotBar";

    public void LoadHotBar (HotBar hotBar)
    {
        ItemContainerSaveData savedSlots = ItemSaveIO.LoadItems(HotBarFileName);
        if (savedSlots == null)
        {
            return;
        }

        for (int i = 0; i < savedSlots.SavedSlots.Length; i++)
        {
            ItemSlots itemSlot = hotBar.itemSlots[i];
            ItemSlotSaveData savedSlot = savedSlots.SavedSlots[i];

            if (savedSlot == null)
            {
                itemSlot.Item = null;
            }
            else
            {
                itemSlot.Item = itemDatabase.GetItemCopy(savedSlot.ItemID);
                hotBar.items.Add(itemSlot.Item);
            }
        }
    }

    public void SaveHotBar (HotBar hotBar)
    {
        SaveItems(hotBar.itemSlots, HotBarFileName);
    }

    private void SaveItems(IList<ItemSlots> itemSlots, string fileName)
    {
        var saveData = new ItemContainerSaveData (itemSlots.Count);

        for (int i = 0; i < saveData.SavedSlots.Length; i++)
        {
            ItemSlots itemSlot = itemSlots[i];

            if (itemSlot.Item == null)
            {
                saveData.SavedSlots[i] = null;
            }
            else
            {
                saveData.SavedSlots[i] = new ItemSlotSaveData(itemSlot.Item.ID);
                saveData.size++;
            }
        }

        ItemSaveIO.SaveItems(saveData, fileName);
    }
}
