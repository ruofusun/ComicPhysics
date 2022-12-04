using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class ButterflyController : MonoBehaviour
{
    public Transform des1;
    public Transform des2;
    public Transform des3;
    
    // Start is called before the first frame update
    void Start()
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

        //  transform.DOMove(des1.position, 3f);
        //   transform.DOMove(des2.position, 3f);
        //  transform.DOMove(des3.position, 3f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
