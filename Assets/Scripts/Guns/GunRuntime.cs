using UnityEngine;

[System.Serializable]
public class GunRuntime
{
    Gun gun;
    float cooldown;

    public GunRuntime(Gun gun)
    {
        this.gun = gun;
        cooldown = 0;
    }

    public void Tick()
    {
        if (cooldown > 0f)
        {
            cooldown -= Time.deltaTime;
        }
    }

    public void TryShoot(Transform shootPoint, Vector2 direction, GameObject bulletPrefab)
    {
        if (gun.FireRate <= 0f || cooldown > 0f)
            return;

        gun.Shoot(shootPoint, direction, bulletPrefab);
        cooldown = 1f / gun.FireRate;


    }
}
