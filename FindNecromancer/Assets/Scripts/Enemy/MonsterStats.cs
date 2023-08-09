using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterStats
{
    public string monsterName;
    public int maxHealth;
    public int curHealth;

    public float attackDistance;
    public float speed;

    public bool isAlive;

    public MonsterStats(string _name, int _maxHealth, float _attDistance, float _speed)
    {
        monsterName = _name;
        maxHealth = _maxHealth;
        attackDistance = _attDistance;
        speed = _speed;
        curHealth = maxHealth;
        isAlive = true;
    }
}
