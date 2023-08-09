using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
     
     float rndmSpeed;
     int RndmDirection;
     bool direction;

   

    private void Start()
    {
        rndmSpeed = Random.Range(0.5f, 1.3f);
        
        RndmDirection = Random.Range(0, 10);
        if (RndmDirection < 5)
        {
            direction = true;
        }
        else
        {
            direction = false;
        }
    }

    public void RotateGear(bool direction)
    {
        if (direction)
            this.transform.Rotate(new Vector3(0, 0, rndmSpeed));
        else if (!direction)
            this.transform.Rotate(new Vector3(0, 0, -rndmSpeed));
    }


    private void Update()
    {
        RotateGear(direction);
    }
}
