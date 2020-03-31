using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float curHP;
    public float maxHP;

    public bool poisoned;

    public void AdjustHP()
    {
        if (curHP <= 0)
        {
            curHP = 0;
        }
        else if (curHP >= maxHP)
        {
            curHP = maxHP;
        }
    }

    public void GetDamage(float dmg)
    {
        curHP -= dmg;
    }

    IEnumerable DamageOverTimeCoroutine(float damage, float duration)
    {
        float timer = duration;

        while (timer > 0)
        {
            curHP -= damage;
            Debug.Log("enemy gets a dot " + damage + " per second. Dot will break at " + timer + "seconds");
            timer -= 1f;
            yield return new WaitForSeconds(1);
        }
    }

    public void DamageOverTime(float dmg, float time)
    {
        StartCoroutine("DamageOverTimeCoroutine",(dmg, time));
    }

    public void Death()
    {
        if (curHP == 0)
        {
            Debug.Log("Enemy is dead ");
            Destroy(gameObject, 3f);

        }
    }

    
    public void Awake()
    {
        maxHP = 100;
        curHP = maxHP;
    }



    public void Update()
    {
        AdjustHP();
        Death();
    }
}
