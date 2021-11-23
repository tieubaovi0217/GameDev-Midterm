using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //[SerializeField] GameObject player;
    protected Animator anim;
    protected GameObject player;
    protected AudioSource audioSource;

    public GameObject coin;
    public GameObject gift;
    public AnimationClip animDie;
    public bool isDead;
    protected float giftRate;
    public int health; // set heath for obstacle, default is 10 -> EASY, 20 -> MEDIUM, 30 -> HARD
                       // bullet damage is 10

    public Area spawnArea;
    public float speed;


    public float timeBetweenSpawn;
    public float nextSpawnTime;
    protected SpawnEnemies spawnEnemies;

    // Start is called before the first frame update
    protected virtual void Start()
    {
        spawnEnemies = GameObject.FindGameObjectsWithTag("SpawnPoint")[0].GetComponent<SpawnEnemies>();
        anim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    public virtual void Hurt(int damage)
    {
        this.health -= damage;
        if (this.health <= 0)
            this.HandleDie();
        //Debug.Log("Enemy health: " + this.health);
    }

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (isDead == false && collision.tag == "Bullet")
        {
            this.Hurt(Bullet.DAMAGE);
        }
        else if (collision.tag == "Player")
        {
            collision.gameObject.GetComponent<Player>().hurt();
        }
    }

    protected virtual void OnDestroy()
    {

    }
    protected virtual void Update()
    {
        
    }

    protected virtual void HandleDie()
    {
        Debug.Log("Die");
        isDead = true;
        if (audioSource != null)
            audioSource.Play();
        if (anim != null)
            anim.Play(animDie.name);
        if (animDie != null)
        {
            Destroy(this.gameObject, animDie.length);
        }
        else
            Destroy(this.gameObject);
    }
}
