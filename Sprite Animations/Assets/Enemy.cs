using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Animator animator;
    public int health = 100;
    private float speed = 2f;
    public Transform groundDetection;
    private bool movingRight = true;
    public Transform PlayerDetectionBehind;
    public Transform PlayerDetectionFront;
    public float playerBehindDistance = 1f;
    public float playerFrontDistance = 2f;
    
    // public GameObject deathEffect;
    // Start is called before the first frame update


    public void TakeDamage (int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }
    private void Update()
    {
        if (health <= 0)
        {
            animator.SetBool("isDead", true);
        }
        

        if(movingRight == true)
        {

            //Debug.Log("Moving Rigt");
            //RaycastHit2D playerInfo = Physics2D.Raycast(PlayerDetectionBehind.position, Vector2.left, playerBehindDistance);
            RaycastHit2D playerInfoFront = Physics2D.Raycast(PlayerDetectionFront.position, Vector2.right, playerFrontDistance);
            //Debug.DrawRay(PlayerDetectionBehind.position, Vector2.left * playerBehindDistance, Color.red);
            Debug.DrawRay(PlayerDetectionFront.position, Vector2.right * playerFrontDistance, Color.magenta);
            if (playerInfoFront.collider == true)
            {
                //Debug.Log(playerInfo.collider.tag);
                if(playerInfoFront.collider.tag == "Player")
                {
                    Debug.Log("Player");
                }
                //Debug.Log("Player in range!");
            }
        }
        else
        {
            //Debug.Log("moving Left");

            RaycastHit2D playerInfoFront = Physics2D.Raycast(PlayerDetectionFront.position, Vector2.left, playerFrontDistance);
            Debug.DrawRay(PlayerDetectionFront.position, Vector2.left * playerFrontDistance, Color.green);

            if (playerInfoFront.collider == true)
            {
                if (playerInfoFront.collider.tag == "Player")
                {
                    Debug.Log("Player");
                }
                //Debug.Log("Player in range!");
            }
        }




        RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, 1f);

        //Debug.DrawRay(PlayerDetectionLeft.position, Vector2.left * 1f, Color.cyan);


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
    
}
