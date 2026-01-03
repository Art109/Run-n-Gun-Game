using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName ="Guns/Pistol")]
public class Pistol : Gun
{


    public override void Shoot(Transform shootPoint, float direction, GameObject bulletPrefab) 
    {
        GameObject bullet = GameObject.Instantiate(bulletPrefab, shootPoint.position, Quaternion.identity);
        bullet.GetComponent<Bullet>().SetDirection(direction);
    }
}
