using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;

public class Patroller : Enemy
{
    bool active;
    Transform target;


    [Header("Movement Params")]
    [SerializeField] Transform groundCheck;
    [SerializeField] LayerMask groundLayer;
    int direction = 1;
    Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        if (rb != null) 
        {
            Debug.LogWarning(this + "without Rb");
            gameObject.SetActive(false);
        }
    }

    protected override void Update() 
    { 
        base.Update();

        if (!active)
        {
            Patrol();
            return;
        }

        Chase();

    }
    protected override void Detect() // Verifies if player is on range
    {
        Collider2D player = Physics2D.OverlapCircle(transform.position, Data.Range, PlayerLayer);

        active = player != null;
        target = player != null ? player.transform : null;

    }

    void Chase() // Logic of Chase Player
    {

    }

    void Patrol() // Logic of Patrol an Area
    {

    }

    void Move() // Enemy Movement
    {
        
    }

    void Flip() // Flip Sprite
    { 
    
    }


    bool BorderCheck() // Verifies if the enemy is near a border
    {
        return false;
    }

    void Shoot()
    {

    }
}
