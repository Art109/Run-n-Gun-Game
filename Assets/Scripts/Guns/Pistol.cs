using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : Gun
{

    public override void Shoot(Transform shootPoint, float direction, GameObject bulletPrefab) 
    {
        GameObject bullet = GameObject.Instantiate(bulletPrefab, shootPoint);
        bullet.GetComponent<Bullet>().SetDirection(direction);
    }
}
