using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private float forceAdded;
    [SerializeField] private GameObject player;
    private Vector3 direction;

    void Start()
    {
        player = GameObject.Find("GreenTank");
        rb = GetComponent<Rigidbody2D>();
        SetDirection();
    }

    // Update is called once per frame
    void Update()
    {
        Shoot();
    }

    private void SetDirection()
    {
        direction = player.transform.position - transform.position;
    }
    private void Shoot()
    {
        
        rb.AddForce(direction * forceAdded * Time.deltaTime, ForceMode2D.Force);
        
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Obstacles" || collision.gameObject.tag == "Nature")
        {
            Destroy(this.gameObject);
        }
    }
}
