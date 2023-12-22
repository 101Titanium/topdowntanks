using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretRotation : MonoBehaviour
{
    public Transform turretTransform;
    public int offset;
    public float turretRotateSpeed;

    void Update()
    {
        RotateTurretTowardsMouse();
    }

    void RotateTurretTowardsMouse()
    {
        // Get the mouse position in the world coordinates
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // Calculate the direction from the turret to the mouse position
        Vector3 direction = mousePosition - turretTransform.position;

        // Calculate the angle between the current turret forward and the direction to the mouse
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        float rotate = turretRotateSpeed * Time.deltaTime;

        // Rotate the turret towards the mouse position
        turretTransform.rotation = Quaternion.RotateTowards(turretTransform.rotation, Quaternion.AngleAxis(angle -= offset, Vector3.forward), rotate);
    }
}
