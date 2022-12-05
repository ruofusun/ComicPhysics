using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingFrameController : MonoBehaviour
{
    private Animator anim;

    private Rigidbody2D rb2d;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShakeFrame()
    {
        if (anim)
        {
            anim.SetTrigger("shake");
        }
    }

    public void SetRotation(bool rotate)
    {
        rb2d.freezeRotation = rotate;
    }
}
