using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingFrameController : MonoBehaviour
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

    public void ShakeFrame()
    {
        if (anim)
        {
            anim.SetTrigger("shake");
        }
    }
}
