using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombBallController : MonoBehaviour
{
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Props"))
        {
            anim.SetTrigger("cd");
        }
    }

    public void SelfDestroy()
    {
        Destroy(gameObject);
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            anim.SetTrigger("explode");
          //  Debug.Log("should hurt player");
        }
    }
}
