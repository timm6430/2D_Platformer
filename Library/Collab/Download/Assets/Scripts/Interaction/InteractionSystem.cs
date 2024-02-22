using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionSystem : MonoBehaviour
{
  public Transform detectionPoint;
  private const float detectionRadius = 1.25f;
  public LayerMask detectionLayer;
  public GameObject detectedObject;
 
  void Update()
  {
    if(DetectObjects())
    {
      if(InteractInput())
      {
        detectedObject.GetComponent<Item>().Interact();
      }
    }

  }
  bool InteractInput()
  {
    return Input.GetKeyDown(KeyCode.E);
  }

  bool DetectObjects()
  {
    Collider2D obj = Physics2D.OverlapCircle(detectionPoint.position, detectionRadius, detectionLayer);
    if(obj == null)
    {
      detectedObject = null;
      return false;
    }
    else
    {
      detectedObject = obj.gameObject;
      return true;
    }
  }


  private void OnDrawGizmosSelected()
  {
    Gizmos.DrawWireSphere(detectionPoint.position, detectionRadius);
  }
}
