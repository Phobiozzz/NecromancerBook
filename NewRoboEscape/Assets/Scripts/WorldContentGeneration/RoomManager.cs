using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomManager : MonoBehaviour
{
    public int myID;
    public int width;
    public int heigth;

    public List<GameObject> tilesObj = new List<GameObject>();
    public Edge edge;

    public void GetChildren()
    {
        Transform[] childrenTransforms =transform.GetComponentsInChildren<Transform>();
        foreach (Transform child in childrenTransforms)
        {
            if(child != transform)
            tilesObj.Add(child.gameObject);
        }
    }

    public void Start()
    {
        GetChildren();
    }
}
