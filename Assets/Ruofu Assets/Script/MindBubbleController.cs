using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using Sirenix.OdinInspector;
using UnityEngine;

public class MindBubbleController : MonoBehaviour
{
    private List<Rigidbody2D> rb2ds;
    public Rigidbody2D centerRB;

    public Transform destination;

    public float duration;
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
       centerRB.gravityScale = -0.6f;

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
            centerRB.gravityScale = -1.2f;
        }
    }
}
