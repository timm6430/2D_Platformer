using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour {

	public Dialogue dialogue;

  private bool isInRange;
  private bool startedDialogue;
  public KeyCode interactKey;

    // Start is called before the first frame update
  void Start()
  {
    isInRange = false;
    startedDialogue = false;
  }

  // Update is called once per frame
  void Update()
  {
      if (isInRange)
      {
        if(Input.GetKeyDown(interactKey))
        {
          TriggerDialogue();
        }
      }
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

	public void TriggerDialogue ()
	{
    Debug.Log("Triggering Dialogue");
    if (!startedDialogue)
    {
      FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
      startedDialogue = true;
    }
		else
    {
      FindObjectOfType<DialogueManager>().DisplayNextSentence();
    }
	}

}
