using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerMovementScript : MonoBehaviour
{
  public CharacterController2D controller;
  private Rigidbody2D m_Rigidbody2D;
  public Animator animator;
  public float runSpeed = 40f;
  float horizontalMove = 0f;
  float vertMovement = 0f;

  bool jump = false;
  //bool doubleJump = false;

  public VectorValue startingPosition;

  void Awake() 
  {
    animator.SetBool("moving", false);
    animator.SetBool("grounded", true);
    //controller.OnLandEvent = OnLandEvent;
  }

  void Start()
  {
    transform.position = startingPosition.initialValue;
  }

  void OnLandEvent(Animator animator)
  {
    animator.SetBool("grounded", true);
  }
  void Update ()
  {
    horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

    if (Input.GetButtonDown("Jump"))
    {
      jump = true;
      animator.SetBool("grounded", false);
    }
  }

  // Update is called once per frame
  public void FixedUpdate()
  {
    if (horizontalMove == 0)
    {
      animator.SetBool("moving", false);
    }
    else
    {
      animator.SetBool("moving", true);
    }

    vertMovement = Input.GetAxisRaw("Vertical");
    
    if (vertMovement == 0)
    {
      animator.SetBool("grounded", true);
    }
    else
    {
      animator.SetBool("grounded", false);
    }

    controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
    jump = false;
  }
}
