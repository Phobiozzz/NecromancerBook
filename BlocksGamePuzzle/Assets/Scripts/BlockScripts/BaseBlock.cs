using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseBlock : MonoBehaviour
{
    public GameObject model;
    public IMove moveType;

    public void Move(bool mainDirection)
    {
        Vector3 finalDestination = transform.position + moveType.MoveVector(mainDirection);
        if (canMove(finalDestination- transform.position))
            this.transform.position = finalDestination;
    }

    bool canMove(Vector3 _destination)
    {
        
        if (Physics.Raycast(transform.position, _destination, 0.5f))
        {
            return false;
        }
        else
        {
            return true;
        }
        
    }
}
