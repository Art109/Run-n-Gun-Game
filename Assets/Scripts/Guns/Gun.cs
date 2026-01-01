using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Gun 
{
    protected float damage;

    public abstract void Shoot(Transform shootPoint, float direction, GameObject bulletPrefab);
    
}
