using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gift : MonoBehaviour
{
    public GameObject playerItemManager;

    // Start is called before the first frame update
    void Start()
    {
        playerItemManager = GameObject.FindGameObjectWithTag("PlayerItemManager");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            playerItemManager.GetComponent<PlayerItemManager>().AddItem();
            Destroy(this.gameObject);
        }
        else if(collision.tag == "Border")
        {
            Destroy(this.gameObject);

        }
    }

    public void GenerateGift(Transform transform)
    {
        Instantiate(this, new Vector3(transform.position.x,
                   transform.position.y, transform.position.z), Quaternion.identity);
    }
}
