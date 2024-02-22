using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCInteractScript : MonoBehaviour
{
  private bool isInRange;
  public KeyCode interactKey;

    // Start is called before the first frame update
    void Start()
    {
        isInRange = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isInRange)
        {
          if(Input.GetKeyDown(interactKey))
          {
            //DialogueTrigger.TriggerDialogue();
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
