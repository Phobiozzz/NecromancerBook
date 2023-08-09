using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseHero : MonoBehaviour
{
    public Transform target;
    public float speed;
    public float attackDistance;
    public Animator animator;
    
    public void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        speed = Random.Range(0.5f, 1.5f);
    }
    public void Update()
    {
        if (Vector2.Distance(transform.position, target.position) > attackDistance)
        {
            animator.SetBool("Attack", true);
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

         
        }
    }
}
