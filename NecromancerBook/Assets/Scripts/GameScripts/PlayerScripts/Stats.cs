using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour
{
   public LifeResources health;
   public LifeResources mana;

   public string playerName;

   
   
   
    public void Heal(float _amount, float _duration)
    {
        StartCoroutine(health.IncreaseOverTime(_amount, _duration));
    }

    public void RegenMana(float _amount, float _duration)
    {
        StartCoroutine(mana.IncreaseOverTime(_amount, _duration));
    }

    public void Damage(float _amount, float _duration)
    {
        StartCoroutine(health.DecreaseOverTime(_amount, _duration));
    }

    public void ReduceMana(float _amount, float _duration)
    {
        StartCoroutine(mana.DecreaseOverTime(_amount, _duration));
    }
   public void Update()
   {
       health.AdjustValues();
       mana.AdjustValues();
   }
}
