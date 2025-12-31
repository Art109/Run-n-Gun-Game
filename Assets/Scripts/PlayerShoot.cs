using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public IGun Gun { get; private set; }
   
    void Start()
    {
        if (Gun == null)
            ChangeGun(new Pistol());
    }

    public void Shoot()
    {
        if (Gun == null)
            return;

        Gun.Shoot();

    }

    public void ChangeGun(IGun newGun)
    {
        Gun = newGun;
    }

}




