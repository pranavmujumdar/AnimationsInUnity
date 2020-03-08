﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;
    public Rigidbody2D rb;
    public GameObject wallImpactEffect;
    public GameObject enemyImapctEffect;
    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision);
        Destroy(gameObject);
        Instantiate(wallImpactEffect, transform.position, transform.rotation);
    }
    // Update is called once per frame
    void Update()
    {
        GameObject[] impactdust = GameObject.FindGameObjectsWithTag("ImpactDust");
        foreach (GameObject obj in impactdust)
        {
            Destroy(obj, 1f);
        }
    }
    private void LateUpdate()
    {
       
    }
}
