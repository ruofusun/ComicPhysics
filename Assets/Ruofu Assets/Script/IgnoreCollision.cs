using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IgnoreCollision : MonoBehaviour
{

    public List<Collider2D> colsToIgnore;

    private Collider2D mycol;
    // Start is called before the first frame update
    void Start()
    {
        mycol = GetComponent<Collider2D>();
        if (colsToIgnore.Count > 0)
        {
            foreach (var col in colsToIgnore)
            {
                Physics2D.IgnoreCollision(mycol, col);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
