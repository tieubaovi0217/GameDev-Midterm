using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private GameObject player;
    private int health;
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    public void hurt(int damage)
    {
        this.health -= damage;
        if (this.health <= 0)
            Destroy(this.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {   
        if(collision.tag == "Bullet")
        {
            anim.Play("ObstacleDie");
            Destroy(this.gameObject, 0.4f);
            GetComponent<AudioSource>().Play();
        }
        else if(collision.tag == "Player")
        {
            Destroy(player.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
}
