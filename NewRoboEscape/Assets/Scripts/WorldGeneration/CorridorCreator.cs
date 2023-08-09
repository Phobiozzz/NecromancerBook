using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CorridorCreator
{
    public List<Edge> edges;
    
    public List<Vector2> pointsMidPoint = new List<Vector2>();


    
    public void CreateCorridor()
    {
        
        for (int i = 0; i < edges.Count; i++)
        {
            Vector2 point1 = edges[i].v1.GetPos2D_XZ();
            Vector2 point2 = edges[i].v2.GetPos2D_XZ();
            
            pointsMidPoint.Add(new Vector2((point1.x + point2.x) / 2, (point1.y + point2.y) / 2));
            
            //Debug.Log("the midpoint of edge with points vectors " + point1 + " and " + point2 + " is " + pointsMidPoint);

        }

    }


    
}
