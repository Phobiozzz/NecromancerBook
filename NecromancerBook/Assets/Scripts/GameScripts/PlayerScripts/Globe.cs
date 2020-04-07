using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Globe : MonoBehaviour
{
    public bool isEmpty;
    public bool isActive;

    Animator animator;

    public float curHp;
    public float maxHp;
    
    public void Awake()
    {
        animator = GetComponent<Animator>();
        isActive = true;
        isEmpty = false;
        curHp = 20;
        maxHp = 20;
    }

    public void AdjustHp()
    {
        if(isActive)
        {
            isEmpty = false;
            if(curHp>= maxHp)
            {
                curHp = maxHp;
            }
            else if(curHp <= 0)
            {
                curHp = 0;
                isEmpty = true;
            }

        }
        
    }

    public void SetupAnimation()
    {
        if(curHp <= maxHp && curHp > maxHp*2/3)
        {
            animator.SetInteger("ClipIndex", 0);
        }
        else if(curHp <= maxHp*2/3 && curHp > maxHp /3)
        {
            animator.SetInteger("ClipIndex", 1);
        }
        else if (curHp <= maxHp/3 && curHp > 0)
        {
            animator.SetInteger("ClipIndex", 2);
        }
        else if(curHp <= 0)
        {
            animator.SetInteger("ClipIndex", 3);
        }
    }
    
    public void TakeDamage(float dmg)
    { 
        curHp -= dmg;
        SetupAnimation();
    }

    public void Update()
    {
        AdjustHp();
    }
}
