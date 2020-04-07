using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class HPBar : MonoBehaviour
{
    public GameObject globeReference;
    public List<GameObject> globes;

    
    public float globePosX = 30;
    public float globePosY = -30;
    public void Awake()
    {
        
    }

    public void AddGlobe()
    {
        GameObject globe = Instantiate(globeReference, new Vector3(globePosX, globePosY, 0), globeReference.transform.rotation);
        globe.GetComponent<Transform>().SetParent(this.transform);
        globe.GetComponent<RectTransform>().anchoredPosition = new Vector2(globePosX, globePosY);
        globe.GetComponent<RectTransform>().localScale = new Vector3(0.5f, 0.5f, 0.5f);
        Debug.Log("Globe position " + globe.GetComponent<RectTransform>().anchoredPosition);
        globePosX = globe.GetComponent<RectTransform>().anchoredPosition.x + 50;
        globes.Add(globe);
    }
    

}
