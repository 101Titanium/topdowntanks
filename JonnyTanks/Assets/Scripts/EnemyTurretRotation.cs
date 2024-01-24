using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTurretRotation : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 30;
    [SerializeField] private GameObject player;
    public EnemyTankMovement enemyTankMovement;
    public ActivateFiring activateFiring;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("GreenTank");
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyTankMovement.canMove == true || activateFiring.shootingAllowed)
        {
            Vector2 directionToPlayer = transform.position - player.transform.position;
            directionToPlayer.Normalize();


            Quaternion targetRotation = Quaternion.LookRotation(Vector3.forward, directionToPlayer);

            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
        
    }
}
