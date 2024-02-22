using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class open_script : MonoBehaviour
{
  public GameObject[] graves;
  public int cleanedGraves;
  public bool openedDoor = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      if(!openedDoor){
        cleanedGraves = 0;
        foreach (var grave in graves)
        {
            if (grave.GetComponent<toggleScript>().clean)
            {
              cleanedGraves++;
            }
        }
      }
      //Debug.Log(graves.Length);
      if (cleanedGraves >= graves.Length && !openedDoor)
      {
        openDoor();
      }
    }

    void openDoor()
    {
      this.GetComponent<Collider2D>().enabled = false;
      openedDoor = true;
    }
}
