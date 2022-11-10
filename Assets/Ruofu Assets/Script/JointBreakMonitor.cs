using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JointBreakMonitor : MonoBehaviour
{
    public MindBubbleController mindBubbleController;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnJointBreak2D(Joint2D brokenJoint)
    {
        mindBubbleController.StartMoving();
    }
}
