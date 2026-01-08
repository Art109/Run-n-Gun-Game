using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sentry : Enemy
{

    private void Update()
    {
        Detect();
    }
    protected override void Shoot()
    {
        
    }

    protected override void Detect()
    {
       Collider2D player = Physics2D.OverlapCircle(transform.position, data.Range, playerLayer);

        if (player != null) 
        {
            Debug.Log("Detectei o Player");
        }
    }


}
