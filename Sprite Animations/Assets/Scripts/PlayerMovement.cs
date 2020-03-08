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

        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A))
        {
            if (!FindObjectOfType<AudioManager>().isPlaying("Footstep"))
            {
                FindObjectOfType<AudioManager>().Play("Footstep");
            }
        }
         
        if (Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.A))
        {
            FindObjectOfType<AudioManager>().Stop("Footstep");
        }
        if (Input.GetButtonDown("Jump"))
        {
            if (isDisguised)
            {
                jump = true;
                animator.SetTrigger("jump");
            }
            else
            {
                jump = true;
                animator.SetBool("isJumping", true);
            }
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
            FindObjectOfType<AudioManager>().Play("Lighting");
            FindObjectOfType<AudioManager>().Play("Smoking");
            animator.SetBool("isSmoking", true);
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            FindObjectOfType<AudioManager>().Stop("Smoking");
            animator.SetBool("isSmoking", false);
        }
        if (Input.GetKeyDown(KeyCode.T))
        {
            if (isDisguised)
            {
                animator.SetTrigger("transform");
                FindObjectOfType<AudioManager>().Play("Transform");
                isDisguised = false;
                Debug.Log(isDisguised);
            }
            else
            {
                animator.SetTrigger("transform");
                FindObjectOfType<AudioManager>().Play("Transform");
                isDisguised = true;
                Debug.Log(isDisguised);
            }
        }
        /*
        if (Input.GetKeyDown(KeyCode.T) && (isDisguised==false))
        {
            Debug.Log("1");
            animator.SetTrigger("transform");
//            animator.SetBool("isDisguised", true);
            isDisguised = true;
            Debug.Log(isDisguised);
        }
        else if (Input.GetKeyDown(KeyCode.T) && (isDisguised == true))
        {
            Debug.Log("2");
            animator.SetTrigger("transform");
            //animator.SetBool("isDisguised", false);
            isDisguised = false;
            Debug.Log(isDisguised);
        }*/

        if (Input.GetMouseButtonDown(0)){
            animator.SetTrigger("shoot");
        }
        /*
        if (horizontalMove != 0)
        {
            Debug.Log("here");
            FindObjectOfType<AudioManager>().Play("Footstep");
        }
        if (horizontalMove == 0)
        {
            Debug.Log("here stops");
            FindObjectOfType<AudioManager>().Stop("Footstep");
        }
        */

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
