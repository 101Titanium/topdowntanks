using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDelete : MonoBehaviour
{
    public float deathTime = 0.25f;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("Die", deathTime);
    }


    void Die()
    {
        Destroy(this.gameObject);
    }
}
