using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDetector : MonoBehaviour
{
   public GameObject detection;
   public SpellBook spellBook;

   public void Start()
   {
       spellBook = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<SpellBook>();
   }

   void OnTriggerEnter2D(Collider2D other)
   {
       if(other.gameObject.tag != "Player")
       {
            gameObject.GetComponent<Animator>().SetBool("Hit", true);
            gameObject.transform.SetParent(other.transform);
            gameObject.GetComponent<Rigidbody2D>().velocity *= 0;
            
            if(other.gameObject.tag == "Enemy")
            {
                spellBook.Damage(other.gameObject);
                Debug.Log("Spell hited an enemy!!!");
            }
       }
       
   }
}
