using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonCreator : MonoBehaviour
{
    public List<GameObject> tilePrefabs;
    public GameObject[] wallPrefabs;
    public GameObject[] floorPrefabs;
    public GameObject[] doorPrefabs;
    public int tileSize;
    public int radius;

    public int dungeonWidth;
    public int dungeonHeigth;


    
    public int roomsCount;
    public int minRoomSize;
    public int maxRoomSize;

    private void Start()
    {
       
    }

    
    public float RoundM(float n, int m)
    {       
      return Mathf.Floor(((n + m - 1) / m)) * m;
    }

    public Vector3 GetPointInCircle(int radius)
    {
        Vector3 newPosition = new Vector3();
        float t = 2 * Mathf.PI * Random.Range(0f, 1f);
        float u = Random.Range(0f, 1f) + Random.Range(0f, 1f);
        float r = 0;

        if (u > 1)
        {
            r = 2 - u;
        }
        else
        {
            r = u;
        }
       
        float x = 0;
        float y = 0;

        x = RoundM(radius * r * Mathf.Cos(t), tileSize);
        y = RoundM(radius * r * Mathf.Sin(t), tileSize);

        newPosition = new Vector3(x, 1, y);
        
        return newPosition;
    }


   
}
