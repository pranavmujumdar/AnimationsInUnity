using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;
    public Rigidbody2D rb;
    public int damage = 20;
    public GameObject wallImpactEffect;
    public GameObject enemyImpactEffect;
    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject.tag);
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Instantiate(enemyImpactEffect, transform.position, transform.rotation);
            Enemy enemy = collision.GetComponent<Enemy>();
            if(enemy != null)
            {
                enemy.TakeDamage(damage);
            }
        }
        else
        {
            Instantiate(wallImpactEffect, transform.position, transform.rotation);
        }

        Destroy(gameObject);
    }
    
    private void LateUpdate()
    {
        GameObject[] impactdust = GameObject.FindGameObjectsWithTag("ImpactDust");
        foreach (GameObject obj in impactdust)
        {
            Destroy(obj, 1f);
        }
    }
}
