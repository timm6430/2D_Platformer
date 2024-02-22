using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class doorInteractRoomTransition : MonoBehaviour
{
  public string sceneToLoad;
  public Vector2 playerNextScenePosition;
  public VectorValue playerStorage;
  public bool isInRange = false;
  public KeyCode interactKey;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isInRange)
        {
          if(Input.GetKeyDown(interactKey))
          {
            playerStorage.initialValue = playerNextScenePosition;
            SceneManager.LoadScene(sceneToLoad);
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
