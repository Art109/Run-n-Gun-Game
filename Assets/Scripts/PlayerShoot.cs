using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{

    [SerializeField] Gun CurrentGun;
    [SerializeField] GameObject bulletPrefab;
    [SerializeField]Transform shootPoint;

    bool canShoot = true;
   
    void Start()
    {
        if (CurrentGun == null)
            Debug.LogError("Arma não Equipada");
            
    }

    void Update()
    {
        
    }

    public void Shoot(float direction)
    {
        if (CurrentGun == null)
            return;

        if (canShoot)
        {
            CurrentGun.Shoot(shootPoint, direction, bulletPrefab);
            StartCoroutine(FireRateControl());
        }
            

    }

    IEnumerator FireRateControl()
    {
        canShoot = false;
        yield return new WaitForSeconds(CurrentGun.FireRate);
        canShoot = true;
        yield return null;
    }

    public void ChangeGun(Gun newGun)
    {
        CurrentGun = newGun;
    }

    public void ChangeAmmo()
    {

    }

}




