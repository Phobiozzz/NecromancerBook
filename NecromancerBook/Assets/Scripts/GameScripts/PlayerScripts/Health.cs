using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health
{
    public HPBar healthBar;
    public int globesMaxCount;
    public int globesCount;
    public int lastActiveGlobe;
    public float playerCurHp;
    public float playerMaxHp;
    
    public void Awake()
    {
        healthBar = GameObject.Find("HPBar").GetComponent<HPBar>();
        globesCount = 0;
        globesMaxCount = 5;
        AddNewGlobe();
        playerCurHp = playerMaxHp;
        lastActiveGlobe = 0;
    }
    
    public void AddNewGlobe()
    {
        if(globesCount < globesMaxCount)
        {
            globesCount ++;
            lastActiveGlobe ++;
            healthBar.AddGlobe();
            CalculatePlayerMaxHp();
            
            Debug.Log("There is a " + globesCount + "globes now.");
        }
        else if(globesCount > globesMaxCount)
        {
            Debug.Log("Cannot create new globe. HP bar is full now. ");
        }
    }

    public void DeleteGlobe()
    {
        if(globesCount > 0)
        {
            globesCount --;
            lastActiveGlobe --;
            CalculatePlayerMaxHp();
        }
        else if (globesCount <= 0)
        {
            Debug.Log("HP bar is empty. cannot delete globe");
        }
    }
    public void CalculatePlayerMaxHp()
    {
        playerMaxHp = globesCount * 20;
        playerCurHp = playerMaxHp;
    }

    public void TakeDamage(float dmg )
    {
        playerCurHp -= dmg;
        Globe globeToDmg = healthBar.globes[lastActiveGlobe].GetComponent<Globe>();
        globeToDmg.TakeDamage(dmg);
        if(globeToDmg.isEmpty)
        {
            if(lastActiveGlobe > 0)
            {
                lastActiveGlobe --;
            globeToDmg = healthBar.globes[lastActiveGlobe].GetComponent<Globe>();
            globeToDmg.TakeDamage(dmg);
            }
            
        }
    }


}
