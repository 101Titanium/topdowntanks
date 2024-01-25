using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankHealth : MonoBehaviour
{

    public float health, maxHealth = 3f;
    public FloatingHealthBar healthBar;
    public GameObject explosionPrefab;

    private void Start()
    {
        health = maxHealth;
        healthBar.UpdateHealthBar(health, maxHealth);
    }
    private void Awake()
    {
        healthBar = GetComponentInChildren<FloatingHealthBar>();
    }

    public void TakeDamage(float damageAmount)
    {
        health -= damageAmount;
        healthBar.UpdateHealthBar(health, maxHealth);

        if (health <= 0)
        {
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            Die();
        }
    }

    public void Die()
    {
        Destroy(this.gameObject);
    }

}
