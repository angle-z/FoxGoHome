using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogControl : Enemy
{
    [SerializeField] private Rigidbody2D rb;
    public Transform left;
    public Transform right;
    public LayerMask Ground;
    public float speed_x = 10;
    public float speed_y = 10;
    private float LeftPos, RightPos;
    private bool faceLeft = true;
   // private Animator Anim;
    public Collider2D coll;

    // Start is called before the first frame update
    protected override void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        base.Start();
       // Anim = GetComponent<Animator>();
        //coll = GetComponent<Collider2D>();
        LeftPos = left.position.x;
        RightPos = right.position.x;
        Destroy(left.gameObject);
        Destroy(right.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        SwitchAnim();
    }
    void Movement()
    {
        if(faceLeft)
        {
            if (coll.IsTouchingLayers(Ground))
            {
                Anim.SetBool("jumping", true);
               // Debug.Log("Leftjumping:" + Anim.GetBool("jumping"));
                rb.velocity = new Vector2(-speed_x, speed_y);
            }
            rb.transform.localScale = new Vector3(1, 1, 1);
            if(transform.position.x<=LeftPos)
            {
                faceLeft = false;
            }
        }
        else
        {
            if (coll.IsTouchingLayers(Ground))
            {
                Anim.SetBool("jumping", true);
               // Debug.Log("Rightjumping:" + Anim.GetBool("jumping"));
                rb.velocity = new Vector2(speed_x, speed_y);
            }
            rb.transform.localScale = new Vector3(-1, 1, 1);
            if (transform.position.x >= RightPos)
            {
                faceLeft = true;
            }
        }
    }
    void SwitchAnim()
    {
        if(Anim.GetBool("jumping"))
        {
           // Debug.Log("jumping:" + Anim.GetBool("jumping"));
            if (rb.velocity.y<0)
            {
                Anim.SetBool("jumping", false);
               // Debug.Log("jumping:" + Anim.GetBool("jumping"));
                Anim.SetBool("falling", true);
               // Debug.Log("falling:" + Anim.GetBool("falling"));
            }
            
        }
        if (coll.IsTouchingLayers(Ground) && Anim.GetBool("falling"))
        {
            Anim.SetBool("falling", false);

        }
    }
    
}
