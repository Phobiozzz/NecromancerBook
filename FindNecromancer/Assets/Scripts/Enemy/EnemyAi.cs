using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAi : MonoBehaviour
{
    public Transform target;
    public float speed;
    public float attackDistance;
    public Animator animator;
    public int healthMax;
    int curHealth;
    Transform player;
    

    public bool isAlive;
    public bool canMove;
    public float damageDuration = 0.383f;
    public float takingDamageCounter;

    public void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        target = player;
        speed = Random.Range(0.5f, 1.5f);
        isAlive = true;
        curHealth = healthMax;
        takingDamageCounter = damageDuration;

    }
    public void FixedUpdate()
    {
        
        if (takingDamageCounter > 0)
        {
            takingDamageCounter -= Time.fixedDeltaTime;
            canMove = false;
        }
        else if (takingDamageCounter <= 0)
        {
            canMove = true;
        }

        if (isAlive && canMove)
        {
            Chase();
        }
    }

    public void Chase()
    {
       
        if (Vector2.Distance(transform.position, target.position) > attackDistance)
        {
            //animator.SetBool("Attack", true);
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.fixedDeltaTime);
        }
    }

    public void TakeDamage(int dmg)
    {
        takingDamageCounter = damageDuration;
        curHealth -= dmg;
        animator.SetTrigger("TakingDamage");
        if (curHealth <= 0 && isAlive)
        {
            Death();
            isAlive = false;
        }
    }

    public void Death()
    {
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Rigidbody2D rb = gameObject.GetComponent<Rigidbody2D>();
        }
    }

}
