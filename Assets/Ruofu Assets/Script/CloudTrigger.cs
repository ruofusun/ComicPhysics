using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudTrigger : MonoBehaviour
{
    public List<CloudController> clouds;
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
        if (other.gameObject.tag == "Player")
        {
            foreach (var cloud in clouds)
            {
                CloudController cloudController = cloud.GetComponent<CloudController>();
                if (cloudController.verticleCloud)
                {
                    cloudController.StartMoving();
                }
                else
                {
                    cloudController.StartMoveHorizontal();
                }
            }
        }
    }
}
