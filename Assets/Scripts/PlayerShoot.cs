using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{

    public Gun CurrentGun { get; private set; }

    [SerializeField] GameObject bulletPrefab;
    [SerializeField]Transform shootPoint;
   
    void Start()
    {
        if (CurrentGun == null)
            ChangeGun(new Pistol());
    }

    public void Shoot(float direction)
    {
        if (CurrentGun == null)
            return;

        CurrentGun.Shoot(shootPoint, direction, bulletPrefab);

    }

    public void ChangeGun(Gun newGun)
    {
        CurrentGun = newGun;
    }

    public void ChangeAmmo()
    {

    }

}




