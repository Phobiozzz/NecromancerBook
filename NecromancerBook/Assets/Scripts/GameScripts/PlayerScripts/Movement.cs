using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Movement : MonoBehaviour
{
    public ParticleSystem trailParticles;

    public float speed;

    [Range (0, 10)]
    public float jumpPower;
    public float move;

    public float fallMultiplier;
    public float lowJumpMultiplier;
    public Rigidbody2D rb;


    public bool isJumping;
    public bool isMoving;
    public bool isLookingRight;

    public Animator animator;

    public bool isAlive;

    public float CoolDownCounter;
    bool canAttack;
    bool canMove;
    private void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        animator = gameObject.GetComponent<Animator>();
        isLookingRight = true;
        isJumping = true;
        isAlive = true;
    }

    void Run()
    {
        move = CrossPlatformInputManager.GetAxis("Horizontal"); // Input.GetAxis("Horizontal");

            if (move != 0)
            {
                isMoving = true;
                if (move > 0)
                {
                    move = 1;
                    isLookingRight = true;
                }
                else if (move < 0)
                {
                    move = -1;
                    isLookingRight = false;
                }

                
                Vector3 horizontal = new Vector3(move, 0.0f, 0.0f);
                transform.position = transform.position + horizontal * speed * Time.deltaTime ;

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
       
        Vector3 characterScale = transform.localScale;
        
        if (isLookingRight != true)
        {
            characterScale.x = -1;
        }
        else if (isLookingRight == true)
        {
            characterScale.x = 1;
        }
        transform.localScale = characterScale;
        
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
            //Debug.Log("isGrounded");
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

    public void SetCoolDownCounter()
    {
        CoolDownCounter -= 1 * Time.deltaTime;

        if (CoolDownCounter <= 0)
        {
            CoolDownCounter = 0;
            canAttack = true;
        }
        else
        {
            canAttack = false;
        }
    }

    void Update()
    {
        if (isAlive)
        {
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
            
            Flip();

            SetCoolDownCounter();


            if (CrossPlatformInputManager.GetButtonDown("Fire"))
            {
                if (canAttack)
                {
                    Attack();
                    CoolDownCounter += 0.5f;
                }

            }
        }
    }

    public void FixedUpdate()
    {
        if (isAlive)
        {
            if (canMove)
            {
                Run();

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
