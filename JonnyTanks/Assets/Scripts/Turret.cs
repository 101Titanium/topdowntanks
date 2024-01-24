using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    public GameObject bulletPrefab;
    public GameObject firePoint;
    public Vector3 directionForBullet;
    [SerializeField] private Animator muzzle;

    public bool coolDown = false;

    public void Start()
    {
        muzzle = GetComponentInChildren<Animator>();
    }
    void Update()
    {
        Shoot();
    }

    void Shoot()
    {
        // Get the mouse position in the world coordinates
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // Calculate the direction from the turret to the mouse position
        Vector3 direction = mousePosition - firePoint.transform.position;

        Quaternion rotation = Quaternion.LookRotation(Vector3.forward, direction);

        

        if (Input.GetKeyDown(KeyCode.Mouse0) && coolDown == false)
        {
            directionForBullet = direction;
            Instantiate(bulletPrefab, firePoint.transform.position, rotation);
            coolDown = true;
            Invoke("DisableCooldown", 0.8f);

            muzzle.SetTrigger("Shoot");
        }
    }

    void DisableCooldown()
    {
        coolDown = false;
    }
}
