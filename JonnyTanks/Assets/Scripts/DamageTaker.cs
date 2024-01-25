using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageTaker : MonoBehaviour
{
    public TankHealth tankHealth;
    [SerializeField] private float damageTaken;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "BulletEnemy")
        {
            tankHealth.TakeDamage(damageTaken);
        }
    }
}
