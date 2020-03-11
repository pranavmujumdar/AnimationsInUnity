using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Animator animator;
    public int health = 100;
    public float speed = 2f;
    public float minSpeed = 2f;
    public Transform groundDetection;
    private bool movingRight = true;
    public Transform PlayerDetectionBehind;
    public Transform PlayerDetectionFront;
    public float playerBehindDistance = 1f;
    public float playerFrontDistance = 2f;
    public float maxSpeed = 4f;
    private Transform target;
    // public GameObject deathEffect;
    // Start is called before the first frame update


    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }
    public void TakeDamage (int damage)
    {
        health -= damage;
    }
    private void Update()
    {


        isDead(health);

        if(movingRight == true)
        {

            //Debug.Log("Moving Rigt");
            //RaycastHit2D playerInfo = Physics2D.Raycast(PlayerDetectionBehind.position, Vector2.left, playerBehindDistance);
            RaycastHit2D playerInfoFront = Physics2D.Raycast(PlayerDetectionFront.position, Vector2.right, playerFrontDistance);
            //Debug.DrawRay(PlayerDetectionBehind.position, Vector2.left * playerBehindDistance, Color.red);
            Debug.DrawRay(PlayerDetectionFront.position, Vector2.right * playerFrontDistance, Color.magenta);
            isPlayerClose(playerInfoFront);
        }
        else
        {
            //Debug.Log("moving Left");

            RaycastHit2D playerInfoFront = Physics2D.Raycast(PlayerDetectionFront.position, Vector2.left, playerFrontDistance);
            Debug.DrawRay(PlayerDetectionFront.position, Vector2.left * playerFrontDistance, Color.green);
            isPlayerClose(playerInfoFront);
            
        }




        RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, 0.5f);

        Debug.DrawRay(groundDetection.position, Vector2.down * 0.5f, Color.cyan);


        Invoke("moveEnemy", 2f);
        if (groundInfo.collider == false)
        {
            if (movingRight == true)
            {
                animator.SetFloat("Speed", 0);
                CancelInvoke("moveEnemy");
                transform.Rotate(0f, 180f, 0f);
                movingRight = false;
            }
            else
            {
                animator.SetFloat("Speed", 0);
                CancelInvoke("moveEnemy");
                transform.Rotate(0f, 180f, 0f);
                movingRight = true;
            }
        }
    }

    IEnumerator rotateEnemy()
    {
        yield return new WaitForSeconds(2.0f);
        transform.Rotate(0f, 180f, 0f);
    }
    /*IEnumerator moveEnemy()
    {
        yield return new WaitForSeconds(0.0f);
        animator.SetFloat("Speed", 2);
        transform.Rotate(0f, 180f, 0f);
    }*/
    
    public void stopEnemy()
    {
        animator.SetFloat("Speed", 0);
        transform.Translate(Vector2.zero);
    }
    public void moveEnemy()
    {
        animator.SetFloat("Speed", 2);
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    public void Die()
    {
        Destroy(gameObject,2f);
    }
    

    public void isPlayerClose(RaycastHit2D playerInfoFront)
    {
        if (playerInfoFront.collider == true)
        {
            if (playerInfoFront.collider.tag == "Player")
            {
                if (speed < maxSpeed)
                {
                    speed = 3f;
                    animator.SetFloat("Speed", 2);
                    transform.position = Vector2.MoveTowards(transform.position, target.position, (speed+1f) * Time.deltaTime);
                }
            }
            //Debug.Log("Player in range!");
        }
        else
        {
            if (speed > minSpeed)
            {
                speed -= 0.01f;
            }
        }
    }
    void isDead(int health)
    {
        if (health <= 0)
        {
            animator.SetBool("isDead", true);
            Die();
        }
    }
}
