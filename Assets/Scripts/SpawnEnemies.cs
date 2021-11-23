using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
    private List<string> enemies = new List<string>() {"Pumpkin", "WallOfFlesh" };
    public GameObject Pumpkin;
    public GameObject WallOfFlesh;
    private Dictionary<string, Area> spawnArea = new Dictionary<string, Area>() {
        {"Pumpkin", new Area(3, 3.5f, -4, 4) },
        {"WallOfFlesh", new Area(9, 0, 0, 0) },
    };
    private List<float> timeBetweenSpawn = new List<float>() {1, 30};
    private List<float> nextSpawnTime = new List<float>() {0, 10};
    private List<int> maxInstances = new List<int>() { 20, 1 };
    private List<int> numOfInstances = new List<int>() { 0, 0 };

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < enemies.Count; i++)
        {
            if (Time.time > nextSpawnTime[i])
            {
                if (numOfInstances[i] < maxInstances[i])
                {
                    Spawn(enemies[i]);
                    numOfInstances[i]++;
                }
                nextSpawnTime[i] = Time.time + timeBetweenSpawn[i];
            }
        }
    }
    
    void Spawn(string enemyType)
    {
        switch (enemyType)
        {
            case "Pumpkin":
                float randomX = Random.Range(spawnArea[enemyType].left, spawnArea[enemyType].right);
                float randomY = Random.Range(spawnArea[enemyType].bottom, spawnArea[enemyType].top);
                Instantiate(Pumpkin, transform.position + new Vector3(randomX, randomY, 0), transform.rotation);
                break;
            case "WallOfFlesh":
                Instantiate(WallOfFlesh, new Vector3(spawnArea[enemyType].left, spawnArea[enemyType].bottom, -10), transform.rotation);
                break;
        }
    }

    public void OnEnemyDie(string enemyName)
    {
        int indexOfEnemies = enemies.IndexOf(enemyName);
        numOfInstances[indexOfEnemies]--;
    }
}
