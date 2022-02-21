using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpossumControl : Enemy
{
    [SerializeField] private Rigidbody2D rb;
    public Transform left;
    public Transform right;
    
    public float speed_x = 2;
    private float LeftPos, RightPos;
    private bool faceLeft = true;
  //  private Animator Anim;
    public Collider2D coll;

    // Start is called before the first frame update
    protected override void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        // Anim = GetComponent<Animator>();
        base.Start();
        LeftPos = left.position.x;
        RightPos = right.position.x;
        Destroy(left.gameObject);
        Destroy(right.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }
    void Movement()
    {
        if (faceLeft)
        {

            rb.velocity = new Vector2(-speed_x, rb.velocity.y);
            rb.transform.localScale = new Vector3(1, 1, 1);
            if (transform.position.x <= LeftPos)
            {
                faceLeft = false;
            }
        }
        else
        {

            rb.velocity = new Vector2(speed_x, rb.velocity.y);
            rb.transform.localScale = new Vector3(-1, 1, 1);
            if (transform.position.x >= RightPos)
            {
                faceLeft = true;
            }
        }

    }
    


}