using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Rigidbody2D rb;
    public float forceAdded;
    public GameObject firePoint;
    public float deathTime = 3f;

    public string[] colorFirePointTags = { "GreenFirePoint", "BlueFirePoint", "RedFirePoint", "SandFirePoint", "BlackFirePoint" };

    [SerializeField] private GameObject greenPlayer;
    [SerializeField] private Rigidbody2D greenRb;

    [SerializeField] private Turret turret;

    [SerializeField] private FirePointColor pickFirePoint;
    public enum FirePointColor
    {
        GreenFirePoint,
        BlueFirePoint,
        RedFirePoint,
        SandFirePoint,
        BlackFirePoint,
    }

    private void Start()
    {
        greenPlayer = GameObject.FindGameObjectWithTag("GreenPlayer");
        greenRb = greenPlayer.GetComponent<Rigidbody2D>();

        string selectedTag = colorFirePointTags[(int)pickFirePoint];

        rb = GetComponent<Rigidbody2D>();

        firePoint = GameObject.FindGameObjectWithTag(selectedTag);

        Invoke("BulletDeath", deathTime);

        turret = firePoint.GetComponent<Turret>();

       
    }

    // Update is called once per frame
    void Update()
    {

        rb.AddForce(turret.directionForBullet * forceAdded * Time.deltaTime, ForceMode2D.Force);


    }

    void BulletDeath()
    {
        Destroy(this.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Obstacles" || collision.gameObject.tag == "Nature")
        {
            BulletDeath();
            Debug.Log("bullet broke");
        }
    }
}
