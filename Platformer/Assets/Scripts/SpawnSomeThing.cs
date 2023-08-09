using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSomeThing : MonoBehaviour
{
    public GameObject[] thingsToSpawn;
    int random;
    // Start is called before the first frame update
    void Start()
    {
        SpawnRandomThing();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnRandomThing()
    {
        random = Random.Range(0, thingsToSpawn.Length);
        Instantiate(thingsToSpawn[random], transform.position, Quaternion.identity);
    }
}
