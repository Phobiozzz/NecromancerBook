using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    
    private float lengthY;
    private float startPosY;
    //private float startPosY;

    public GameObject camera;

    public float parallaxEffect;


    private void Awake()
    {
        startPosY = transform.position.y;
       // startPosY = transform.position.y;
        lengthY = gameObject.GetComponent<SpriteRenderer>().bounds.size.y;
       //lengthY = gameObject.GetComponent<SpriteRenderer>().bounds.size.y;
        camera = GameObject.FindGameObjectWithTag("MainCamera");

    }

    private void FixedUpdate()
    {
        float temp = (camera.transform.position.y * (1 - parallaxEffect));


        float distanceY = (camera.transform.position.y * parallaxEffect);
        //float distanceY = (camera.transform.position.y * parallaxEffect);
        transform.position = new Vector3(transform.position.x, startPosY + distanceY, transform.position.z);

        if (temp > startPosY + lengthY)
        {
            startPosY += lengthY;
        }
        else if (temp < startPosY - lengthY)
        {
            startPosY -= lengthY;
        }
                
    }


}
