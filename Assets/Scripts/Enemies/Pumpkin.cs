using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pumpkin : Enemy
{
    public Pumpkin()
    {
        spawnArea = new Area(3, 3.5f, -4, 4);
        timeBetweenSpawn = 2f;
        nextSpawnTime = 0;
    }

    protected override void Update()
    {
        base.Update();
        transform.position -= new Vector3(speed * Time.deltaTime, 0, 0);
    }
    
    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision); 
        if (collision.tag == "Border")
        {
            Destroy(this.gameObject);
        }
    }
    protected override void OnDestroy()
    {
        base.OnDestroy();
        spawnEnemies.OnEnemyDie("Pumpkin");
    }

    // Start is called before the first frame update
    protected override void HandleDie()
    {
        base.HandleDie();

        float giftRate = Random.Range(0.0f, 1.0f);
        if (giftRate < 0.05f) // 5% rate of gift
        {
            gift.GetComponent<Gift>().GenerateGift(transform);
        }
        else
        {
            coin.GetComponent<Coin>().GenerateCoin(transform.position);
        }
    }
}
