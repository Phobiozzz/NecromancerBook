using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
public class MapGenerator : MonoBehaviour
{
    public float tileSize;
    public int mapWidth;
    public int mapHeigth;

    public GameObject leafPrefab;
    public GameObject roomPrefab;

    public GameObject VertexPrefab;
    

    public MapSpace mapSpace;

    public int roomMinSize;
    
    Vector3 mapCenter = new Vector3(0, 0, 0);
    Color tileColor;

    public List<Room> rooms = new List<Room>();
    public List<GameObject> roomsObj = new List<GameObject>();
    public int treshhold = 0;
    CorridorCreator corridorCreator = new CorridorCreator();

    List<Vector3> roomPositions()
    {
        List<Vector3> vectors = new List<Vector3>();
        for (int i = 0; i < roomsObj.Count; i++)
        {
            vectors.Add(roomsObj[i].transform.position);
        }
        return vectors;
    }

    List<Vector3> vector3s;
    List<Triangle> triangles;
    public List<RoomManager> roomsInfos = new List<RoomManager>();
    Graph graph;
    private void Start()
    {
       
        mapSpace = new MapSpace();
        mapSpace.minRoomSize = roomMinSize;
        mapSpace.CreateFullMapSpace(mapWidth, mapHeigth, mapCenter);
        mapSpace.CreateTree();
        rooms = mapSpace.rooms;
        //DrawDungeon();
        DrawRooms();
        vector3s = roomPositions();
        triangles = Delaunay.TriangulateByFlippingEdges(vector3s);
        graph = new Graph(triangles);
        corridorCreator.edges = graph.MST;
        
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            //DrawTriangles(triangles);
            DrawGraph(graph);
            CreateCorridor();
        }

       
    }
   
    public void DrawDungeon()
    {
        GameObject spaces = new GameObject();
        spaces.transform.name = "Spaces";
        foreach (Node leaf in mapSpace.nodes)
        {
            GameObject newSpace = Instantiate(leafPrefab, leaf.nodeCenter, Quaternion.identity);
           
            newSpace.name = "Space # " + leaf.myID;
            newSpace.GetComponent<MeshRenderer>().material.color = Random.ColorHSV();
            newSpace.transform.localScale = new Vector3(leaf.width, 1, leaf.heigth);
            newSpace.transform.parent = spaces.transform;
        }

       
    }

    public void DrawParents()
    {
        GameObject parents = new GameObject();
        foreach (Node leaf in mapSpace.parents)
        {

            GameObject newSpace = Instantiate(leafPrefab, leaf.nodeCenter, Quaternion.identity);
            newSpace.name += " " + leaf.myID;
            newSpace.GetComponent<MeshRenderer>().material.color = Random.ColorHSV();
            newSpace.transform.localScale = new Vector3(leaf.width, 1, leaf.heigth);
            newSpace.transform.parent = parents.transform;

        }

    }

    public void DrawRooms()
    {
        GameObject rooms = new GameObject();
        rooms.transform.position = new Vector3(0, 0, 0);
        //rooms.transform.localScale = new Vector3(mapWidth, 1, mapHeigth);
        rooms.transform.name = "Rooms";
        BoxCollider boxCollider = rooms.AddComponent<BoxCollider>();
        boxCollider.size = new Vector3(mapWidth, 0.5f, mapHeigth);
       
        for (int i = 0; i < mapSpace.rooms.Count; i++)
        {
            
            GameObject room = Instantiate(roomPrefab, mapSpace.rooms[i].roomPosition, Quaternion.identity);
            room.transform.SetParent(rooms.transform);
            
            Color roomColor = new Color();
            if (mapSpace.rooms[i].roomWidth >= treshhold && mapSpace.rooms[i].roomWidth >= treshhold)
            {
                roomColor = Color.red;
            }
            else
            {
                roomColor = Color.black;
            }
            for (int j = 0; j < mapSpace.rooms[i].tilesPosition.Count; j++)
            {
                WallPosition wallType = mapSpace.rooms[i].tiles[j].wallType;
                if (wallType == WallPosition.NotAWAll)
                {
                    tileColor = Color.black;
                }
                else if (wallType == WallPosition.LeftDownCorner || wallType == WallPosition.LeftUpCorner || wallType == WallPosition.RigthDownCorner || wallType == WallPosition.RigthUpCorner)
                {
                    tileColor = Color.red;
                }
                else if (wallType == WallPosition.Down || wallType == WallPosition.left || wallType == WallPosition.Rigth || wallType == WallPosition.Up)
                {
                    tileColor = Color.blue;
                    
                }
               
                GameObject tile = Instantiate(leafPrefab, room.transform);
                tile.transform.localPosition = mapSpace.rooms[i].tilesPosition[j];
                tile.transform.name = mapSpace.rooms[i].tiles[j].id;
                tile.GetComponent<MeshRenderer>().material.color = tileColor;
                if (mapSpace.rooms[i].tiles[j].wallType != WallPosition.NotAWAll)
                {
                    tile.AddComponent<BoxCollider>().isTrigger = true;
                }
            }
            RoomManager rm= room.AddComponent<RoomManager>();
            room.AddComponent<BoxCollider>();
            rm.width = (int)mapSpace.rooms[i].roomWidth;
            rm.heigth = (int)mapSpace.rooms[i].roomHeigth;
            rm.myID = i;
            room.name = "Room " + rm.myID;
            roomsObj.Add(room);

        }

        for (int r = 0; r < roomsObj.Count; r++)
        {
            float spaceWidth = mapSpace.nodes[r].width;
            float spaceHeigth = mapSpace.nodes[r].heigth;

            float roomWidth = mapSpace.rooms[r].roomWidth;
            float roomHeigth = mapSpace.rooms[r].roomHeigth;

            float randomXoffset = 0;
            if (spaceWidth > roomWidth * 2)
            {
                randomXoffset = Mathf.Round(Random.Range(-1 * roomWidth / 2, roomWidth / 2));
            }
            float randomYoffset = 0;
            if (spaceHeigth > roomHeigth * 2)
            {
                randomYoffset = Mathf.Round(Random.Range(-1 * roomHeigth / 2, roomHeigth / 2));
            }
            Vector3 correctPosition = new Vector3(roomsObj[r].transform.position.x+randomXoffset, roomsObj[r].transform.position.y, roomsObj[r].transform.position.z+ randomYoffset);
            if ((spaceWidth - roomWidth) % 2 > 0)
            {
                bool random = Random.value > (0.5);
                float multiplyer = 0;
               
                if (random)
                {
                    multiplyer = -1;
                }
                else if (!random)
                {
                    multiplyer = 1;
                }

                correctPosition += new Vector3(0.5f * multiplyer, 0, 0);
               
            }

            if ((spaceHeigth - roomHeigth) % 2 > 0)
            {
                bool random = Random.value > (0.5);
                float multiplyer = 0;
                if (random)
                {
                    multiplyer = -1;
                }
                else if (!random)
                {
                    multiplyer = 1;
                }

                correctPosition += new Vector3(0, 0, 0.5f * multiplyer);
            }

            roomsObj[r].transform.localPosition = correctPosition;  

        }
    }

    public void DrawTriangles(List<Triangle> triangles)
    {
        foreach (Triangle triangle in triangles)
        {
            Debug.Log("Trangles count is " + triangles.Count);
            Debug.DrawLine(triangle.v1.position, triangle.v2.position, Color.white, 100f);
            Debug.DrawLine(triangle.v2.position, triangle.v3.position, Color.white, 100f);
            Debug.DrawLine(triangle.v3.position, triangle.v1.position, Color.white, 100f);

        }
    }

    public void DrawGraph(Graph graph)
    {
        //Graph graph = new Graph(triangles);
        GameObject verts = new GameObject();
        foreach (Vertex vertex in graph.vertices)
        {
           GameObject v = Instantiate(VertexPrefab, vertex.position, Quaternion.identity);
            v.transform.SetParent(verts.transform);
            Collider[] roomCol = Physics.OverlapSphere(v.transform.position, 1f);
            foreach (Collider collider in roomCol)
            {
                if (collider.transform.tag == "Room")
                {
                    RoomManager roomInfo = collider.GetComponent<RoomManager>();
                    roomsInfos.Add(roomInfo);
                }
                
            }
            
        }
        foreach (Edge edge in graph.MST)
        {
            //Debug.Log("Drawing line beetween " + edge.v1.position + " and " + edge.v2.position);
            Debug.DrawLine(edge.v1.position, edge.v2.position, Color.white, 200f);
           //Debug.DrawLine(edge.v1.halfEdge.v.position, edge.v2.halfEdge.v.position, Color.red, 200f);
        }
    }

    public void CreateCorridor()
    {
        corridorCreator.CreateCorridor();

    }
}
