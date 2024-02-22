using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gateOpen : MonoBehaviour
{

  public bool openedGate = false;
  public bool isInRange = false;
  public KeyCode interactKey;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
      if (Input.GetKeyDown(interactKey))
      {
        if (isInRange)
        {
          Open();
        }
        
      }
    }
    void Open()
    {
      Debug.Log("open");
      
      FindObjectOfType<DialogueManager>().GetComponent<Collider2D>().enabled = false;
      openedGate = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
  {
    Debug.Log(collision.tag);
    if (collision.gameObject.CompareTag("Player"))
    {
      isInRange = true;
      //Debug.Log("Entered");
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
