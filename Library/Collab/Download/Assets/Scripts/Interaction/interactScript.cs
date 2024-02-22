using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class interactScript : MonoBehaviour
{
  public bool isInRange = false;
  public KeyCode interactKey;
  public UnityEvent interactAction;

    // Update is called once per frame
    void Update()
    {
        if (isInRange)
        {
          if(Input.GetKeyDown(interactKey))
          {
            interactAction.Invoke(); // fire event
          }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
      if (collision.gameObject.CompareTag("Player"))
      {
        isInRange = true;
      }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
      if (collision.gameObject.CompareTag("Player"))
      {
        isInRange = false;
      }
    }

}
