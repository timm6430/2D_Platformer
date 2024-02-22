using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(CircleCollider2D))]
public class Item : MonoBehaviour
{
  public enum InteractionType {NONE, PickUp, Examine}
  public enum ItemType {NONE, Static, Consumables}
  public InteractionType interactType;
  public ItemType itemType;
  //public UnityEvent staticEvent;
  public UnityEvent consumableEvent;
  private void Reset()
  {
    GetComponent<Collider2D>().isTrigger = true;
    gameObject.layer = 12;
  }
  
  public void Interact()
  {
    switch(interactType)
    {
      case InteractionType.PickUp:
        FindObjectOfType<HotBarSystem>().PickUp(gameObject);
        gameObject.SetActive(false);
        break;
      case InteractionType.Examine:
        Debug.Log("Examine");
        break;
      default:
        Debug.Log("Null item");
        break;
        
    }
  }
}
