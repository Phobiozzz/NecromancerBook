using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoisonArrow : MonoBehaviour
{
    public ParticleSystem blowEffect;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision != null)
        {
            if (collision.transform.tag == "Enemy" || collision.transform.tag == "Monster")
            {
                Destroy(collision.gameObject);
            }
            Instantiate(blowEffect, transform.position, transform.rotation);
            Destroy(gameObject);
           
        }
        
    }
}
