using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] BulletData data;
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] Rigidbody2D rb;
    void Start()
    {
        spriteRenderer.sprite = data.Sprite;
    }

    public void SetDirection(float direction)
    {
        Debug.Log(direction);
        rb.velocity = new Vector2(direction, 0) * data.Speed;
    }
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        IDamageble damageable = collision.GetComponent<IDamageble>();

        if (damageable != null)
        {
            damageable.TakeDamage(data.Damage);
        }

        Explode();
    }

    void Explode()
    {
        //Animação de Explodir ao Contato
        //Destroy
    }
}
