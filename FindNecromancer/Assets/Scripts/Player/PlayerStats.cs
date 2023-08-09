using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public int maxHealth;
    public int currentHealth;
    Animator animator;

    public void Start()
    {
        currentHealth = maxHealth;
        animator = GetComponent<Animator>();
    }


    public void TakeDamage(int _damage)
    {
        animator.SetTrigger("TakeDamage");
        if (currentHealth > 0)
        {
            
            currentHealth -= _damage;
            Debug.Log("Was kikced by monster");
        }
        else
        {
            Destroy(gameObject);
        }
         
    }

   
}
