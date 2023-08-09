using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    public string sttr;

    private void Start()
    {
        for (int i = 1; i < 3000; i++)
        {
            sttr += i; 
        }

        Debug.Log("Char at 2020 position is " + sttr[2019]);
    }
}
