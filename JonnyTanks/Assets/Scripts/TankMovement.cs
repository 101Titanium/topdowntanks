using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankMovement : MonoBehaviour
{
    public Rigidbody2D tankRigidbody;
    public float rotateSpeed;

    public float forwardSpeed;
    public float backwardSpeed;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        // Use GetAxis to smoothly control movement
        float verticalInput = Input.GetAxis("Vertical");

        float moveSpeed = verticalInput > 0 ? forwardSpeed : backwardSpeed;

        tankRigidbody.AddForce(transform.up * verticalInput * -moveSpeed * Time.deltaTime);

        // Use GetAxis to smoothly control rotation
        float horizontalInput = Input.GetAxis("Horizontal");
        tankRigidbody.MoveRotation(tankRigidbody.rotation - horizontalInput * rotateSpeed * Time.deltaTime);
    }
}
