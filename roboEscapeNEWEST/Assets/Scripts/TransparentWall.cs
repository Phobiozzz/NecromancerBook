using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransparentWall : MonoBehaviour
{
    private MeshRenderer rend;
    Color materialColor;
    public Material transMaterial;
    public Material opaqueMaterial;
    public bool transparent = false;

    private void Start()
    {
        //Get the renderer of the object
        rend = gameObject.GetComponent<MeshRenderer>();
        //Get the material color
       
    }

    public void ChangeTransparency(bool transparent)
    {
        //Avoid to set the same transparency twice
        if (this.transparent == transparent) return;

        //Set the new configuration
        this.transparent = transparent;

        //Check if should be transparent or not
        if (transparent)
        {
            //Change the alpha of the color
            rend.material = transMaterial;
           // materialColor.a = 0.45f;
        }
        else
        {
            //Change the alpha of the color
            rend.material = opaqueMaterial;
           // materialColor.a = 1.0f;
        }
        //Set the new Color
       // rend.material.color = materialColor;
    }
}
