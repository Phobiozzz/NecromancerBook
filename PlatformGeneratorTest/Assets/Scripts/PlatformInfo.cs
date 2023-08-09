using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformInfo
{
    public int length;
    public int heigth;
    public bool isMovable;
    public Vector3 position;

    public PlatformInfo(int _length, int _heigth, bool _isMovable, Vector3 _position)
    {
        length = _length;
        heigth = _heigth;
        isMovable =_isMovable;
        position = _position;
    }

    public void Start()
    {
        AdjustPlatformSize();
    }
    public void AdjustPlatformSize()
    {
        if(length <= 2)
        {
            length = 2;
        }

        if(heigth <= 2)
        {
            heigth = 2;
        }
    }
}
