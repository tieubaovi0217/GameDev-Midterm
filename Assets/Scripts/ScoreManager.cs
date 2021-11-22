using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text scoreText;
    public GameObject player;
    public AudioSource audioSource;


    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        player = GameObject.FindGameObjectWithTag("Player");
    }
    // Update is called once per frame
    void Update()
    {
        if(GameObject.FindGameObjectWithTag("Player") != null)
        {
            int playerScore = player.GetComponent<Player>().score;
            scoreText.text = "Score: " + ((int)playerScore).ToString();
        }
    }

    public int GetScore()
    {
        return player.GetComponent<Player>().score;
    }

    public void AddScore()
    {
        player.GetComponent<Player>().score += 10;
        audioSource.Play();
    }
}
