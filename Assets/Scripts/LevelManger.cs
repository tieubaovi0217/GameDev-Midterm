using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManger : MonoBehaviour
{
    // Start is called before the first frame update
    public static class Difficult
    {
        public static int EASY = 0;
        public static int MEDIUM = 1;
        public static int HARD = 2;
    }

    public static int MAXIMUM_LEVEL = 2;

    private float[] enemyHealthMuliplier = new float[] {1, 1.5f, 2 };
    private string[] backgroundResources = new string[] {"SKY" , "CITY", "SPACE"};

    public GameObject gameOverPanel;

    void Start()
    {
        loadBackground();
    }

    private void loadBackground()
    {
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindGameObjectWithTag("Player") == null)
        {
            gameOverPanel.SetActive(true);
        }
    }
}
