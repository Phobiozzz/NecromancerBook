using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{

    public Transform playerPosition;

    public float attackDistance;
    public float moveSpeed;

    public Rigidbody2D rb;


    public void Awake()
    {
        moveSpeed = 1;
        attackDistance = 0.6f;
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Chase();
    }

    public void Chase()
    {
        playerPosition = GameObject.FindGameObjectWithTag("Player").transform;

        float distance = Vector3.Distance(playerPosition.position, gameObject.transform.position);
        if (distance > attackDistance)
        {
            if (playerPosition.position.x > transform.position.x)
            {
                rb.velocity = new Vector2(moveSpeed, 0);
                transform.localScale = new Vector2(1, 1);
            }

            else if (playerPosition.position.x < transform.position.x)
            {
                rb.velocity = new Vector2(-moveSpeed, 0);
                transform.localScale = new Vector2(-1, 1);
            }
        }
        else
        {
            print("Attacking!!!");
        }
    }
}
