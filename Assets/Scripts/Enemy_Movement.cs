﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Movement : MonoBehaviour
{

    [SerializeField] float moveSpeed = 1f;

    Rigidbody2D myRigidBody2D;


    // Start is called before the first frame update
    void Start()
    {
        myRigidBody2D = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isFacingRight())
        {
            myRigidBody2D.velocity = new Vector2(moveSpeed, 0f);
        }

        else
        {
            myRigidBody2D.velocity = new Vector2(-moveSpeed, 0f);
        }

    }

    bool isFacingRight()
    {
        return transform.localScale.x > 0;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        transform.localScale = new Vector2(-(Mathf.Sign(myRigidBody2D.velocity.x)), 1f);
    }
}