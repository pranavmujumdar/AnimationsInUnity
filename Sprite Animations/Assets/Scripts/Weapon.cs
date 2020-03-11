using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Animator animator;
    public Transform firePoint;
    public GameObject bulletPrefab;
    public bool hasGun = false;
    public int bullets = 0;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (PlayerMovement.isDisguised || hasGun == false || bullets <=0)
            {
                return;
            }
            else
            {
                
                Shoot();
                
            }
        }

        void Shoot()
        {
            animator.SetTrigger("shoot");
            Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            FindObjectOfType<AudioManager>().Play("Gunshot");
            bullets -= 1;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Gun"))
        {
            hasGun = true;
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("BulletsPick"))
        {
            bullets = 10;
            Destroy(collision.gameObject);
        }
    }
}
