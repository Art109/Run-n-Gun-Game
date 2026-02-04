using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour, IDamageble
{
    [SerializeField] int maxHealth;
    int currentHealth;

    PlayerRespawn respawn;
    PlayerController controller;


    private void Awake()
    {
        respawn = GetComponent<PlayerRespawn>();
        controller = GetComponent<PlayerController>();
    }

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        Debug.Log("Estou com " + currentHealth + " vida");
        if (currentHealth <= 0) 
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Morri");
        if (controller != null)
        {
            controller.enabled = false;
        }

        currentHealth = maxHealth;
        respawn.Respawn();

        controller.enabled = true;
    }


}
