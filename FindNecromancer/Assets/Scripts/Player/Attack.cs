using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public Transform castBall;

    public GameObject spellPrefab;
    public float spellSpeed;
    public Animator animator;

    public void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Cast();
        }
    }

    public void Cast()
    {
        animator.SetTrigger("Attack");
        GameObject spell = Instantiate(spellPrefab, castBall.position, castBall.rotation);
        Rigidbody2D rigidbody = spell.GetComponent<Rigidbody2D>();
        rigidbody.AddForce(castBall.up * spellSpeed, ForceMode2D.Impulse);
        
        Destroy(spell, 2);
    }

}
