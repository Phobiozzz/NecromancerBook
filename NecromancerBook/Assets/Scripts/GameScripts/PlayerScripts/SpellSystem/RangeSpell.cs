using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeSpell : MonoBehaviour
{
   
    float lifeTime;
    float damage;
    Rigidbody2D rigidbody;

    public void Start()
    {
       rigidbody = gameObject.GetComponent<Rigidbody2D>();
       rigidbody.gravityScale = 0;
       rigidbody.freezeRotation = true;
    }
   public void OnTriggerEnter2D(Collider2D collider)
   {
       Debug.Log("Spell power is "+ damage + ". Spell duration effect is " + lifeTime);
       if(collider.gameObject.tag != "Player")
       {
            gameObject.GetComponent<Animator>().SetBool("Hit", true);
            gameObject.transform.SetParent(collider.transform);
            Debug.Log("Spell hitted " + collider.tag);
            gameObject.GetComponent<Rigidbody2D>().velocity *= 0;
            
            if(collider.gameObject.tag == "Enemy")
            {
                collider.GetComponent<Enemy>().DamageOverTime(damage,lifeTime);
            }
       } 
   }

   public void SetupValues(float _lifeTime, float _damage)
   {
       lifeTime = _lifeTime;
       damage = _damage;
   }

}
