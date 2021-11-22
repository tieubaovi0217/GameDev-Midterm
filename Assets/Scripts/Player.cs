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
    private float invisibleTime = 0;
    private int defaultInvisibleTime = 3;

    public int score = 0;
    public int health = 3;

    private Animator anim;
    private AudioSource audioSource;
    public PlayerInfoManager playerInfoManager;


    public int level;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
        playerInfoManager = GetComponentInParent<PlayerInfoManager>();
        playerInfoManager.updateHealth(health);
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

    public void checkInvisible()
    {
        this.invisibleTime -= Time.deltaTime;
        Debug.Log("invisibleTime: " + invisibleTime);
        if (isInvisible())
        {
            anim.Play("Blink");
            Debug.Log("Blink");
        }
        else
        {
            anim.Play("Idle");
            Debug.Log("Idle");
        }
    }

    private bool isInvisible()
    {
        return this.invisibleTime > 0;
    }

    public void hurt()
    {
        if (!isInvisible())
        {
            this.health -= 1;
            if (this.health < 0)
            {
                Destroy(this.gameObject);
                return;
            }
            this.invisibleTime = this.defaultInvisibleTime;
        }
        //Debug.Log("Player hurt, remaing health: " + health);
        playerInfoManager.updateHealth(health);
    }

    private void Shoot()
    {
        if(level == 0)
        {
            Instantiate(bullet, new Vector3(transform.position.x + 1f,
                   transform.position.y, transform.position.z), Quaternion.identity);
        }
        else if(level == 1)
        {
            Instantiate(bullet, new Vector3(transform.position.x + 1f,
                   transform.position.y - 0.25f, transform.position.z), Quaternion.identity);
            Instantiate(bullet, new Vector3(transform.position.x + 1f,
                   transform.position.y + 0.25f, transform.position.z), Quaternion.identity);
        }
        else if(level == 2)
        {
            Instantiate(bullet, new Vector3(transform.position.x + 1f,
                   transform.position.y - 0.4f, transform.position.z), Quaternion.identity);
            Instantiate(bullet, new Vector3(transform.position.x + 1f,
                   transform.position.y, transform.position.z), Quaternion.identity);
            Instantiate(bullet, new Vector3(transform.position.x + 1f,
                   transform.position.y + 0.4f, transform.position.z), Quaternion.identity);
        }
    }

    void FixedUpdate()
    {
        _rigidbody2D.velocity = new Vector2(_direction.x * speed, _direction.y * speed);
        if (_direction.y == 1 || _direction.y == -1)
        {
            anim.Play("ShipMoveVertical");
        }
        else if (_direction.x == 1 || _direction.x == -1)
        {
            anim.Play("ShipMoveHorizontal");
        }
        else
        {
            anim.Play("Ship");
        }
        checkInvisible();
    }
}
