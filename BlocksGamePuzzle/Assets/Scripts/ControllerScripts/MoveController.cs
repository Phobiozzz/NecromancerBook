using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveController : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            gameObject.BroadcastMessage("Move", true); 
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            gameObject.BroadcastMessage("Move", false);
        }
    }
}
