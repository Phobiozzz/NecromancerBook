using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyParticles : MonoBehaviour
{
    public void Start()
    {
        Destroy(gameObject, GetComponent<ParticleSystem>().duration);
    }
}
