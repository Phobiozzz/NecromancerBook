using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalMove : IMove
{
    public Vector3 MoveVector(bool _mainDirection)
    {
        if (_mainDirection)
        {
            return new Vector3(Measures.stepSize, 0, 0);
            
        }
        else
        {
            return new Vector3(-Measures.stepSize, 0, 0);
        }
    }
}
