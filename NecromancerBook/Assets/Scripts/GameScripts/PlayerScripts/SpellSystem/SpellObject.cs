using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Spell", menuName = "Spell")]
public class SpellObject : ScriptableObject
{
    public RuntimeAnimatorController Animator;
    public string spellName;
    public string description;
    public float power;
    public bool isKnown;
    public CastType castType;
    public SpellType spellType;

    public float speed;

    public float manaCost;
    public float healthCost;
    public float bonesCost;

    public float cooldown;
    public float castTime;
    public float lifeTime;
    public float effectTime;

   

}
public enum CastType
{
    Range,
    Self
} 
public enum SpellType
{
    Heal,
    Damage
}

public enum EffectTime
{
    Point,
    OverTime
}

public enum CostType
{
    Mana, Health, Bones
}

public class ResourceCost
{
   public CostType type;
    public float cost;
}
