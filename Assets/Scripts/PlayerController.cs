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
    public float enemySpawnSpeed = 1.0f;
    private float elapsedBulletTime = 0.0f;
    private float elapsedEnemyTime = 0.0f;
    [SerializeField] GameObject bulletSpawnPoint;
    [SerializeField] Bullet bulletPrefab;
    [SerializeField] int bulletSpeed;
    [SerializeField] GameObject enemyPrefab;
    public float maxRadius = 1.0f;   // Radius of the outer circle
    public float minRadius = 1.0f;   // Radius of the inner circle
    public int segments = 36;    // Number of segments to approximate the circle

    
    private void FixedUpdate() 
    {
        _rigidbody.velocity = new Vector3(_joystick.Horizontal * moveSpeed, _rigidbody.velocity.y, _joystick.Vertical * moveSpeed);
        if(_joystick.Horizontal !=0 || _joystick.Vertical != 0) transform.rotation = Quaternion.LookRotation(_rigidbody.velocity.normalized);
    }

    private void Update()
    {
        elapsedBulletTime += Time.deltaTime;
        elapsedEnemyTime += Time.deltaTime;
        if (elapsedBulletTime >= bulletspawnSpeed)
        {
            var bulletObj = Instantiate(bulletPrefab.gameObject, bulletSpawnPoint.transform.position, bulletSpawnPoint.transform.rotation);
            bulletObj.GetComponent<Bullet>().rb.velocity = bulletSpawnPoint.transform.forward * bulletSpeed;
            elapsedBulletTime = 0.0f;
        }
        if(elapsedEnemyTime >= enemySpawnSpeed)
        {
            Vector3 enemyPos;
            do
            {
                // Generate a random point within the sphere of max radius
                enemyPos = Random.insideUnitSphere * maxRadius;

                // Flatten to the XZ plane and set a fixed Y position
                enemyPos.y = 1f;

                // Check if the point is outside the minimum radius
            } while (enemyPos.magnitude < minRadius);

            //Vector3 enemySpawnPos = new Vector3(enemyPos.x, enemyPos.y, 0f);
            GameObject enemy = Instantiate(enemyPrefab.gameObject, enemyPos, Quaternion.identity);
            Destroy(enemy, 5f);
            elapsedEnemyTime = 0.0f;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red; // Set the color of the circle
        DrawCircle(gameObject.transform.position, maxRadius, segments);
        DrawCircle(gameObject.transform.position, minRadius, segments);
    }

    private void DrawCircle(Vector3 center, float radius, int segments)
    {
        float angleStep = 360f / segments; // Angle between each segment
        Vector3 previousPoint = center + new Vector3(radius, 0, 0); // Start at (radius, 0)

        for (int i = 1; i <= segments; i++)
        {
            float angle = i * angleStep * Mathf.Deg2Rad; // Convert angle to radians
            Vector3 newPoint = center + new Vector3(Mathf.Cos(angle) * radius,0f , Mathf.Sin(angle) * radius);

            Gizmos.DrawLine(previousPoint, newPoint); // Draw a line between the points
            previousPoint = newPoint;                // Update the previous point
        }
    }
}
