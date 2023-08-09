using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Flicking : MonoBehaviour
{
    Image image;
    public float speed;

    public float timer;
    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();
        
    }

    // Update is called once per frame
    void Update()
    {
        Flick();
    }

    public void Flick()
    {
       
    }
}
