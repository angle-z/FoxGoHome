using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EagleControl :Enemy
{
    public Rigidbody2D rb;
    public Collider2D coll;
    public Transform top;
    public Transform down;
    
    
    public float speed_y = 5;
    private float TopPos, DownPos;
    private bool FaceTop = true;
  //  private Animator Anim;

    // Start is called before the first frame update
    protected override void Start()
    {
        FaceTop = true;
        //  Anim = GetComponent<Animator>();
        base.Start();
        TopPos = top.position.y;
        DownPos = down.position.y;
        Destroy(top.gameObject);
        Destroy(down.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }
    void Movement()
    {
        if(FaceTop)
        {
            rb.velocity = new Vector2(rb.velocity.x, speed_y);
            if(rb.position.y>=TopPos)
            {
                FaceTop = false;
            }
        }
        else
        {
            rb.velocity = new Vector2(rb.velocity.x, -speed_y);
            if (rb.position.y <= DownPos)
            {
                FaceTop = true;
            }
        }
    }
   
}
