using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed = 5f; //Movement speed of the player

    private Rigidbody rb; //Reference to the Rigidbody component
    private float movement; //The current movement direction
    public GameObject bulletPrefab;
    public Transform bulletSpawnPoint; 
    public float bulletSpeed = 10f;

    private void Start()
    {
        //Get the Rigidbody component attached to this GameObject
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        //Get horizontal input
        movement = Input.GetAxis("Horizontal");

        if(Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        if (bulletPrefab && bulletSpawnPoint)
        {
            // Instantiate the bullet at the spawn point position and rotation
            GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);

            // Get the Rigidbody component of the bullet and set its velocity
            Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();
            if (bulletRb != null)
            {
                bulletRb.velocity = bullet.transform.forward * bulletSpeed;
            }
        }
        else
        {
            Debug.Log("Not Set Bullet");
        }
    }

    private void FixedUpdate()
    {
        //Move the player left or right in the FixedUpdate method
        Vector3 newPosition = rb.position + Vector3.right * movement * moveSpeed * Time.fixedDeltaTime;
        rb.MovePosition(newPosition);
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.layer == 8)
        {
            #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
            #else
            Application.Quit();
            #endif
        }
    }
}
