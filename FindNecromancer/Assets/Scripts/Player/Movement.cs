using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public int speed;

    Vector2 moveDirection;
    public Rigidbody2D rb;
    public Camera camera;
    float directionX;
    float directionY;

    Vector2 mousePosition;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        directionX = Input.GetAxis("Horizontal");
        directionY = Input.GetAxis("Vertical");
        moveDirection = new Vector2(directionX, directionY);
        mousePosition = camera.ScreenToWorldPoint(Input.mousePosition);

    }

    public void FixedUpdate()
    {
        Move();
    }
    public void Move()
    {
        rb.MovePosition(rb.position + moveDirection * speed * Time.fixedDeltaTime);

        Vector2 rotateDirection = mousePosition - rb.position;
        float angle = Mathf.Atan2(rotateDirection.y, rotateDirection.x) * Mathf.Rad2Deg + 90f;
        rb.rotation = angle;
    }


}
