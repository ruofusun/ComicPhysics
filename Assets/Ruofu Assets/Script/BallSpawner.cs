using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{

    public GameObject ball;
    public float duration = 10f;

    public int BallCount = 15;

    private int currentBallCount = 0;
    private ShadowController _shadowController;

    // Start is called before the first frame update
    void Start()
    {
      //  StartCoroutine(SpawnBallRoutine());
      _shadowController = FindObjectOfType<ShadowController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private float t = 0;
    public IEnumerator SpawnBallRoutine()
    {
        while (t<duration)
        {
            t += 4f;
            Instantiate(ball, transform.position+ new Vector3(Random.Range(-7,7), 0,-0.15f), Quaternion.identity);
            yield return new WaitForSeconds(4f);
        }

        yield break;
    }

    public bool SpawnBall(int count)
    {
        if (currentBallCount >= BallCount || _shadowController.CurrentLevel == 0) 
            return false;
 
        for (int i = 0; i < count; i++)
        {
           // Instantiate(ball, transform.position+ new Vector3(Random.Range(-5,5), 0,ball.transform.position.z), Quaternion.identity);
           StartCoroutine(SpawnBallTimeRoutine());
        }
        currentBallCount += count;
        return true;
    }
    
    public IEnumerator SpawnBallTimeRoutine()
    {
     
            Instantiate(ball, transform.position+ new Vector3(Random.Range(-23,23), 0,ball.transform.position.z), Quaternion.identity);
            yield return new WaitForEndOfFrame();
    }
    
    
    
    
}
