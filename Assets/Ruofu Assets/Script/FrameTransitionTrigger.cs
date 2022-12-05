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

    public float transferCD = 2f;
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
        if (other.gameObject.layer == LayerMask.NameToLayer("Player")||other.gameObject.layer == LayerMask.NameToLayer("Props")||other.gameObject.layer == LayerMask.NameToLayer("Butterfly"))
        {
            StartCoroutine(MoveRoutine(other.gameObject.GetComponent<Rigidbody2D>()));
        }
    }


    IEnumerator MoveRoutine(Rigidbody2D rb2d)
    {
        rb2d.gameObject.SetActive(false);
        if (rb2d.GetComponent<PlayerController>())
        {
            rb2d.gameObject.transform.position =
                new Vector3(playerDes.position.x, playerDes.position.y, rb2d.transform.position.z);
            rb2d.gameObject.transform.localScale = new Vector3(PlayerScale, PlayerScale, 1);
        }
        else
        {
            if(prop)
            rb2d.gameObject.transform.position =  new Vector3(propDes.position.x, propDes.position.y, rb2d.transform.position.z);
        }

        if (PD)
        {
            PD.Play();
        }
        yield return new WaitForSeconds(transferCD);
      

        rb2d.gameObject.SetActive(true);
        
    }
}
