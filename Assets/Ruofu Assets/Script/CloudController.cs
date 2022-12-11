using System;
using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

public class CloudController : MonoBehaviour
{
    public Rigidbody2D rb2d;

    public float speed = 2;

    private bool startMoving = false;

    public bool verticleCloud = true;

    public bool moveAtStart = false;

    public float upwardsGravity = -0.4f;
    // Start is called before the first frame update
    void Start()
    {
        if (moveAtStart)
        {
         //   StartCoroutine(MoveLeftAndRight());
        }
    }

    IEnumerator MoveLeftAndRight()
    {
        while (true)
        {
            Debug.Log("should move the cloud");
            rb2d.AddForce(new Vector2(speed,0), ForceMode2D.Force);
            yield return new WaitForSeconds(2f);
            rb2d.AddForce(new Vector2(-speed*2,0), ForceMode2D.Force);
            yield return new WaitForSeconds(2f);
        }

        yield return null;
    }

    // Update is called once per frame
    void Update()
    {
        if (startMoving)
        {
            rb2d.AddForce(new Vector2(speed,0), ForceMode2D.Force);
        }
    }

    private void FixedUpdate()
    {
        if (moveAtStart)
        {
          //  rb2d.AddForce(new Vector2(speed,0), ForceMode2D.Force);
        }
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
        rb2d.gravityScale = upwardsGravity;

    }

    [Button]
    public void StartMoveHorizontal()
    {
        startMoving = true;
        //rb2d.velocity = new Vector2(1* speed, 0);
        //rb2d.AddForce(new Vector2(speed,0));
    }
}
