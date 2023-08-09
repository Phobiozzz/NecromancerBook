using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutlineScript : MonoBehaviour
{
    [SerializeField] private Material outlineMaterial;
    [SerializeField] private float outlineScaleFactor;
    [SerializeField] private Color outlineColor;
    private MeshRenderer outlineRenderer;

    void Start()
    {
        outlineRenderer = CreateOutline(outlineMaterial, outlineScaleFactor, outlineColor);
    }

    MeshRenderer CreateOutline(Material outlineMat, float scaleFactor, Color color)
    {

        GameObject outlineObject = Instantiate(this.gameObject, transform.position, transform.rotation, transform);
        MeshRenderer rend = outlineObject.GetComponent<MeshRenderer>();
        rend.material = outlineMat;
        rend.material.SetColor("_Color", color);
        rend.material.SetFloat("_ScaleFactor", scaleFactor);
        rend.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off;
        outlineObject.GetComponent<OutlineScript>().enabled = false;
        outlineObject.GetComponent<Collider>().enabled = false;
        rend.enabled = false;

        return rend;
    }

    private void OnMouseEnter()
    {
        outlineRenderer.enabled = true;
    }

    private void OnMouseOver()
    {
       transform.Rotate(Vector3.up, 1f, Space.World);
    }

    private void OnMouseExit()
    {
        outlineRenderer.enabled = false;
    }
}
