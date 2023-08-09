using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalBlock : BaseBlock
{
    // Start is called before the first frame update
    void Start()
    {
        this.moveType = new VerticalMove();
    }

  
}
