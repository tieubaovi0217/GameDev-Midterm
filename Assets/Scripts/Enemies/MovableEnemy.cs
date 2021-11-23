using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovableEnemy : MonoBehaviour
{
    // Start is called before the first frame update
    public Vector2 direction;
    public float speed;

    void Start()
    {
        
    }

    public void SetDirection(Vector2 direction)
    {
        this.direction = direction;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(direction.normalized.x * speed * Time.deltaTime, direction.normalized.y * speed * Time.deltaTime);
    }
}
