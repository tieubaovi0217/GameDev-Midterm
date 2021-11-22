using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    //[SerializeField] GameObject player;
    public GameObject coin;
    public GameObject gift;
    public GameObject player;
    public AudioSource audioSource;
    public AnimationClip animDie;
    public Animator anim;
    public bool isDead;
    public int health; // set heath for obstacle, default is 10 -> EASY, 20 -> MEDIUM, 30 -> HARD
                       // bullet damage is 10

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    public void Hurt(int damage)
    {
        this.health -= damage;
        if (this.health <= 0)
            this.HandleDie();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {   
        if(isDead == false && collision.tag == "Bullet")
        {
            this.Hurt(Bullet.DAMAGE);         
        }
        else if(collision.tag == "Player")
        {
            collision.gameObject.GetComponent<Player>().hurt();
        }
        else if(collision.tag == "Border")
        {
            Destroy(this.gameObject);
        }
    }

    void HandleDie()
    {
        isDead = true;
        audioSource.Play();
        anim.Play(animDie.name);
        Destroy(this.gameObject, animDie.length);
        
        float giftRate = Random.Range(0.0f, 1.0f);
        if(giftRate < 0.05f) // 5% rate of gift
        {
            gift.GetComponent<Gift>().GenerateGift(transform);
        }
        else
        {
            coin.GetComponent<Coin>().GenerateCoin(transform);
        }
    }

}
