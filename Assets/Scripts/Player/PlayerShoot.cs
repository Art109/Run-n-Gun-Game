using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{

    [SerializeField] Gun currentGun;
    [SerializeField] GameObject bulletPrefab;
    [SerializeField]Transform shootPoint;
    GunRuntime gunRuntime;


    private void Awake()
    {
        if (currentGun == null)
        {
            Debug.LogError("Arma não Equipada");
            enabled = false;
            return;
        }
            

        gunRuntime = new GunRuntime(currentGun);
    }
    void Start()
    {
        
            
    }

    void Update()
    {
        gunRuntime.Tick();
    }

    public void Shoot(Vector2 direction)
    {
        if (currentGun == null)
            return;

            gunRuntime.TryShoot(shootPoint, direction, bulletPrefab);
     

    }

    public void ChangeGun(Gun newGun)
    {
        currentGun = newGun;

        gunRuntime = new GunRuntime(currentGun);
    }

    public void ChangeAmmo()
    {

    }

}




