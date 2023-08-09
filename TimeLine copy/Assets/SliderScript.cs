using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class SliderScript : MonoBehaviour
{
    SoundManager sm;

    private void Start()
    {
        sm = GameObject.FindGameObjectWithTag("SoundManager").GetComponent<SoundManager>();
    }


    public void Chains()
    {
        sm.Chains();
    }
}
