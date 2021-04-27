using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityManager : MonoBehaviour
{
    protected int health;

    [SerializeField] protected Animator animator;


    protected virtual void Start()
    {
        // Initialize the values. Can be overriden
        health = 3;

    }

    // Update is called once per frame
    protected virtual void Update()
    {
        // Get the movement

    }

    protected void FixedUpdate()
    {
    }



    protected virtual void Interact()
    {
        return;
    }

    protected virtual void Attack()
    {
        return;
    }

    protected virtual void SecondAttack()
    {
        return;
    }
}