using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class fallResetScript : MonoBehaviour
{
  public GameObject player;
  public VectorValue playerStorage;
  public string sceneToLoad;
  public Vector2 playerNextScenePosition;

    // called on player collision
  private void OnTriggerEnter2D(Collider2D collision)
  {
    Vector3 v = new Vector3(0, 0, 0);
    if (collision.gameObject.CompareTag("Player"))
    {
      Debug.Log("falling");
      player.transform.position = playerStorage.initialValue;
      Debug.Log(player.transform.position);
      //decrement player health here
      if (player.GetComponent<CharacterStats>().GetHealth() > 1.0f)
      {
        player.GetComponent<CharacterStats>().DecreaseHealth(1.0f);
      }
      else
      {
        playerStorage.initialValue = playerNextScenePosition;
        SceneManager.LoadScene(sceneToLoad);
      }
    }
  }

}
