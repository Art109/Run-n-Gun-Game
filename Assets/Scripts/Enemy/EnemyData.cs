using UnityEngine;

[CreateAssetMenu(menuName = "EnemyData")]
public class EnemyData : ScriptableObject
{
    [SerializeField] int hp;
    public int Hp { get { return hp; } }

    [SerializeField] int damage;
    public int Damage { get { return damage; } }

    [SerializeField] float moveSpeed;

    public float MoveSpeed { get { return moveSpeed; } }

    [SerializeField] int range;
    public int Range { get { return range; } }

    [SerializeField] GameObject bulletPrefab;
    public GameObject Bullet { get { return bulletPrefab; } }

}
