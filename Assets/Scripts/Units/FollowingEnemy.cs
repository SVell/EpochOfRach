﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class FollowingEnemy : MonoBehaviour
{

    public int damage = 20;
    public AIPath aiPath;

    // Update is called once per frame
    void Update()
    {
        // TODO: Change direction upon walls
        // Change direction upon end of the platform
        if (aiPath.desiredVelocity.x >= 0.01f)
        {
            transform.localScale = new Vector3(-1,1,1);
        }
        else if (aiPath.desiredVelocity.x <= -0.01f)
        {
            transform.localScale = new Vector3(1,1,1);
        }
    }
    
    void OnCollisionStay2D(Collision2D collision2D)
    {
        if (collision2D.gameObject.CompareTag("Player"))
        {
            collision2D.gameObject.GetComponent<playerController>().TakeDamage(damage);
        }
    }
    
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.gameObject.GetComponent<playerController>().TakeDamage(damage);
        }
    }
}
