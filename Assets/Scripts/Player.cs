using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    private Rigidbody2D _rigidbody2D;
    private Vector2 _direction;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float directionY = Input.GetAxisRaw("Vertical");
        _direction = new Vector2(0, directionY).normalized;
    }

    void FixedUpdate()
    {
        _rigidbody2D.velocity = new Vector2(0, _direction.y * speed);
    }
}
