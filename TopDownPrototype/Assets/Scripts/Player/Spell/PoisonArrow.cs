using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoisonArrow : MonoBehaviour
{
    Rigidbody2D rb;
    public int speed;
    public int damage;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
        rb.AddForce(transform.up * speed, ForceMode2D.Impulse);
        Destroy(gameObject, 2f);
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag != "Spell" && collision.transform.tag != "Spawner" && collision.transform.tag != "Player")
        {
            if (collision.transform.tag == "Enemy")
            {
                collision.gameObject.GetComponent<EnemyStats>().TakeDamage(damage);
            }
            Destroy(gameObject);
        }
    }
}
