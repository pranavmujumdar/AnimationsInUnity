using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Animator animator;
    public int health = 100;

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
    }
    public void Die()
    {
        Destroy(gameObject,2f);
    }
    
}
