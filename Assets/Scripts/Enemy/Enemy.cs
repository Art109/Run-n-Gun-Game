using UnityEngine;

public abstract class Enemy : MonoBehaviour , IDamageble
{
    [Header("Core")]
    [SerializeField] EnemyData data;
    [SerializeField] Gun currentGun;
    [SerializeField] Transform shootPoint;
    [SerializeField] LayerMask playerLayer;
    public EnemyData Data { get { return data; } }
    public Gun CurrentGun { get { return currentGun; } }
    protected Transform ShootPoint => shootPoint;
    public LayerMask PlayerLayer {  get { return playerLayer; } }


    protected GunRuntime gunRuntime;
    int currentHp;

    

    protected virtual void Awake()
    {
        if (data == null || currentGun == null || shootPoint == null)
        {
            Debug.LogError($"{name} está com referencias faltando.", this);
            enabled = false;
            return;
        }


        gunRuntime = new GunRuntime(currentGun);
        currentHp = data.Hp;
    }

    protected virtual void Update()
    {
        gunRuntime.Tick();
        Detect();
    }

    protected void TryShoot(Vector2 direction)
    {
        gunRuntime.TryShoot(shootPoint, direction, Data.Bullet);
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
