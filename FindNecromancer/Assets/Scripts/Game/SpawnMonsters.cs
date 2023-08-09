using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMonsters : MonoBehaviour
{
    public Transform spawner;
    public GameObject monster;

    public float leftBorder;
    public float rigthBorder;

    public int maxMonsters;
    public float nextMonsterTime;
    public float spawnTime;
    

    public void Start()
    {
        nextMonsterTime = spawnTime;
    }

    public void Update()
    {
        if (nextMonsterTime > 0)
        {
           
            nextMonsterTime -= Time.deltaTime;
        }

        else if (nextMonsterTime < 0)
        {
            Spawn();
        }

    }
    public void Spawn()
    {
       
        Vector3 spawnerPosition = new Vector3 (Random.Range(leftBorder, rigthBorder), spawner.position.y, spawner.position.z);

        if (GameObject.FindGameObjectsWithTag("Enemy").Length < maxMonsters)
        {
            Instantiate(monster, spawnerPosition, spawner.rotation);
            nextMonsterTime = spawnTime;
        }
        
    }

    public void Count()
    {
        
    }


}
