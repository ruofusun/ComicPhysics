using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushroomController : MonoBehaviour
{
    public int speedBounce = 60;
    public int speedInward = 30;
    public Rigidbody2D centerRB;

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
           // speedInward = 300;
           centerRB.AddForce(Vector2.down * speedInward);
           Debug.Log("player enter mushroom");
        }

    }

    void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * speedBounce, ForceMode2D.Impulse);
            Debug.Log("player leave mushroom");
        }
    
    }
}