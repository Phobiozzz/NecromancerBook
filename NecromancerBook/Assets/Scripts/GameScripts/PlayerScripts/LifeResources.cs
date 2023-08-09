using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeResources
{
   public float currentValue;
   public float maxValue;

   public void AdjustValues()
   {
       if(currentValue <= 0)
       {
           currentValue = 0;
       }
       else if(currentValue >= maxValue)
       {
           currentValue = maxValue;
       }
   }

    
   public IEnumerator IncreaseOverTime(float _increaseAmount, float _increaseTime)
   {
       Debug.Log("StartedHealing");
       float increased = 0;
       float perLoop = _increaseAmount/ _increaseTime;
       while(increased < _increaseAmount)
       {
           increased += perLoop;
           yield return new WaitForSeconds(1f);
       }
   }

   public IEnumerator DecreaseOverTime(float _decreaseAmount, float _decreaseTime)
   {
       float decreased = 0;
       float perLoop = _decreaseAmount/_decreaseTime;
       while(decreased < _decreaseAmount)
       {
           decreased += perLoop;
           yield return new WaitForSeconds(1f);
       }
   }
}
