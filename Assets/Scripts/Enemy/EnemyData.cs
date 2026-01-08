using UnityEngine;

[CreateAssetMenu(menuName = "EnemyData")]
public class EnemyData : ScriptableObject
{
    [SerializeField] int hp;
    public int Hp { get { return hp; } }

    [SerializeField] int damage;
    public int Damage { get { return damage; } }

    [SerializeField] int fireRate;
    public int FireRate { get { return fireRate; } }

    [SerializeField] float speed;

    public float Speed { get { return speed; } }

    [SerializeField] int range;
    public int Range { get { return range; } }  

}
