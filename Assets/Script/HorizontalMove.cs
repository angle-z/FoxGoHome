using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalMove : MonoBehaviour
{
    public float speed=300;
    public float distance=0.5f;
    [SerializeField] private Rigidbody2D rb;
    // Start is called before the first frame update
    private float rb_x;
    private float rb_left;
    private float rb_right;
    private bool GoLeft, GoRight;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb_x =transform.position.x;
        rb_left = rb_x - distance;
        rb_right = rb_x + distance;
        GoLeft = true;
        GoRight = false;
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }
    public void Movement()
    {
        if (GoLeft)
        {
            rb.transform.localScale = new Vector3(1, 1, 1);
            rb.velocity = new Vector2(-speed * Time.deltaTime, rb.velocity.y);
            if (rb.position.x <= rb_left)
            {
                GoLeft = false;
                GoRight = true;
            }
        }
        
        if(GoRight)
        {
            rb.transform.localScale = new Vector3(-1, 1, 1);
            rb.velocity = new Vector2(speed * Time.deltaTime, rb.velocity.y);
            if(rb.position.x>=rb_right)
            {
                GoRight = false;
                GoLeft = true;
                
            }
        }

    }
}
