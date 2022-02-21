using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    protected Animator Anim;
    protected AudioSource boomAudio;
    // Start is called before the first frame update
    protected virtual void Start()
    {
        Anim = GetComponent<Animator>();
        boomAudio = GetComponent<AudioSource>();
    }
    public void Boom()
    {
        boomAudio.Play();
        Anim.SetTrigger("boom");
        
        
    }
    public void death()
    {
        Destroy(gameObject);
    }

}
