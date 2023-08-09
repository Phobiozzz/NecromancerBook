using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Vector3 ofset;
    public Transform player;

    private void Update()
    {
        Vector3 position = player.position + ofset;
        transform.position = position;
    }
}
