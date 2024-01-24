using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTankMovement : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private Rigidbody2D enemyRigidbody;

    public bool canMove = false;

    [SerializeField] private float forwardSpeed = 20;

    public float rotationSpeed = 100;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("GreenTank");
        enemyRigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    public void Update()
    {
        

        if (canMove == true)
        {
            Vector2 directionToPlayer = transform.position - player.transform.position;
            directionToPlayer.Normalize();


            enemyRigidbody.AddForce(directionToPlayer * forwardSpeed * Time.deltaTime);

            Quaternion targetRotation = Quaternion.LookRotation(Vector3.forward, directionToPlayer);

            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }

    }

}
