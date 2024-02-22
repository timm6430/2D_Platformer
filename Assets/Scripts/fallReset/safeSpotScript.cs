using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class safeSpotScript : MonoBehaviour
{

  public VectorValue playerStorage;

  private void OnTriggerEnter2D(Collider2D collision)
  {
    if (collision.gameObject.CompareTag("Player"))
    {
      playerStorage.initialValue = new Vector2(transform.position.x, transform.position.y);
    }
  }
}
