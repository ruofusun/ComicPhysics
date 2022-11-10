using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MindBubbleController : MonoBehaviour
{
    private List<Rigidbody2D> rb2ds;
    public Rigidbody2D centerRB;

    public Transform destination;
    // Start is called before the first frame update
    void Start()
    {
        rb2ds = GetComponentsInChildren<Rigidbody2D>().ToList();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MoveToDesiredPosition()
    {
       
    }
}
