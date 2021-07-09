using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;
    public Animator animator;
    float horizontalMove = 0f;
    public float runSpeed = 40f;
    bool jump = false;
    bool crounch = false;
    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));
        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
            animator.SetBool("isJumping", true);
        }
        if (Input.GetButtonDown("Crounch"))
        {
            crounch = true;
        }else if (Input.GetButtonUp("Crounch"))
        {
            crounch = false;
        }
    }

    public void OnLanding()
    {
        animator.SetBool("isJumping", false);
    }
    public void OnCrounching(bool isCrounching)
    {
        animator.SetBool("isCrounching", isCrounching);
    }
    private void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, crounch, jump);
        jump = false;
    }
}
