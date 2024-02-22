using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableItem : MonoBehaviour
{
    [SerializeField] Item item;
    [SerializeField] HotBar hotBar;
    [SerializeField] KeyCode itemPickupKeycode = KeyCode.E;

    bool isInRange;

    private void Update() 
    {
        if (isInRange && Input.GetKeyDown(itemPickupKeycode))
        {
            hotBar.AddItem(Instantiate(item));
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        isInRange = true;
        //Debug.Log("Entered");
    }
    private void OnTriggerExit2D(Collider2D other) 
    {
        isInRange = false;
        //Debug.Log("Exited");
    }
}
