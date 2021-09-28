using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float movHor;
    [SerializeField] float speed = 5f;

    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        movHor = Input.GetAxisRaw("Horizontal");
    }
    void FixedUpdate()
    {
        rb.velocity = new Vector2(movHor * speed, rb.velocity.y);    
    }
}
