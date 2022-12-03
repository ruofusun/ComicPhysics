using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushroomController : MonoBehaviour
{
    public int speedBounce = 60;
    public int speedInward = 30;
    public Rigidbody2D centerRB;
    public float playerJumpBooster = 1.2f;
    public bool isSpecial = false;

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
           // speedInward = 300;
           if(centerRB)
           centerRB.AddForce(Vector2.down * speedInward);
           Debug.Log("player enter mushroom");
           
           if (isSpecial)
           {
               Rigidbody2D playerRB = other.gameObject.GetComponent<Rigidbody2D>();
               playerRB.velocity = transform.up * playerJumpBooster *playerRB.GetComponent<PlayerController>().jumpHeight;
               
           }
        }

   

    }

    void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Rigidbody2D playerRB = other.gameObject.GetComponent<Rigidbody2D>();
            if (transform.parent != null)
            {
                playerRB.velocity = transform.parent.up * playerJumpBooster *playerRB.GetComponent<PlayerController>().jumpHeight;
            }
        

            //  new Vector2(0,playerRB.GetComponent<PlayerController>().jumpHeight*playerJumpBooster);
            Debug.Log("player leave mushroom");
        }
    
    }

    public void MushroomShow()
    {
        centerRB.AddForce(-transform.parent.up  * 1, ForceMode2D.Impulse);

    }

    public void MushroomHide()
    {
        
    }
}