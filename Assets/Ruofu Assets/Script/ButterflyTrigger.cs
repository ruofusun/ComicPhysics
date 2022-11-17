using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class ButterflyTrigger : MonoBehaviour
{
    public float WaitTime = 4f;

    public Vector3 Dir = new Vector3(1, 0, 0);

    private ButterflyController butterfly;
    // Start is called before the first frame update
    void Start()
    {
        butterfly = FindObjectOfType<ButterflyController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            StartCoroutine(ButterflyMoveRoutine());
        }
    }
    
    IEnumerator ButterflyMoveRoutine()
    {
        
        yield return new WaitForSeconds(WaitTime);
     butterfly.transform.DOMove(butterfly.transform.position+ Dir* 5, 1.5f);
      

        
        
    }
    
}
