using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnThings : MonoBehaviour
{
    public GameObject[] things;

    public void Start()
    {
        int rndm = Random.Range(0, things.Length);
        GameObject newThing = Instantiate(things[rndm], transform.position, Quaternion.identity, transform);
        float rndmScale = Random.Range(-0.1f, 0.1f);
        newThing.transform.localScale = new Vector3(newThing.transform.localScale.x + rndmScale, newThing.transform.localScale.y + rndmScale, newThing.transform.localScale.z);
    }
}
