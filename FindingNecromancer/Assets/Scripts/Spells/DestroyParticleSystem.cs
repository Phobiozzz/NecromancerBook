using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyParticleSystem : MonoBehaviour
{

        private IEnumerator Start()
        {
            yield return new WaitForSeconds(GetComponent<ParticleSystem>().duration);
            Destroy(gameObject);
        }

}
