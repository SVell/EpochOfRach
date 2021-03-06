﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;
using UnityEngine.PlayerLoop;

public class FireBall : MonoBehaviour
{
    public GameObject destroyed;
    public int damage = 20;
    public float movementSpeed = 8;
    public float direction = -1;
    
    public AudioSource destroy;
    
    
    void Update()
    {
        transform.Translate( transform.right * (direction * movementSpeed * Time.deltaTime));
    }

    // Destroy and play part with sound
    void OnCollisionEnter2D(Collision2D collision2D)
    {
        if (collision2D.gameObject.CompareTag("Player"))
        {
            collision2D.gameObject.GetComponent<playerController>().TakeDamage(damage);
        }
        destroy.Play();
        Instantiate(destroyed, transform.position, transform.rotation);
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        gameObject.GetComponent<Collider2D>().enabled = false;
        gameObject.GetComponentInChildren<Light2D>().enabled = false;
        Destroy(gameObject,1f);
    }
}
