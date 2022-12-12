using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CapsuleCollider2D))]
public class PlayerController : MonoBehaviour
{
    // Move player in 2D space
    public float maxSpeed = 3.4f;
    public float jumpHeight = 6.5f;

    public float gravityScale = 1.5f;
    //  public Camera mainCamera;

    bool facingRight = true;
    float moveDirection = 0;
    bool isGrounded = false;
    Vector3 cameraPos;
    Rigidbody2D r2d;
    CapsuleCollider2D mainCollider;
    Transform t;
    private Animator anim;
    public AudioSource walkaudiosource;

    // public Text speedText;

    // public TextMeshPro speedText;
    public TextMeshProUGUI speedText;

    // Use this for initialization
    void Start()
    {
        t = transform;
        r2d = GetComponent<Rigidbody2D>();
        mainCollider = GetComponent<CapsuleCollider2D>();
        r2d.freezeRotation = true;
        r2d.collisionDetectionMode = CollisionDetectionMode2D.Continuous;
        r2d.gravityScale = gravityScale;
        facingRight = t.localScale.x > 0;
        anim = GetComponent<Animator>();

        /*   if (mainCamera)
           {
               cameraPos = mainCamera.transform.position;
           }*/
    }

    // Update is called once per frame
    void Update()
    {
        // Movement controls
        if ((Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow)) &&
            (isGrounded || Mathf.Abs(r2d.velocity.x) > 1))
        {
            moveDirection = Input.GetKey(KeyCode.LeftArrow) ? -1 : 1;
        }
        else
        {
            if (isGrounded || r2d.velocity.magnitude < 1f)
            {
                moveDirection = 0;
            }
        }

        // Change facing direction
        if (moveDirection != 0)
        {
            if (moveDirection > 0 && !facingRight)
            {
                facingRight = true;
                t.localScale = new Vector3(Mathf.Abs(t.localScale.x), t.localScale.y, transform.localScale.z);
                speedText.rectTransform.localScale = new Vector3(Mathf.Abs(speedText.rectTransform.localScale.x),
                    speedText.rectTransform.localScale.y, speedText.rectTransform.localScale.z);
            }

            if (moveDirection < 0 && facingRight)
            {
                facingRight = false;
                t.localScale = new Vector3(-Mathf.Abs(t.localScale.x), t.localScale.y, transform.localScale.z);
                speedText.rectTransform.localScale = new Vector3(Mathf.Abs(-speedText.rectTransform.localScale.x),
                    speedText.rectTransform.localScale.y, speedText.rectTransform.localScale.z);
            }
        }

        // Jumping
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            SetJumpAnimationBasedOnMoveDirection();
            // walkaudiosource.Stop();
            r2d.velocity = new Vector2(r2d.velocity.x * 0.3f, jumpHeight);

        }

        // Camera follow
        /*   if (mainCamera)
           {
               mainCamera.transform.position = new Vector3(t.position.x, cameraPos.y, cameraPos.z);
           }
   */
        if (speedText)
        {
            speedText.text = r2d.velocity.x.ToString("0.00");
        }
    }

    void FixedUpdate()
    {

        float colliderRadiusY = mainCollider.size.y * 0.6f * Mathf.Abs(transform.localScale.y);
        RaycastHit2D hitGround = Physics2D.Raycast(transform.position - transform.up * colliderRadiusY, transform.right,
            0.5f, 1 << LayerMask.NameToLayer("Ground"));
        RaycastHit2D hitPropsLeft = Physics2D.Raycast(transform.position - transform.up * colliderRadiusY,
            -transform.right, 1.5f, 1 << LayerMask.NameToLayer("Props"));
        RaycastHit2D hitPropsRight = Physics2D.Raycast(transform.position - transform.up * colliderRadiusY,
            transform.right, 1.5f, 1 << LayerMask.NameToLayer("Props"));

        isGrounded = false;
        if (hitGround.collider || hitPropsLeft.collider || hitPropsRight.collider)
        {
            isGrounded = true;
        }

        // Apply movement velocity
        r2d.AddForce(new Vector2((moveDirection) * maxSpeed * r2d.mass, r2d.velocity.y * r2d.mass), ForceMode2D.Force);
        anim.SetFloat("Speed", Mathf.Abs(r2d.velocity.x));
        anim.SetFloat("VerticalSpeed", r2d.velocity.y);
        if (Mathf.Abs(r2d.velocity.x) >1.2&&isGrounded&&moveDirection!=0)
        {
            if(!walkaudiosource.isPlaying)
          walkaudiosource.Play();
        }
        else
        {
            walkaudiosource.Stop();
        }

        // SoundManager.Instance.PlaySoundEffect(SoundManager.Instance.walking);
            // r2d.velocity = new Vector2((moveDirection) * maxSpeed, r2d.velocity.y);
            // Simple debug
            //  Debug.DrawLine(groundCheckPos, groundCheckPos - new Vector3(0, colliderRadiusX, 0), isGrounded ? Color.green : Color.red);
            Debug.DrawLine(transform.position - transform.up * colliderRadiusY,
                transform.position - transform.up * colliderRadiusY + transform.right * 1.5f,
                isGrounded ? Color.green : Color.red);
            Debug.DrawLine(transform.position - transform.up * colliderRadiusY,
                transform.position - transform.up * colliderRadiusY - transform.right * 1.5f,
                isGrounded ? Color.cyan : Color.yellow);
        
    }

    public void SetJumpAnimationBasedOnMoveDirection()
    {
        if (moveDirection!=0)
        {
            anim.ResetTrigger("JumpUp");
            anim.SetTrigger("Jump");
        }
        else
        {
            anim.ResetTrigger("Jump");
            anim.SetTrigger("JumpUp");
        }
    }
}
