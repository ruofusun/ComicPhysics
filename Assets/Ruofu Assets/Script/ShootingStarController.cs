using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingStarController : MonoBehaviour
{
    public List<GameObject> shootingStars;

    public float interval = 7f;

    private float timer = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > interval)
        {
            foreach (var star in shootingStars)
            {
                star.SetActive(false);
            }
            timer = 0;
            int rand = Random.Range(0, shootingStars.Count);
            {
                shootingStars[rand].SetActive(true);
            }

        }

    }
}
