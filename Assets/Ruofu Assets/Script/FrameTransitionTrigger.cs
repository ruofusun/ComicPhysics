using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class FrameTransitionTrigger : MonoBehaviour
{
    public Transform playerDes;

    public GameObject prop;

    public Transform propDes;


    public float PlayerScale = 1;

    public PlayableDirector PD;
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
        if (other.gameObject.layer == LayerMask.NameToLayer("Player")||other.gameObject.layer == LayerMask.NameToLayer("Props"))
        {
            StartCoroutine(MoveRoutine(other.gameObject.GetComponent<Rigidbody2D>()));
        }
    }


    IEnumerator MoveRoutine(Rigidbody2D rb2d)
    {
        rb2d.gameObject.SetActive(false);
        if (rb2d.GetComponent<PlayerController>())
        {
            rb2d.gameObject.transform.position = playerDes.position;
            rb2d.gameObject.transform.localScale = new Vector3(PlayerScale, PlayerScale, 1);
        }
        else
        {
            if(prop)
            rb2d.gameObject.transform.position = propDes.position;
        }

        if (PD)
        {
            PD.Play();
        }
        yield return new WaitForSeconds(2f);
      

        rb2d.gameObject.SetActive(true);
        
    }
}
