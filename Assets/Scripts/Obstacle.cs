using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private GameObject player;
    public GameObject coin;
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
            GetComponent<AudioSource>().Play();
            Invoke("GenerateCoin", 0.4f);

            Destroy(this.gameObject, 0.4f);
            
        }
        else if(collision.tag == "Player")
        {
            collision.gameObject.GetComponent<Player>().hurt();
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    void GenerateCoin()
    {
        Instantiate(coin, new Vector3(transform.position.x - 0.5f,
                   transform.position.y, transform.position.z), Quaternion.identity);
    }
}
