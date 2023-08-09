using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapSpace
{
    public int minRoomSize;
    public Node allMapSpace;
    int roomId = 0;
    public List<Node> nodes = new List<Node>();
    public List<Node> parents = new List<Node>();

    public List<Room> rooms = new List<Room>();

    public void CreateFullMapSpace(int _mapWidth, int _MapHeigth, Vector3 _mapCenter)
    {
        allMapSpace = new Node(null, _mapWidth, _MapHeigth, _mapCenter, minRoomSize);
    }


    public void CreateTree()
    {
        //Debug.Log("Trying create tree with mapSpace with size of " + allMapSpace.heigth + " " + allMapSpace.heigth);
        GrowTree(allMapSpace);
        FillListOfNodes(allMapSpace);
    }

    public void GrowTree( Node _root)
    {
        if (_root != null)
        {
            
            if (_root.width > minRoomSize * 2.5 && _root.heigth>minRoomSize*2.5)
            {
                _root.SplitNode();
                
                GrowTree(_root.leftChild);
                GrowTree(_root.rigthChild);
            }
           
        }
       
    }

    public void FillListOfNodes(Node root)
    {
        if (root.leftChild == null)
        {
            float minW = 0;
            if (minRoomSize >= root.width)
            {
                minW = root.width;
            }
            else
            {
                minW = minRoomSize;
            }

            float minH = 0;
            if (minRoomSize >= root.heigth)
            {
                minH = root.heigth;
            }
            else
            {
                minH = minRoomSize;
            }
            string id = "R" + roomId;
            roomId++;
            rooms.Add(new Room(id, root.nodeCenter,(int)Random.Range(minW, root.width) ,(int)Random.Range(minH, root.heigth)));
            nodes.Add(root);
        }
        else
        {
            parents.Add(root);
            FillListOfNodes(root.leftChild);
            FillListOfNodes(root.rigthChild);
        }
    }
}
