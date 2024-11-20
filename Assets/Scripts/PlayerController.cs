using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Rigidbody _rigidbody;
    [SerializeField] FixedJoystick _joystick;
    [SerializeField] float moveSpeed;
   

    [Header("Bullet Stuff")]
    public float bulletspawnSpeed = 1.0f;
    private float elapsedTime = 0.0f;
    [SerializeField] GameObject bulletSpawnPoint;
    [SerializeField] Bullet bulletPrefab;
    [SerializeField] int bulletSpeed;

    // Start is called before the first frame update
    private void FixedUpdate() 
    {
        _rigidbody.velocity = new Vector3(_joystick.Horizontal * moveSpeed, _rigidbody.velocity.y, _joystick.Vertical * moveSpeed);
        if(_joystick.Horizontal !=0 || _joystick.Vertical != 0) transform.rotation = Quaternion.LookRotation(_rigidbody.velocity.normalized);
    }

    private void Update()
    {
        elapsedTime += Time.deltaTime;
        if (elapsedTime >= bulletspawnSpeed)
        {
            Debug.Log("PEW PEW");
            var bulletObj = Instantiate(bulletPrefab.gameObject, bulletSpawnPoint.transform.position, bulletSpawnPoint.transform.rotation);
            bulletObj.GetComponent<Bullet>().rb.velocity = bulletSpawnPoint.transform.forward * bulletSpeed;
            elapsedTime = 0.0f;
        }
    }
}
