using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] public Rigidbody rb;
    // Start is called before the first frame update
    private void Awake()
    {
        Destroy(gameObject, 3f);
    }
}
