using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighligthScript : MonoBehaviour
{
    public Material myMaterial;
    Color myColor;

    private void Start()
    {
        myMaterial = GetComponent<MeshRenderer>().material;
        myColor = myMaterial.color;
    }

    public void OnMouseEnter()
    {
        myMaterial.color = Color.green;
    }

    private void OnMouseExit()
    {
        myMaterial.color = myColor;
    }
}
