using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalBlock : BaseBlock
{
    private void Start()
    {
        this.moveType = new HorizontalMove();
    }
}
