using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "NewSpell", menuName ="Spell"), ]
public class SpellObject : ScriptableObject
{
    public string spellName;
    public string description;

    public Sprite sprite;

    

    public SpellType spellType;
    public SpellRangeType spellRangeType;
    public TimeType timeType;
    public MagicSchool magicSchool;

    public CostType costType;
    public float costAmount;

    public float power;

    public float coolDown;
    public float range;
    public float effectTime;


    
    
}


public enum SpellType
{
    Attaking,
    Buff,
    Debuf,
    Restoring
}

public enum SpellRangeType
{
    Self,
    Enemy,
    Ally,
    AOE
}

public enum MagicSchool
{
    Necromancy,
    NaturalMagic
}

public enum TimeType
{
    Immidiately,
    Dot,
    Chanelling,
    Mixed
}

public enum CostType
{
    Mana,
    Health,
    Bones
}