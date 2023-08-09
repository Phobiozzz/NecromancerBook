using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalMove : IMove
{
    public Vector3 MoveVector(bool _mainDirection)
    {
        if (_mainDirection)
        {
            return new Vector3(0, 0, Measures.stepSize);
        }
        else
        { 
            return new Vector3(0, 0, -Measures.stepSize);
        }
    }
}
