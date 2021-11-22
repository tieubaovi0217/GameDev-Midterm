using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ScoreManager : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] AudioSource audioSource;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(GameObject.FindGameObjectWithTag("Player") != null)
        {
            int playerScore = player.GetComponent<Player>().score;
            GetComponent<TextMeshProUGUI>().text = ((int)playerScore).ToString();
        }
    }

    public void AddScore()
    {
        player.GetComponent<Player>().score += 10;
        audioSource.Play();
    }
}
