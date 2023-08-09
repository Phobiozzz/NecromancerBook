using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    public int currentHP;
    public int maxHP;

    void AdjustHP()
    {
        if (currentHP <= 0)
        {
            currentHP = 0;
            gameObject.GetComponent<EnemyAI>().currentState = State.Dead;

        }
        else if (currentHP >= maxHP)
        {
            currentHP = maxHP;
        }

    }
    private void Start()
    {
        maxHP = 3;
        currentHP = maxHP;
    }
    private void Update()
    {
        AdjustHP();
    }
    public void TakeDamage(int _dmg)
    {
        currentHP -= _dmg;
    }
}
