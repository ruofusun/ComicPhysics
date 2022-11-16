using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Playables;

public class MindBubbleController : MonoBehaviour
{
    private List<Rigidbody2D> rb2ds;
    public Rigidbody2D centerRB;

    public Transform destination;

    public float duration;

    public PlayableDirector endPlayableDirector;

    public float addJumpForce;

    private bool PlayerOnBubble = false;
    // Start is called before the first frame update
    void Start()
    {
        rb2ds = GetComponentsInChildren<Rigidbody2D>().ToList();
    }

    // Update is called once per frame
    void Update()
    {
      
        
    }

    [Button]
    public void StartMoving()
    {
       // centerRB.DOMove(destination.position, duration).OnComplete(OnTweenComplete);
       /* foreach (var rb2d in rb2ds)
        {
            rb2d.gravityScale = -0.05f;
        }
*/
       centerRB.gravityScale = -0.4f;

    }
    


    public void OnTweenComplete()
    {
        foreach (var rb2d in rb2ds)
            {
                rb2d.gravityScale = 0f;
            }
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            PlayerOnBubble = true;
            centerRB.gravityScale = -1.4f;
            Debug.Log("change gravity here");
            endPlayableDirector.Play();
            Rigidbody2D rb2d = other.gameObject.GetComponent<Rigidbody2D>();
            if (rb2d )
            {
                rb2d.AddForce(new Vector2(0, addJumpForce), ForceMode2D.Impulse);
                Debug.Log("add force to player here");
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            PlayerOnBubble = false;
        }
    }


    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            PlayerOnBubble = true;
            Rigidbody2D rb2d = other.gameObject.GetComponent<Rigidbody2D>();
            if (rb2d )
            {
                rb2d.AddForce(new Vector2(0, addJumpForce), ForceMode2D.Impulse);
                Debug.Log("add force to player here");
            }
        }
    }
}
