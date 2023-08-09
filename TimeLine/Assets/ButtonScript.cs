using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    public SoundManager manager;

    private void Awake()
    {
        manager = GameObject.FindGameObjectWithTag("SoundManager").GetComponent<SoundManager>();
    }

    public void Click()
    {
        
        manager.Click();
    }

    public void Chains()
    {
        manager.Chains();
    }
}
