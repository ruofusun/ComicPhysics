using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class TriggerTimeline : MonoBehaviour
{

    public LayerMask layer;

    public PlayableDirector playableDirector;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        int otherLayer = 1 << other.gameObject.layer;
        Debug.Log(otherLayer+" "+ layer);
        if (otherLayer == layer)
        {
            playableDirector.Play();
            Debug.Log("change camera");
            
        }
    }
}
