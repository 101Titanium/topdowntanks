using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateFiring : MonoBehaviour
{

    public GameObject bulletPrefab;
    public GameObject firePoint;
    public Vector3 directionForBullet;
    [SerializeField] private Animator muzzle;

    public EnemyTankMovement enemyTankMovement;

    [SerializeField] private GameObject player;

    [SerializeField] private GameObject enemy;

    [SerializeField] private RigidbodyConstraints2D enemyConstraints;

    private int maxIterations = 0;

#pragma warning disable
    private bool cooldown = false;
#pragma warning restore

    public bool shootingAllowed = false;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("GreenTank");
        muzzle = GetComponentInChildren<Animator>();
        enemyConstraints = GetComponent<RigidbodyConstraints2D>();
    }

    private void Update()
    {
        if (shootingAllowed == true)
        {
            Shoot();
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.name == "GreenTank")
        {
            shootingAllowed = true;
            enemyTankMovement.canMove = false;

            enemyConstraints = RigidbodyConstraints2D.FreezeRotation;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "GreenTank")
        {
            shootingAllowed = true;
            enemyTankMovement.canMove = false;

            enemyConstraints = RigidbodyConstraints2D.FreezeRotation;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "GreenTank")
        {
            shootingAllowed = false;
            enemyTankMovement.canMove = true;

            enemyConstraints = RigidbodyConstraints2D.None;
        }
    }

    private void Shoot()
    {
        if (cooldown == false && maxIterations == 0)
        {
            Vector3 direction = player.transform.position - firePoint.transform.position;

            Quaternion rotation = Quaternion.LookRotation(Vector3.forward, direction);

            Instantiate(bulletPrefab, firePoint.transform.position, rotation);
            cooldown = true;
            Invoke("DisableCooldown", 0.8f);

            muzzle.SetTrigger("Shoot");

            maxIterations = 1;
        }
    }

    void DisableCooldown()
    {
        cooldown = false;
        maxIterations = 0;
    }
}
