using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellBook : MonoBehaviour
{
   public GameObject player;
   public SpellObject[] spells;

   public int castingSpell;
   public Transform castPoint;
   public GameObject spellPrefab;
   public bool paid;
   public bool isActive;
   int paycounter;
    
   public void Start()
   {
      paid = false;
      isActive = false;
   }
   public void Cast(int _castindSpellIndex)
   {
      castingSpell = _castindSpellIndex;
      SpellObject cS = spells[_castindSpellIndex];
      CastType castType = cS.castType;
      SpellType spellType = cS.spellType;
      
      
      SetCastingPosition(castType);
      ChargeCost(cS.manaCost, cS.healthCost, cS.bonesCost);
      if(paid == true)
      {
         ApllyEffect(cS);
         paid = false;
      }
      else
      {
         paid = false;
         Debug.Log("You not paid for this spell!");
      }
   }

   public void SetCastingPosition(CastType _castType)
   {
      if(_castType == CastType.Range)
      {
         castPoint = transform;
      }
      else
      {
         castPoint = player.transform;
      }
   }
   public void ChargeCost(float _manaCost, float _healthCost, float _boneCost)
   {
      Player playerInfo = player.GetComponent<Player>();
      paycounter = 0;
      if(playerInfo.curMP >= _manaCost)
      {
         playerInfo.curMP -= _manaCost;
         paycounter ++;
      }
      else
      {
         paycounter--;
         Debug.Log("not enougth mana");
      }

      if(playerInfo.curHP >= _healthCost)
      {
         playerInfo.curHP -= _healthCost;
         paycounter ++;
      }
      else
      {
         paycounter --;
      }
   
      if(playerInfo.curBones >= _boneCost)
      {
         playerInfo.curBones -= _boneCost;
         paycounter ++;
      }
      else
      {
         Debug.Log("Not enougth bones to cast this spell");
         paycounter--;
      }

      if(paycounter == 3)
      {
         paid = true;
      }
      else
      {
         paid = false;
      }
      paycounter =0;
   }

   public void ApllyEffect(SpellObject _spellInfo)
   {
      GameObject spell = Instantiate(spellPrefab,castPoint.position, castPoint.rotation);
      if(_spellInfo.castType == CastType.Range)
      {
         Rigidbody2D rb = spell.AddComponent<Rigidbody2D>();
         TriggerDetector trigger = spell.AddComponent<TriggerDetector>();
         spell.GetComponent<Animator>().runtimeAnimatorController = _spellInfo.Animator;
         rb.gravityScale = 0;
         rb.freezeRotation = true;
         rb.velocity = spell.transform.right * _spellInfo.speed;
      }
      else if(_spellInfo.castType == CastType.Self)
      {
         if(isActive == false)
         {
            spell.transform.SetParent(player.transform);
            spell.transform.localPosition = new Vector3(-0.053f, -0.041f, 0);
            spell.GetComponent<Animator>().runtimeAnimatorController =_spellInfo.Animator;
            ManaBuff(player, _spellInfo.power, _spellInfo.lifeTime);
         } 
         else
         {
            Debug.Log("you already have a buff now!!");
         }
      }
      Destroy(spell, _spellInfo.lifeTime);
   }

   public void ChargeResource(float _curRes, float _needRes)
   {
      if(_curRes >= _needRes)
      {
         _curRes -= _needRes;
      }
      else
      {
         Debug.Log("Not enought resource to cast spell");
      }
   }
   public void Damage(GameObject _enemy)
   {
      float damage = spells[castingSpell].power;
      _enemy.GetComponent<Enemy>().GetDamage(damage);
      Debug.Log("Enemy was damaged with " + damage + " amount of damage");
   }

public void ManaBuff( GameObject _target, float _spellPower, float _activeTime)
{  
   if(_target.tag == "Player")
   {
      StartCoroutine(RestoreManaOvertime(_target.GetComponent<Player>().curMP, _spellPower, _activeTime));
   }
   
}

   public void Update()
   {
      if(paycounter<=0)
      {
         paycounter = 0;
      }
      if(Input.GetKeyDown(KeyCode.M))
      {
         Cast(0);
      }

      if(Input.GetKeyDown(KeyCode.H))
      {
         Cast(1);
      }
   }

   public IEnumerator RestoreManaOvertime(float _curMp, float _skillPower, float _timeAmount)
   {
      isActive = true;
      float counterRefreshed = 0f;
      float restorePerLoop = _skillPower/_timeAmount;
      while(counterRefreshed < _skillPower)
      {
         _curMp +=restorePerLoop;
         counterRefreshed += restorePerLoop;
         yield return new WaitForSeconds(1f);
      }
      isActive = false;
   }
}
