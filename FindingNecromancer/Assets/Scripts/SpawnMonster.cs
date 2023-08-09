using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMonster : MonoBehaviour
{
    public GameObject monsterPrefab;
    public float nextSpawnTime;
    public Vector2 spawnRangeX;
    public float currentTime;
    Vector2 spawnPosition;

    public int maxMonstersAmount;

    public void Start()
    {
        currentTime = 0;
        maxMonstersAmount = 5;
    }

    public void FixedUpdate()
    {
        if (GameObject.FindGameObjectsWithTag("Monster").Length < maxMonstersAmount)
        {
            Spawn();
        }
        else
        {
            Debug.Log("Spawner cannot spawn more monsters ");
        }
        
    }

    public void Spawn()
    {
        if (currentTime <= 0)
        {
            spawnPosition = new Vector2(Random.Range(spawnRangeX.x, spawnRangeX.y), transform.position.y);
            Instantiate(monsterPrefab, spawnPosition, Quaternion.identity);
            currentTime = nextSpawnTime;
        }
        else
        {
            currentTime -= Time.fixedDeltaTime;
        }
    }
}
