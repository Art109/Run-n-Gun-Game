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

    [SerializeField] float shootBufferTime = 0.1f;
    float shootBufferCounter;
    Vector2 bufferedDirection;

    [Header("Recoil Params")]
    [SerializeField] Rigidbody2D rb;
    [SerializeField] float recoilForce = 2f;


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


    void Update()
    {
        gunRuntime.Tick();

        shootBufferCounter -= Time.deltaTime;

        if (shootBufferCounter > 0)
        {
            gunRuntime.TryShoot(shootPoint, bufferedDirection, bulletPrefab);
        }
    }

    public void Shoot(Vector2 direction)
    {
        if (currentGun == null)
            return;

        if(gunRuntime.TryShoot(shootPoint, direction, bulletPrefab))
        {
            ApplyRecoil(direction);
        }

        bufferedDirection = direction;
        shootBufferCounter = shootBufferTime;

    }

    void ApplyRecoil(Vector2 direction)
    {
        rb.AddForce(Vector2.up.normalized * recoilForce, ForceMode2D.Impulse);
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




