using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HotBarSystem : MonoBehaviour
{
    public List<GameObject> items = new List<GameObject>();
    public GameObject uiWindow;
    public Image[] itemsImages;
    KeyCode[] hotbarKeys = new KeyCode[] {KeyCode.Alpha1, KeyCode.Alpha2, KeyCode.Alpha3, KeyCode.Alpha4, KeyCode.Alpha5};
    public Sprite hotbarSprite;
    public void Update() 
    {
        for (int i = 0; i < hotbarKeys.Length; i++)
        {
            if (Input.GetKeyDown(hotbarKeys[i]))
            {
                Consume (i);
                //remove image
            }
        }
    }
    public void PickUp (GameObject item)
    {
        items.Add(item);

        UpdateUI ();
    }

    void UpdateUI ()
    {
        for (int i = 0; i < 5; i++)
        {
            if (i < items.Count)
            {
                itemsImages[i].sprite = items[i].GetComponent<SpriteRenderer>().sprite;
            }
            else
            {
                itemsImages[i].sprite = hotbarSprite;
            }
        }
    }

    public void Consume (int id)
    {
        if (items[id].GetComponent<Item>().itemType == Item.ItemType.Consumables)
        {
            Debug.Log($"Consumed {items[id].name}");
            items[id].GetComponent<Item>().consumableEvent.Invoke();
            Destroy (items[id], 0.1f);
            items.RemoveAt (id);
            UpdateUI ();
        }
    }
}
