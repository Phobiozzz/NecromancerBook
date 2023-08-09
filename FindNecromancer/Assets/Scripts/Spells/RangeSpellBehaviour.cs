using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeSpellBehaviour : MonoBehaviour
{
    public ParticleSystem destroyEffect;
    public int damage;
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision != null)
        {
            if (collision.gameObject.tag == "Destructable")
            {
                Destroy(collision.gameObject);
                
            }
            else if (collision.gameObject.tag == "Enemy")
            {
                collision.gameObject.GetComponent<EnemyAi>().TakeDamage(damage);
                
            }
            Debug.Log("Spell attacked " + collision.transform.tag);
            ParticleSystem effect = Instantiate(destroyEffect, transform.position, transform.rotation);
            Destroy(gameObject);
            
        }
    }
}
