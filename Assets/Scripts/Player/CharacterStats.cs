using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterStats : MonoBehaviour
{
  [SerializeField]
  private float maxHealth;

  public SignalSender playerHealthSignal;

  public FloatValue currentHealth;
  //public FloatValue currentMana;
  public VectorValue playerStorage;
  public bool isLoaded = false;
  [SerializeField] KeyCode characterSaveKeycode = KeyCode.V;
  [SerializeField] KeyCode characterLoadKeycode = KeyCode.L;


  private void Start()
  {
    currentHealth.initialValue = maxHealth;
  }

  private void Update() 
  {
    if (Input.GetKeyDown(characterSaveKeycode))
    {
      SavePlayer();
    }
    if (Input.GetKeyDown(characterLoadKeycode))
    {
      LoadPlayer();
    }
  }

  public float GetHealth ()
  {
    return currentHealth.runtimeValue;
  }

  public void DecreaseHealth(float amount)
  {
    currentHealth.runtimeValue -= amount;
    playerHealthSignal.Raise();

    if(currentHealth.runtimeValue <= 0.0f)
    {
      Die();
    }
  }

  public void IncreaseHealth ()
  {
    if (currentHealth.runtimeValue < 5.0f)
    {
      currentHealth.runtimeValue += 1;
      playerHealthSignal.Raise();
    }
  }

  public void IncreaseMana ()
  {
    if (currentHealth.runtimeValue < 5.0f)
    {
      currentHealth.runtimeValue += 1;
      playerHealthSignal.Raise();
    }
  }

  private void Die()
  {
    this.gameObject.SetActive(false);
  }

  public void SavePlayer ()
  {
    CharacterDataSave.SavePlayer(this);
  }

  public void LoadPlayer ()
  {
    Vector2 position;
    CharacterData data = CharacterDataSave.LoadPlayer();
    Debug.Log(data.level);
    currentHealth.runtimeValue = data.health;
    playerHealthSignal.Raise();
    position.x = data.position[0];
    position.y = data.position[1];
    playerStorage.initialValue = position;
    SceneManager.LoadScene (data.level);
  }
}
