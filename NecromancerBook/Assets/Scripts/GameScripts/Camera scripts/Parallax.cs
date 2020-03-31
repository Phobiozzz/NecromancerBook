using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    private float lengthX;
    private float lengthY;
    private float startPosX;
    //private float startPosY;

    public GameObject camera;

    public float parallaxEffect;


    private void Awake()
    {
        startPosX = transform.position.x;
       // startPosY = transform.position.y;
        lengthX = gameObject.GetComponent<SpriteRenderer>().bounds.size.x;
       //lengthY = gameObject.GetComponent<SpriteRenderer>().bounds.size.y;
        camera = GameObject.FindGameObjectWithTag("MainCamera");

    }

    private void FixedUpdate()
    {
        float temp = (camera.transform.position.x * (1 - parallaxEffect));


        float distanceX = (camera.transform.position.x * parallaxEffect);
        //float distanceY = (camera.transform.position.y * parallaxEffect);
        transform.position = new Vector3(startPosX + distanceX, transform.position.y, transform.position.z);

        if (temp > startPosX + lengthX)
        {
            startPosX += lengthX;
        }
        else if (temp < startPosX - lengthX)
        {
            startPosX -= lengthX;
        }
                
    }


}
