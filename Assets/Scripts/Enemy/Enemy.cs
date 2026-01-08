using UnityEngine;

public abstract class Enemy : MonoBehaviour , IDamageble
{
    public EnemyData data;

    public LayerMask playerLayer;

    int currentHp;

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

        if (data == null) return;
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, data.Range);
    }
}
