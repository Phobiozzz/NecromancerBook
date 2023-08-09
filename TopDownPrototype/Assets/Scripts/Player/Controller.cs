using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    
    public int speed;
    Rigidbody2D rb;
    public Vector2 direction;
    Vector2 velocity;
    Animator anim;
    
    public Camera cam;
    Vector2 mousePos;
    public GameObject shootingPoint;
    

    [SerializeField]
    private LayerMask dashLayerMask;

    public bool isDashingButtonDown;
    public float dashDistance;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();
       
       
    }

    // Update is called once per frame
    void Update()
    {

        direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
        velocity = direction * speed;

       

        if (Input.GetMouseButtonDown(0))
        {
            gameObject.GetComponent<SpellCasting>().CastSpell();
            anim.SetTrigger("Attack");
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            isDashingButtonDown = true;
        }
       
    }

    private void FixedUpdate()
    {
        rb.velocity = velocity;
        

        if (isDashingButtonDown)
        {
            Vector2 currentPosition = new Vector2(transform.position.x, transform.position.y);
            Vector2 dashPosition = currentPosition + direction * dashDistance;

            RaycastHit2D raycastHit2D = Physics2D.Raycast(currentPosition, direction, dashDistance, dashLayerMask);
            if (raycastHit2D.collider != null)
            {
                dashPosition = raycastHit2D.point;
                Debug.DrawRay(currentPosition, direction, Color.red, dashDistance);
            }
             
            rb.MovePosition(dashPosition);
            isDashingButtonDown = false;
        }
       
        RotateShootPoint();
    }

    public void RotateShootPoint()
    {
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        Vector2 lookDirection = mousePos - shootingPoint.GetComponent<Rigidbody2D>().position;
        float angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg - 90f;
        shootingPoint.GetComponent<Rigidbody2D>().rotation = angle;
        shootingPoint.transform.position = transform.position;
    }

    
}
