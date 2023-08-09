using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateGears : MonoBehaviour
{
    public void Rotate(bool direction)
    {
        if (direction)
            this.transform.Rotate(new Vector3(0, 0, 5));
        else if (!direction)
            this.transform.Rotate(new Vector3(0, 0, -5));
    }

    public void Update()
    {
       
    }
}
