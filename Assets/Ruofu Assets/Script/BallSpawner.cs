using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{

    public GameObject ball;
    public float duration = 10f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnBallRoutine());
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
            Instantiate(ball, transform.position+ new Vector3(Random.Range(-5,5), 0,0), Quaternion.identity);
            yield return new WaitForSeconds(4f);
        }

        yield break;
    }
}
