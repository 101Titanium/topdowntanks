using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    public GameObject bulletPrefab;
    public GameObject firePoint;
    public Vector3 directionForBullet;

    public bool coolDown = false;

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
            Instantiate(bulletPrefab, firePoint.transform.position, rotation);
            coolDown = true;
            Invoke("DisableCooldown", 0.8f);

            directionForBullet = direction;
        }
    }

    void DisableCooldown()
    {
        coolDown = false;
    }
}
