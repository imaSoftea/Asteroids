using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Horde horde;
    // Gun Timer
    float timer = 5.0f;
    public GameObject bulletPrefab;
    public Transform bulletSpawnPoint; 
    public float bulletSpeed = 10f;


    void Update()
    {
        timer -= Time.deltaTime;
        if(timer <= 0)
        {
            Shoot();
            timer = 5.0f;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.layer);
        if(collision.gameObject.layer == 7)
        {
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
        else
        {
            horde.FlipDirection();
        }
    }

    void Shoot()
    {
        if (bulletPrefab && bulletSpawnPoint)
        {
            // Instantiate the bullet at the spawn point position and rotation
            GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);

            // Get the Rigidbody component of the bullet and set its velocity
            Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();
            if (bulletRb != null)
            {
                bulletRb.velocity = -bullet.transform.forward * bulletSpeed;
            }
        }
        else
        {
            Debug.Log("Not Set Bullet");
        }
    }
}
