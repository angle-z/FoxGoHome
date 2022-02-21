using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayController : MonoBehaviour
{
    [SerializeField]private Rigidbody2D rb;
    public Collider2D collHead;
    private Animator Anim;

    public float speed = 10;
    public float jumpforce = 10;
   
    public LayerMask Ground;
    public LayerMask Ladder;
    public Collider2D coll;
    public Joystick joystick;
    public float Score;
    public Text ScoreText;
    public bool IsHurt;
    public AudioSource scoreAudio;
    public AudioSource hurtAudio;
    public AudioSource jumpAudio;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!IsHurt)
        {
            Movement();
        }
        SwitchAnim();

        if (rb.position.y < -7)
        {
            Invoke("Restar", 2f);
        }
    }
    //移动
    void Movement()
    {
        //float horizontalmove = Input.GetAxis("Horizontal");
        float horizontalmove = joystick.Horizontal;
        //float facedirection = Input.GetAxisRaw("Horizontal");
        float facedirection = joystick.Horizontal;
        //float vertical = Input.GetAxis("Vertical");
        float vertical = joystick.Vertical;
        //角色移动
        if(horizontalmove==0)
        {
            Anim.SetFloat("running", 0);
        }
        if (horizontalmove!=0)
        {

            rb.velocity = new Vector2(horizontalmove *speed, rb.velocity.y);
            Anim.SetFloat("running", Mathf.Abs(facedirection));
        }
       
        if(facedirection>=0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        if (facedirection < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        //角色跳跃
        if ((Input.GetButtonDown("Jump") || vertical > 0.5) && coll.IsTouchingLayers(Ground))
        {
            if (!jumpAudio.isPlaying)
            {
                jumpAudio.Play();
            }
            rb.velocity = new Vector2(rb.velocity.x, jumpforce);
            Anim.SetBool("jumping", true);
        }
        //角色下蹲
        if(vertical<-0.5)
        {
            Anim.SetBool("crouching", true);
            collHead.isTrigger = true;

        }
        if(vertical>=-0.5)
        {
            Anim.SetBool("crouching", false);
            collHead.isTrigger = false;
        }
        //角色攀爬
        if(coll.IsTouchingLayers(Ladder))
        {
            Anim.SetBool("climbing", true);

            if (Input.GetKey(KeyCode.UpArrow))
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpforce-4);
               
            }
        }
        else if(!coll.IsTouchingLayers(Ladder))
        {
            Anim.SetBool("climbing", false);
        }

    }
    //动画切换
    void SwitchAnim()
    {

        Anim.SetBool("idle", false);
        
        if (rb.velocity.y < 0)
        {
            Anim.SetBool("falling", true);
        }
        if(Anim.GetBool("jumping"))
        {
            if(rb.velocity.y<0)
            {
                Anim.SetBool("jumping", false);
                Anim.SetBool("falling", true);
            }
        }
        //受伤
        else if(IsHurt)
        {
            
            Anim.SetBool("hurting", true);
            if(!hurtAudio.isPlaying)
            hurtAudio.Play();
            
            if (Mathf.Abs(rb.velocity.x)<0.1)
            {
                Anim.SetBool("hurting", false);
                Anim.SetFloat("running", 0);
                IsHurt = false;
                
            }
        }
        else if(coll.IsTouchingLayers(Ground))
        {
            Anim.SetBool("falling", false);
            Anim.SetBool("idle", true);
        }
        
    }

    //获得分值
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag.Equals("Collection"))
        {
            scoreAudio.Play();
            Destroy(collision.gameObject);
            Score += 1;
            ScoreText.text = Score.ToString();
        }
    }
    //复活，重新开始
    void Restar()
    {
      
      SceneManager.LoadScene(SceneManager.GetActiveScene().name);
       
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //消灭敌人
        if (collision.gameObject.tag.Equals("Enemy"))
        {
            
            Enemy enemy = collision.gameObject.GetComponent<Enemy>();


            if (Anim.GetBool("falling"))
            {
               
                enemy.Boom();

                rb.velocity = new Vector2(rb.velocity.x, jumpforce);
                Anim.SetBool("jumping", true);
            }//受伤
           else if(transform.position.x<collision.gameObject.transform.position.x)
            {
                
                rb.velocity = new Vector2(-5, rb.velocity.y);
                IsHurt = true;
            }
           else if(transform.position.x > collision.gameObject.transform.position.x)
            {
                rb.velocity = new Vector2(5, rb.velocity.y);
                IsHurt = true;
            }
           else if(transform.position.y < collision.gameObject.transform.position.y)
            {
                rb.velocity = new Vector2(5, rb.velocity.y);
                IsHurt = true;
            }
        }
        
    }
}
