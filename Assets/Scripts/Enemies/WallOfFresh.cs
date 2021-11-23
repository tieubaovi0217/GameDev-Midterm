using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WallOfFresh : Enemy
{
    private int numberOfCoin = 20;
    private float endX = 3.7f;
    private float timeBetweenShootFollow = 1f;
    private float timeBetweenShootSpiral = 3f;
    private float followShootTime = 3f;
    private float spiralShootTime = 3f;
    public GameObject healthBarObject;
    public HealthBar healthBar;
    private float maxHealth;

    public GameObject followBullet;
    public GameObject normalBullet;

    protected override void Start()
    {
        base.Start();
        healthBarObject = GameObject.FindGameObjectWithTag("HealthBar");
        healthBarObject.GetComponent<RectTransform>().localScale = new Vector3(1,1,1);
        healthBar = healthBarObject.GetComponent<HealthBar>();
        healthBar.SetMaxHealth(health);
    }
    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);
    }
    protected override void OnDestroy()
    {
        base.OnDestroy();
        spawnEnemies.OnEnemyDie("WallOfFlesh");
    }

    public override void Hurt(int damage)
    {
        base.Hurt(damage);
        healthBar.SetHealth(health);
    }

    protected override void Update()
    {
        base.Update();
        if (transform.position.x > endX)
            transform.position -= new Vector3(speed * Time.deltaTime, 0, 0);

        if (Time.time > followShootTime)
        {
            ShootFollow();
            followShootTime = Time.time + timeBetweenShootFollow;
        }
        if (Time.time > spiralShootTime)
        {
            ShootSpiral();
            spiralShootTime = Time.time + timeBetweenShootSpiral;
        }
    }

    private void ShootSpiral()
    {
        float startAngle = 135;

        for (int i = 0; i < 9; i++)
        { 
            GameObject enemy = Instantiate(normalBullet, transform.position, transform.rotation);
            MovableEnemy script = enemy.GetComponent<MovableEnemy>();
            float angle = (startAngle + 10 * i) * Mathf.Deg2Rad;
            script.SetDirection(new Vector2(Mathf.Cos(angle), Mathf.Sin(angle)));
        }
    }
    private void ShootFollow()
    {
        GameObject target = GameObject.FindGameObjectWithTag("Player");
        Vector2 direction = new Vector2(target.transform.position.x - transform.position.x, target.transform.position.y - transform.position.y);
        GameObject enemy = Instantiate(followBullet, transform.position, transform.rotation);
        MovableEnemy script = enemy.GetComponent<MovableEnemy>();
        script.SetDirection(direction);
    }

    protected override void HandleDie()
    {
         base.HandleDie();
        healthBarObject.GetComponent<RectTransform>().localScale = new Vector3(0, 0, 0);

        gift.GetComponent<Gift>().GenerateGift(transform);
        for (int i = 0; i < numberOfCoin; i++)
        {
            float randomX = Random.Range(-0.5f, 0.5f);
            float randomY = Random.Range(-4f, 4f);
            coin.GetComponent<Coin>().GenerateCoin(transform.position + new Vector3(randomX, randomY));
        }
    }
}
