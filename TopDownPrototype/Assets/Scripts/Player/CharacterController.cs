using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public int speed;
    Vector2 velocity;
    Rigidbody2D rigidbody2D;

    public void Awake()
    {
        rigidbody2D = gameObject.GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Vector2 moveDirection = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        velocity = moveDirection.normalized * speed;

    }

    private void FixedUpdate()
    {
        rigidbody2D.MovePosition(rigidbody2D.position + velocity * Time.fixedDeltaTime);
    }
}
