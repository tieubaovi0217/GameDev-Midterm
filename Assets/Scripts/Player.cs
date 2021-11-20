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
    private bool isMoving = false;

    private Animator anim;
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
 
        float directionY = Input.GetAxisRaw("Vertical");
        float directionX = Input.GetAxisRaw("Horizontal");
        _direction = new Vector2(directionX, directionY).normalized;

        if (_rigidbody2D.velocity.x != 0 || _rigidbody2D.velocity.y != 0)
            isMoving = true;
        else
            isMoving = false;

        if (isMoving)
        {
            if (!audioSource.isPlaying)
                audioSource.Play();
        }

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
        _rigidbody2D.velocity = new Vector2(_direction.x * speed, _direction.y * speed);
        
        if (_direction.y == 1 || _direction.y == -1)
        {
            anim.Play("ShipMoveVertical");
        }
        if (_direction.x == 1 || _direction.x == -1)
        {
            anim.Play("ShipMoveHorizontal");
        }
    }
}
