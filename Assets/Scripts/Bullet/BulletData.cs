using System.Collections;
using System.Collections.Generic;
using System.IO.Enumeration;
using UnityEngine;

[CreateAssetMenu(fileName = "Ammo", menuName = "Ammuniton")]
public class BulletData : ScriptableObject 
{
    [SerializeField] int damage;
    public int Damage { get { return damage; } }
    [SerializeField] float speed;
    public float Speed { get { return speed; } }
    [SerializeField] Sprite sprite;
    public Sprite Sprite { get { return sprite; } }
}
