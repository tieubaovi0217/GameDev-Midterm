using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerItemManager : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddItem()
    {
        audioSource.Play();
        int playerLevel = player.GetComponent<Player>().level;
        if (playerLevel < LevelManger.MAXIMUM_LEVEL)
        {
            player.GetComponent<Player>().level += 1;
        }
    }
}
