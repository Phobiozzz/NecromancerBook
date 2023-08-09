using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellCasting : MonoBehaviour
{

    public GameObject[] spellsPrefabs;
    public Transform castPoint;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CastSpell()
    {
       GameObject spell = Instantiate(spellsPrefabs[0], castPoint.position, castPoint.rotation);
       
    }
}
