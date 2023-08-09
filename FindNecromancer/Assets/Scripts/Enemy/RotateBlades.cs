using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateBlades : MonoBehaviour
{
    
    public int speed;
    public int damage;
   

    public void Update()
    {   
      transform.Rotate(0, 0, -360 * speed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision != null)
        {
            if (collision.transform.tag == "Player")
            {
                collision.gameObject.GetComponent<PlayerStats>().TakeDamage(damage);
            }
        }
    }
}

