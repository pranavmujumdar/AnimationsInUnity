using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;

    public Animator animator;
    public float speed = 40f;
    float horizontalMove = 0f;
    bool jump = false;
    bool crouch = false;
    bool isDisguised = false;
    
    // Update is called once per frame
    void Update()
    {
        animator.SetBool("isDisguised", isDisguised);
        horizontalMove = Input.GetAxisRaw("Horizontal") * speed;
        animator.SetFloat("speed", Mathf.Abs(horizontalMove));
        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
            animator.SetBool("isJumping", true);
        }
        if (Input.GetButtonDown("Crouch"))
        {
            crouch = true;
        }
        else if (Input.GetButtonUp("Crouch"))
        {
            crouch = false;
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            animator.SetBool("isSmoking", true);
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            animator.SetBool("isSmoking", false);
        }
        if (Input.GetKeyDown(KeyCode.T) && (isDisguised = false))
        { 
            animator.SetTrigger("transform");
            animator.SetBool("isDisguised", true);
            isDisguised = true;
        }
        if (Input.GetKeyDown(KeyCode.T) && (isDisguised = true))
        {
            animator.SetTrigger("transform");
            animator.SetBool("isDisguised", false);
            isDisguised = false;
        }
        if (Input.GetMouseButton(0)){
            animator.SetTrigger("shoot");
        }
    }

    private void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;
    }

    public void onLanding()
    {
        animator.SetBool("isJumping", false);
    }
}
