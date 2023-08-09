using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum State
{
    Idle, Patroling,Return, Chasing, RunningAway, Hited, Attacks, Dead
}
public class EnemyAI : MonoBehaviour
{
    
    Rigidbody2D rb;
    GameObject player;
    Collider2D ownCollider;
    public State currentState;
    Animator anim;
    Vector2 startPosition;
    public float attackDistance;
    public float acceptibleDistance;
    public float initialSpeed;

    float distanceToPlayer;
    

    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
        ownCollider = GetComponent<Collider2D>();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        currentState = State.Idle;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        distanceToPlayer = Vector2.Distance(transform.position, player.transform.position);
        
        Behaviour();
    }

    private void FixedUpdate()
    {
        Vector2 rayDirection = player.transform.position - transform.position;
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, rayDirection, 7f);
        Color rayColor = Color.black;
        if (hitInfo.collider != null)
        {
            if (hitInfo.collider.gameObject.tag == "Player")
            {
                rayColor = Color.white;
                currentState = State.Chasing;
            }
            else
            {
                currentState = State.Return;
                rayColor = Color.red;
            }
            Debug.DrawLine(transform.position, rayDirection, rayColor);
            Debug.Log("Hitted " + hitInfo.collider.tag);
        }
        
    }

    public void Behaviour()
    {
            bool move = false;
            float currentSpeed = 1;

            switch (currentState)
            {
                case State.Chasing:
                    if (distanceToPlayer >= attackDistance)
                    {
                        move = true;
                    }
                    else
                    {
                        move = false;
                    }
                    currentSpeed = initialSpeed;
                    break;
                case State.RunningAway:
                    if (distanceToPlayer < acceptibleDistance)
                    {
                        move = true;
                    }
                    else
                    {
                        move = false;
                    }
                    currentSpeed = initialSpeed * -2;
                    break;
                case State.Return:
                    currentSpeed = initialSpeed * 1.5f;
                    transform.position = Vector2.MoveTowards(transform.position, startPosition, currentSpeed * Time.deltaTime);
                    break;
            case State.Dead:
                Destroy(gameObject);
                break;

            }
            if (move)
                transform.position = Vector2.MoveTowards(transform.position, player.transform.position, currentSpeed * Time.deltaTime);

        Debug.Log(currentState);
        
       
    }

    
}
