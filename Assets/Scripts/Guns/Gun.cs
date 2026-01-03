using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Gun : ScriptableObject
{
    [SerializeField] float damage;
    [SerializeField] float fireRate;

    public float Damage { get {return damage; } }
    public float FireRate { get {return fireRate;} }

    public abstract void Shoot(Transform shootPoint, float direction, GameObject bulletPrefab);
    
}
