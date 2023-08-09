using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
public class Player : MonoBehaviour
{
    Animator animator;
    public string PlayerName;

    public Health health;
    public float curHP;
    public float maxHP;
    public float curMP;
    public float maxMP;
    public float curBones;
    public void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        PlayerName = gameObject.name;

        health = new Health();
        health.Awake();
        maxHP = health.playerMaxHp;
        curHP = health.playerCurHp;
    }

    public void TakeDamage(float dmg)
    {   
        health.TakeDamage(dmg);
        animator.SetTrigger("Hit");   
    }

    public void Death()
    {
        
        gameObject.GetComponent<Movement>().isAlive = false;
        Debug.Log("Hero is dead");
       
    }

    public void AdjustHp()
    {
        maxHP = health.playerMaxHp;
        curHP = health.playerCurHp;
        if (curHP > maxHP)
        {
          curHP  = maxHP;
        }
        else if (curHP <= 0)
        {
            curHP = 0;
            Death();
        }

    }

    private void Update()
    {
        AdjustHp();
        
        if (Input.GetKey(KeyCode.B))
        {
            TakeDamage(1);
        }

        if(Input.GetKey(KeyCode.A))
        {
            health.AddNewGlobe();
        }
    }
}
