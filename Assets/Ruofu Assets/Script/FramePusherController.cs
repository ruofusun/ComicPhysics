using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Playables;

public class FramePusherController : MonoBehaviour
{
    public FadeInAndOutController _fadeInAndOutController;
    private Vector3 origin;
    private ButterflyController _butterflyController;
    private PlayerController _playerController;
    public Transform playerDes;
    public Transform butterflyDes;
    private Rigidbody2D rb;
    
    
    // Start is called before the first frame update
    void Start()
    {
       // _fadeInAndOutController = FindObjectOfType<FadeInAndOutController>();
        origin = transform.position;
        _butterflyController = FindObjectOfType<ButterflyController>();
        _playerController = FindObjectOfType<PlayerController>();
        rb = GetComponent<Rigidbody2D>();

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
          transform.position = origin;
          _playerController.transform.position =new Vector3(playerDes.position.x-6,playerDes.position.y,_playerController.transform.position.z) ;
          _butterflyController.transform.position = new Vector3(butterflyDes.position.x,butterflyDes.position.y,_butterflyController.transform.position.z) ;
          rb.velocity= Vector2.zero;
        }
    }
}
