using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class toggleScript : MonoBehaviour
{
  public bool clean = false;
  private bool isInRange = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
          toggleClean();
        }
    }
    
    public void toggleClean()
    {
      if (clean)
      {
        clean = false;
      }
      else
      {
        clean = true;
      }
      Debug.Log("toggled");
    }

    private void OnTriggerEnter2D(Collider2D collision)
  {
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
