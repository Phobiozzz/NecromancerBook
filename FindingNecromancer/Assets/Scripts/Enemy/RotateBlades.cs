using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateBlades : MonoBehaviour
{
    
    public int speed;
    public void Update()
    {
        transform.Rotate(0, 0, -360 * speed * Time.deltaTime); 
    }
}
