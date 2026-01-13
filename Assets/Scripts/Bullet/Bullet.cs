using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] BulletData data;
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] Rigidbody2D rb;

    void Awake()
    {
        if (data == null)
            Debug.LogError("BulletData não atribuído", this);

        if (rb == null)
            rb = GetComponent<Rigidbody2D>();

        if (spriteRenderer == null)
            spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Start()
    {
        spriteRenderer.sprite = data.Sprite;
        Destroy(gameObject, 2f);
    }


    public void SetDirection(Vector2 direction)
    {
        direction.Normalize();
        rb.velocity = direction * data.Speed;
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
        Destroy(gameObject);
    }
}
