using UnityEngine;

public abstract class Enemy : MonoBehaviour , IDamageble
{
    public EnemyData data;

    public LayerMask playerLayer;

    int currentHp;

    float fireCooldown;

    private void Awake()
    {
        if (data == null)
        {
            Debug.LogError($"{name} não possui EnemyData atribuído.", this);
            enabled = false;
            return;
        }

        currentHp = data.Hp;
    }

    protected virtual void Update()
    {
        UpdateFireCooldown();
    }

    protected void UpdateFireCooldown()
    {
        if(fireCooldown > 0f)
            fireCooldown -= Time.deltaTime;
    }

    protected bool CanShoot()
    {
       return fireCooldown <= 0f && data.FireRate > 0f;
    }

    protected void ResetFireCooldown()
    {
        fireCooldown = 1f / data.FireRate;
    }

    public void TakeDamage(int damage)
    {
        currentHp -= damage;

        if(currentHp <= 0)
        {
            Die();
        }

    }

    protected virtual void Die()
    {
        Destroy(gameObject);
    }

    protected abstract void Shoot();

    protected abstract void Detect();

    private void OnDrawGizmos()
    {
        if (data == null)
            return;

        DrawBaseGizmos();
        DrawExtraGizmos();
    }

    protected virtual void DrawBaseGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, data.Range);
    }

    protected virtual void DrawExtraGizmos()
    {
        // vazio por padrão
    }
}
