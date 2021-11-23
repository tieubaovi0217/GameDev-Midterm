using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] AudioSource audioSource;

    private Vector3 scoreCornerPos = new Vector3(670, 378, 0);
    private Vector3 scoreCenterPos = new Vector3(88, -170, 0);

    public GameObject highScore;

    void Start()
    {
        transform.localPosition = scoreCornerPos;
    }

    // Update is called once per frame
    void Update()
    {
        if(GameObject.FindGameObjectWithTag("Player") != null)
        {
            int playerScore = player.GetComponent<Player>().score;
            GetComponent<TextMeshProUGUI>().text = ((int)playerScore).ToString();
        }
        else
        {
            transform.localPosition = scoreCenterPos;
            int playerScore = Int32.Parse(GetComponent<TextMeshProUGUI>().text);
            SetHighScore(playerScore);
        }
    }

    private void SetHighScore(int playerScore)
    {
        int playerHighScore = PlayerPrefs.GetInt("HighScore", 0);
        if (playerScore > playerHighScore)
        {
            PlayerPrefs.SetInt("HighScore", playerScore);
            playerHighScore = playerScore;
        }
        highScore.GetComponent<TextMeshProUGUI>().text = ((int)playerHighScore).ToString();
    }

    public void AddScore()
    {
        player.GetComponent<Player>().score += 10;
        audioSource.Play();
    }
}
