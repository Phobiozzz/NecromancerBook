using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Movement : MonoBehaviour
{
    public ParticleSystem trailParticles;
    
    public int speed;

    [Range (0, 10)]
    public int jumpPower;
    public float move;

    public Rigidbody2D rb;

    public bool isJumping;
    public bool isMoving;
    public bool isLookingRight = true;

    public Animator animator;

    public bool isAlive;

    bool canMove;
    private void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        animator = gameObject.GetComponent<Animator>();
        isJumping = true;
        isAlive = true;
        isLookingRight = true;
        speed = 1;
        jumpPower = 4;
    }

    void Run(float move)
    {
        // Input.GetAxis("Horizontal");

            if (move != 0)
            {
                isMoving = true;
                if (move > 0)
                {
                    move = 1;
                }
                else if (move < 0)
                {
                    move = -1;
                }
                Vector3 horizontal = new Vector3(move, 0.0f, 0.0f);
                transform.position = transform.position + horizontal * speed * Time.deltaTime;

            }
            else
            {
                isMoving = false;
            }
  
    }

    void Jump()
    {
        if (CrossPlatformInputManager.GetAxis("Vertical" ) > 0.6)
        {
            if (isJumping != true)
            {
                rb.velocity = Vector2.up * jumpPower;
            }
  
        }

        
    }

    void Flip()
    { 
        isLookingRight = !isLookingRight;
        transform.Rotate(0,180,0);
    }
        
    public void Attack()
    {

        animator.SetTrigger("Attacking");

    }


    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.transform.tag == "Ground")
        {
            isJumping = false;
            Debug.Log("isGrounded");
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        isJumping = true;
    }

    
    public void Animate()
    {

        if (isAlive)
        {
            animator.SetFloat("Speed", Mathf.Abs(move));
            animator.SetBool("isJumping", isJumping);
        }
        else if(isAlive == false)
        {
            Debug.Log("Player died");
            
            animator.SetBool("isDead", true);
            //animator.SetTrigger("isdead");
            
        }
    }
    void Update()
    {
        if (isAlive)
        {
            if(move < 0 && isLookingRight){Flip();}
            if(move > 0 && !isLookingRight){Flip();}

            if (this.animator.GetCurrentAnimatorStateInfo(0).IsName("mainAttack"))
            {
                canMove = false;
                Debug.Log("Player cannot move cose hes attacking");
            }
            else
            {
                canMove = true;
            }

            if (canMove)
            {
                Jump();
            }

        }
    }

    public void FixedUpdate()
    {
        move = CrossPlatformInputManager.GetAxis("Horizontal"); 
        if (isAlive)
        {
            if (canMove)
            {
                Run(move);

                if (isMoving)
                {
                    if (!isJumping)
                        trailParticles.Play();
                    else if (isJumping)
                    {
                        trailParticles.Stop();
                    }

                }
                else if (!isMoving)
                {
                    trailParticles.Stop();
                }
            }
        }
       
        Animate();
       
    }
}
