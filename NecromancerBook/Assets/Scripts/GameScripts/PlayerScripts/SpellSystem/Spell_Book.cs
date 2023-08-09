using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
public class Spell_Book : MonoBehaviour
{
    public GameObject player;
    public GameObject spellPrefab;
    public SpellObject[] spellBook;
    public Transform castPoint;

    public bool isCasting;

    public IEnumerator CastSpell(SpellObject _spellInfo)
    {
        SpellObject castingSpell = _spellInfo;
        isCasting =true;

        ChooseCastPoint(castingSpell.castType);

        bool paid = ChargeCost(player.GetComponent<Player>(), castingSpell.manaCost, castingSpell.healthCost, castingSpell.bonesCost);

        if (paid == true)
        {
            yield return new WaitForSeconds(0.183f);
            InstatiateSpell(castPoint, castingSpell);
        }
        else if(paid == false)
        {
            Debug.Log("You'd not paid for this spell!!");
        }
        isCasting = false;
    } 

    public void ChooseCastPoint(CastType _castType)
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

    public bool ChargeCost(Player _ResInfo, float _manaCost, float _healthCost, float _bonesCost)
    {
        return true;
    }

    public void InstatiateSpell(Transform _castPoint, SpellObject _castingSpellInfo)
    {
        GameObject spell = Instantiate(spellPrefab, _castPoint.position, _castPoint.rotation);
        spell.GetComponent<Animator>().runtimeAnimatorController = _castingSpellInfo.Animator;
        if(_castingSpellInfo.castType == CastType.Range)
        {
            Rigidbody2D spellRB = spell.AddComponent<Rigidbody2D>();
            RangeSpell range = spell.AddComponent<RangeSpell>();
            range.SetupValues( _castingSpellInfo.effectTime, _castingSpellInfo.power); 
            spellRB.velocity = transform.right * _castingSpellInfo.speed;
        }
        else if(_castingSpellInfo.castType == CastType.Self)
        {
            spell.transform.SetParent(player.transform);
            spell.transform.localPosition = new Vector3(-0.053f, -0.041f, 0);
            if(_castingSpellInfo.spellType == SpellType.Heal)
            {
                player.GetComponent<Stats>().Heal(_castingSpellInfo.power, _castingSpellInfo.effectTime);
                Debug.Log(player.GetComponent<Stats>().health.currentValue + " is a player current health");
            }
            
        }
        Destroy(spell, _castingSpellInfo.lifeTime);
    }

    public IEnumerator CastingSpellTimer(float _castTime)
    {
        if(isCasting == true)
        {
            yield return new WaitForSeconds(_castTime);
            isCasting = false;
        }
    }

    public void Update()
    {
        
        if(CrossPlatformInputManager.GetButtonDown("Fire"))
        {
            StartCoroutine(CastSpell(spellBook[0]));
        }
        else if (Input.GetKeyDown(KeyCode.B))
        {
            StartCoroutine(CastSpell(spellBook[1]));
        }
    }
}
