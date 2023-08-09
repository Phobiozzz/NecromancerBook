using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Vector3 ofset;
    public Transform player;

    public TransparentWall currentTransparentWall;

    private void Update()
    {
        Vector3 position = player.position + ofset;
        transform.position = position;

        //Calculate the Vector direction 
        Vector3 direction = player.transform.position - transform.position;
        //Calculate the length
        float length = Vector3.Distance(player.transform.position, transform.position);
        //Draw the ray in the debug
        Debug.DrawRay(transform.position, direction.normalized * length, Color.red);
        

        RaycastHit currentHit;
        //Cast the ray and report the firt object hit filtering by "Wall" layer mask
        if (Physics.Raycast(transform.position, direction, out currentHit, 300f))
        {
            Debug.Log(currentHit.transform.name);
            if (currentHit.transform.tag == "Wall")
            {
                //Getting the script to change transparency of the hit object
                TransparentWall transparentWall = currentHit.transform.GetComponent<TransparentWall>();
                //If the object is not null
                if (transparentWall)
                {
                    if (currentTransparentWall && currentTransparentWall.gameObject != transparentWall.gameObject)
                    {
                        //Restore its transparency setting it not transparent
                        currentTransparentWall.ChangeTransparency(false);
                    }
                    //Change the object transparency in transparent.
                    transparentWall.ChangeTransparency(true);
                    currentTransparentWall = transparentWall;
                }
               
            }
            else
            {

                //If nothing is hit and there is a previous object hit
                if (currentTransparentWall)
                {

                    //Restore its transparency setting it not transparent
                    currentTransparentWall.ChangeTransparency(false);
                }
            }

        }

    }

    private void FixedUpdate()
    {
        
     
       
    }
}