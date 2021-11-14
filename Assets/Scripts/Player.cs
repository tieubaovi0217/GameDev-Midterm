using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    public GameObject bullet;
    private Rigidbody2D _rigidbody2D;
    private Vector2 _direction;
    private double shootTime = 0;
    public double timeBetweenShoot;

    

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float directionY = Input.GetAxisRaw("Vertical");
        _direction = new Vector2(0, directionY).normalized;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (Time.time > shootTime)
            {
                Shoot();
                shootTime = Time.time + timeBetweenShoot;
            }
        }
    }

    private void Shoot()
    {
        Instantiate(bullet, new Vector3(transform.position.x + 1f,
                   transform.position.y, transform.position.z), Quaternion.identity);
    }

    void FixedUpdate()
    {
        _rigidbody2D.velocity = new Vector2(0, _direction.y * speed);
    }
}
