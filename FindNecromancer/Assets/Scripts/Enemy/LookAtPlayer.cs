using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtPlayer : MonoBehaviour
{
    public Transform player;
    public Transform eyes;
    public int speed;

    public Vector2 borderX;
    public Vector2 borderY;

    public void LookAt()
    {
            Vector3 bordingVector = new Vector3(Mathf.Clamp(player.position.x, borderX.x, borderX.y), Mathf.Clamp(player.position.y, borderY.x, borderY.y), eyes.position.z);
            eyes.position = bordingVector * speed *  Time.fixedDeltaTime;
    }

    public void FixedUpdate()
    {
        LookAt();
    }
}
