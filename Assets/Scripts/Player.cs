using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float movHor;
    [SerializeField] float speed = 5f;
    [SerializeField] bool isMoving = false;
    [SerializeField] float jumpForce = 3f;
    [SerializeField] bool isGrounded = false;
    [SerializeField] float radius = 0.3f;
    [SerializeField] float groundRayDist = 0.5f;
    [SerializeField] LayerMask groundLayer;

    Rigidbody2D rb;
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        movHor = Input.GetAxisRaw("Horizontal");
        isMoving = (movHor != 0f);
        isGrounded = Physics2D.CircleCast(this.transform.position, radius, Vector3.down, groundRayDist, groundLayer);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            jump();
        }
        flip(movHor);
    }
    void FixedUpdate()
    {
        rb.velocity = new Vector2(movHor * speed, rb.velocity.y);    
    }
    void jump()
    {
        if (!isGrounded) return;

        rb.velocity = Vector2.up * jumpForce;
    }
    void flip(float direccion)
    {
        
    }

    private void OnDrawGizmos()
    {
        RaycastHit2D rayo;
        Gizmos.color = Color.yellow;
        rayo = Physics2D.CircleCast(this.transform.position, radius, Vector3.down, groundRayDist, groundLayer);

        Gizmos.DrawSphere(rayo.centroid, rayo.distance);
        
    }
}
