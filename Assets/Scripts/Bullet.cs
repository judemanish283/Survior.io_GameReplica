using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Rigidbody rb;

    private void Awake()
    {
        Destroy(gameObject, 3f);
    }
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            other.gameObject.GetComponent<Enemy>().EnemyKilled();
            //Destroy(gameObject);
        }
    }

   
}
