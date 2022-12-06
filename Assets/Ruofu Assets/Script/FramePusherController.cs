using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FramePusherController : MonoBehaviour
{
    private FadeInAndOutController _fadeInAndOutController;
    // Start is called before the first frame update
    void Start()
    {
        _fadeInAndOutController = FindObjectOfType<FadeInAndOutController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
          _fadeInAndOutController.DoFadeInAndOut();
        }
    }
}
