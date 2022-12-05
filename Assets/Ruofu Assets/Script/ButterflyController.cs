using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Sirenix.OdinInspector;
using UnityEngine;
using Random = System.Random;

public class ButterflyController : MonoBehaviour
{
    public Transform des1;
    public Transform des2;
    public Transform des3;

    private RotatingFrameController _rotatingFrameController;
    private BallSpawner _ballSpawner;

    private Rigidbody2D rb2d;

    public float speed = 2f;
    private bool canPassSide = false;
    
    public enum CurrentScene
    {
        tutorial,
        mushroom,
        rotating
        
    }

     public CurrentScene currentScene = CurrentScene.tutorial;
    
    // Start is called before the first frame update
    void Start()
    {
        _rotatingFrameController = FindObjectOfType<RotatingFrameController>();
        _ballSpawner = FindObjectOfType<BallSpawner>();

        rb2d = GetComponent<Rigidbody2D>();
            
        if (currentScene == CurrentScene.rotating)
        {
            MoveRight();
        }

        if (currentScene == CurrentScene.tutorial)
        {
            var sequence = DG.Tweening.DOTween.Sequence();
            sequence.Pause();
            // "Wrap" the tween
            if (des1)
            {
                sequence.Append( transform.DOMove(new Vector3(des1.position.x, des1.position.y, transform.position.z), 3f)); 
            }

            if (des2)
            {
                sequence.Append( transform.DOMove(new Vector3(des2.position.x, des2.position.y, transform.position.z), 6.5f));
            }

            if (des3)
            {
                sequence.Append( transform.DOMove(new Vector3(des3.position.x, des3.position.y, transform.position.z), 3f));
            }
            sequence.Play();
        }

        

        //  transform.DOMove(des1.position, 3f);
        //   transform.DOMove(des2.position, 3f);
        //  transform.DOMove(des3.position, 3f);
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name.Contains("side") && !canPassSide)
        {
           
            
            if (_rotatingFrameController)
            {
            _rotatingFrameController.ShakeFrame();
            }

            if (rb2d && rb2d.velocity.x > 0)
            {
                MoveLeft();
                if (!_ballSpawner.SpawnBall(1))
                {
                    canPassSide = true;
                    MoveRight(); 
                    //PushBoundary();
                }
              
                

                Debug.Log("butterfly hit right sides");
            }
           else if (rb2d && rb2d.velocity.x < 0)
            {
                MoveRight();
                if (!_ballSpawner.SpawnBall(2))
                {
                    canPassSide = true;
                    MoveRight(); 
                    //PushBoundary();
                }
           
                Debug.Log("butterfly hit left sides");
            }

        }


        if (other.gameObject.name.Contains("ButterflyDes"))
        {
            speed = 2f;
            GetComponent<SpriteRenderer>().sortingOrder = 1;
         //   MoveLeft();
        }

    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.name.Contains("Pusher"))
        {
            other.GetComponent<Rigidbody2D>().velocity = new Vector2(-2, 0);
        }

        if (canPassSide)
        {
            speed = 1f;
            if (other.gameObject.name.Contains("pushable"))
            {
                other.GetComponentInParent<RotatingFrameController>().SetRotation(false);
                other.transform.DOMove(other.transform.position + transform.right*3, 2f);
            }
        }

    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (canPassSide)
        {
            if (other.gameObject.name.Contains("pushable"))
            {
                other.GetComponentInParent<RotatingFrameController>().SetRotation(true);
               // other.transform.DOMove(other.transform.position + transform.right*2, 2f);
            }
        }
    }


    public void PushBoundary()
    {
        Debug.Log("should push boundary now");
    }


    [Button]
    public void MoveLeft()
    {
        rb2d.velocity = new Vector2(-speed, 0);
    }
    
    [Button]
    public void MoveRight()
    {
        rb2d.velocity = new Vector2(speed, 0);
    }
}
