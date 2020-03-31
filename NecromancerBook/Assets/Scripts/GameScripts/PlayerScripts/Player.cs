using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
public class Player : MonoBehaviour
{
    Animator animator;
    public string PlayerName;

    public float curHP;
    public float maxHP;

    public float curMP;
    public float maxMP;

    public float curBones;

    

    public void Awake()
    {
        
        animator = gameObject.GetComponent<Animator>();
        name = gameObject.name;
    }

   

    public void TakeDamage(float dmg)
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            animator.SetTrigger("Hit");
            curHP -= dmg;
        }
        
    }

    public void Death()
    {
        
        gameObject.GetComponent<Movement>().isAlive = false;
        Debug.Log("Hero is dead");
       
    }

    public void AdjustHp()
    {
        if (curHP > maxHP)
        {
            curHP = maxHP;
        }
        else if (curHP < 0)
        {
            curHP = 0;

        }
        else if (curHP == 0)
        {
            Death();
        }

    }

    

    private void Update()
    {
        AdjustHp();
        
        if (Input.GetKey(KeyCode.B))
        {
            TakeDamage(5);
        }

    }
}
