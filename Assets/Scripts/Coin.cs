using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public GameObject player;
    public AudioSource audioSource;
    public GameObject scoreManager;
    // Start is called before the first frame update
    void Start()
    {
        scoreManager = GameObject.FindGameObjectWithTag("ScoreManager");
        player = GameObject.FindGameObjectWithTag("Player");
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            scoreManager.GetComponent<ScoreManager>().AddScore();
            Destroy(this.gameObject);
        }
        else if(collision.tag == "Border")
        {
            Destroy(this.gameObject);
        }
    }

    public void GenerateCoin(Transform transform)
    {
        Instantiate(this, new Vector3(transform.position.x,
                   transform.position.y, transform.position.z), Quaternion.identity);
    }
}
