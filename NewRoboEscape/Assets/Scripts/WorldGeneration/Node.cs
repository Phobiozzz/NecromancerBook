using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node
{
    public static int ID = 0;
    public int myID;
    public Node parent;
    public Node leftChild;
    public Node rigthChild;
    public Node sibiling;

    public float width;
    public float heigth;

    public Vector3 nodeCenter;
    float minRoomSize;
    //bool splited;
   
    public Node(Node _parent, float _width, float _heigth, Vector3 _nodeCenter, float _minSize)
    {
        myID = ID + 1;
        ID++;
        parent = _parent;
        leftChild = null;
        rigthChild = null;
        sibiling = null;

        width = _width;
        heigth = _heigth;

        nodeCenter = _nodeCenter;
        //splited = false;
        minRoomSize = _minSize;
    }


    public bool Horizontal()
    {
        if (width > heigth)
        {
            //Debug.Log("Width larger thaan heigth. Splittin horizontal");
            return false;
         
        }
        else if (width < heigth)
        {
            //Debug.Log("Width smaller thaan heigth. Splittin vertical");
            return true;
        }
        else
        {
            //Debug.Log("Width and heigth equals. Splittin randomly");
            return Random.value > 0.5f;
        }
    }

    public Vector3Int SplitPosition(bool _horizontal )
    {
        Vector3Int splitPosition = new Vector3Int(0, 0, 0);
       
        if (_horizontal)
        {
            float rndm = Random.Range(minRoomSize*2, heigth - minRoomSize);
            splitPosition = new Vector3Int(0, 0, (int)rndm);
            //Debug.Log("Node heigth = " + heigth + ". Split posi);
        }
        else if (!_horizontal)
        {
            float rndm = Random.Range(minRoomSize*2, width - minRoomSize);
            splitPosition = new Vector3Int((int)rndm, 0, 0);
            //Debug.Log("Node heigth = " + width + ". Split position set to " + splitPosition);
        }
        return splitPosition;
    }

    
    public void SplitNode()
    {
        bool horizontalSplit = Horizontal();
        Vector3 splitPosition = SplitPosition(horizontalSplit);

        Vector2 leftChildSize = new Vector2(0,0);
        Vector2 rigthChildSize = new Vector2(0,0);
        Vector3 leftchildCenter = new Vector3(0, 0, 0);
        Vector3 rigthChildCenter = new Vector3(0, 0, 0);
        if (horizontalSplit)
        {
            leftChildSize += new Vector2(width, heigth - splitPosition.z);
            rigthChildSize += new Vector2(width, splitPosition.z);
            leftchildCenter += new Vector3(nodeCenter.x, 0, nodeCenter.z - splitPosition.z / 2);
            rigthChildCenter += new Vector3(nodeCenter.x, 0, leftchildCenter.z + (leftChildSize.y / 2 + rigthChildSize.y / 2));
        }
        else if (!horizontalSplit)
        {
            leftChildSize += new Vector2(width - splitPosition.x, heigth);
            rigthChildSize += new Vector2(splitPosition.x, heigth);
            leftchildCenter += new Vector3(nodeCenter.x - splitPosition.x / 2, 0, nodeCenter.z);
            rigthChildCenter += new Vector3(leftchildCenter.x + (leftChildSize.x / 2 + rigthChildSize.x / 2), 0, nodeCenter.z);
        }

        leftChild = new Node(this, leftChildSize.x, leftChildSize.y, leftchildCenter, minRoomSize);
        rigthChild = new Node(this, rigthChildSize.x, rigthChildSize.y,rigthChildCenter, minRoomSize);

        leftChild.parent = this;
        rigthChild.parent = this;
        leftChild.sibiling = rigthChild;
        rigthChild.sibiling = leftChild;
        //splited = true;
    }
}
