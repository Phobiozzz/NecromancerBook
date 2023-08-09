using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform target;
    public float speed;

    public Vector3 offset;
    public float leftX;
    public float rigthX;



    public void FixedUpdate()
    {
        Follow();


    }




    public void Follow()
    {
        Vector3 cameraPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, cameraPosition, speed * Time.fixedDeltaTime);
        Vector3 bordindVector = new Vector3(Mathf.Clamp(smoothedPosition.x, leftX, rigthX), smoothedPosition.y, -10);
        transform.position = bordindVector;
    }
}
