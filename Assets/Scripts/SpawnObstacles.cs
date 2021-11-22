using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObstacles : MonoBehaviour
{
    public GameObject obstacle;
    public GameObject boss;
    public float minX;
    public float maxX;
    public float minY;
    public float maxY;
    public float timeBetweenSpawn;
    private float spawnTime;
    public GameObject scoreManager;
    public int bossScoreLevel;

    // Update is called once per frame
    void Update()
    {
        if(Time.time > spawnTime)
        {
            Spawn();
            spawnTime = Time.time + timeBetweenSpawn; 
        }
    }

    void Spawn()
    {
        //if (scoreManager.GetComponent<ScoreManager>().GetScore() > bossScoreLevel && GameObject.FindGameObjectWithTag("Boss") == null)
        //{
        //    Instantiate(boss, transform.position + new Vector3(3, 0, 0), transform.rotation);
        //}
        
        if (GameObject.FindGameObjectWithTag("Boss") != null)
        {
            float randomX = Random.Range(minX, maxX);
            float randomY = Random.Range(minY, maxY);
            Instantiate(obstacle, transform.position + new Vector3(randomX, randomY, 0), transform.rotation);
        }
    }

    
}
