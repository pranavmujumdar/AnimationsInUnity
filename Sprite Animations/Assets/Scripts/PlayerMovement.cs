using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;

    public Animator animator;
    public float speed = 40f;
    float horizontalMove = 0f;
    bool jump = false;
    bool crouch = false;
    public static bool isDisguised = false;


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
        // To got to game over scene
        if (Input.GetKeyDown(KeyCode.B))
        {
            ScoreScript.scoreValue = 10;
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            SceneManager.LoadScene("LevelComplete", LoadSceneMode.Single);
        }
    /*    if (Input.GetMouseButtonDown(0))
        {
            if (!isDisguised)
            {
                animator.SetTrigger("shoot");
            }
        }
*/
    }

    private void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
            if (isDisguised)
            {
                return;
            }
            else
            {
                FindObjectOfType<AudioManager>().Stop("Footstep");
                SceneManager.LoadScene("GameOver", LoadSceneMode.Single);
            }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Disguise"))
        {
            if (!isDisguised)
            {
                animator.SetTrigger("transform");
                FindObjectOfType<AudioManager>().Play("Transform");
                isDisguised = true;
                Debug.Log(isDisguised);
                
            }
        }
        if (collision.gameObject.CompareTag("Suit"))
        {
            if (isDisguised)
            {
                animator.SetTrigger("transform");
                FindObjectOfType<AudioManager>().Play("Transform");
                isDisguised = false;
                Debug.Log(isDisguised);
            }
        }
    }
    public void onLanding()
    {
        animator.SetBool("isJumping", false);
    }

}
