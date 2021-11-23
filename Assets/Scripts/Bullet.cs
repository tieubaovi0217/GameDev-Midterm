using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Animator anim;
    public int speed;
    public static int DAMAGE = 10;
   
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {   
        if (collision.tag == "Enemy" || collision.tag == "Border")
        {
            Destroy(this.gameObject);
        }
    }
}
