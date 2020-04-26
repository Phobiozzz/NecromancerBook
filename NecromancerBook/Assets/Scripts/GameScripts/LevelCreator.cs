using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelCreator : MonoBehaviour
{
    public float tileSize;

    public GameObject PlayerPrefab;
    public GameObject[] level; 
    public int platformsCount;

    public GameObject platformParent;
    public Vector3 platformParentPosition;
   
    public Sprite[] tileset = new Sprite[6];
    

    public void Start()
    {
        tileSize = 0.32f;
        
        platformParentPosition = new Vector3(0,0,0);
        level = new GameObject[platformsCount];
        CreateLevel(platformsCount);
        
    }

    public void CreateLevel(int _platformsCount)
    {
        for(int i = 0; i < _platformsCount; i++)
        {
            spawnPlatform(platformParentPosition);
            platformParentPosition.x += tileSize * Random.Range(1,3);
            level[i] = platformParent; 
            
        }
        Instantiate(PlayerPrefab, level[0].transform.position + new Vector3(0, tileSize ,0), Quaternion.identity);
    }
    public void spawnPlatform(Vector3 _platformStartingPosition)
    { 
        //Creating new platform on the scene. Setup platform parent and position 
        platformParent = new GameObject("Platform");
        platformParent.transform.SetParent(transform);
        PlatformInfo info = new PlatformInfo(Random.Range(2,8), 5, Random.Range(1, 4));
        Vector3 topTilePosition = new Vector3(0,0,0);
        platformParent.transform.localPosition = _platformStartingPosition + new Vector3(0, info.floor * tileSize, 0);
        
        
        //Choose rigth sprites to draw
        int spriteToDraw;

         for(int l = 0; l < info.length; l++)
        {
            if(l == 0)
            {
                spriteToDraw = 0;
            }
            else if(l>0 && l< info.length -1 )
            {
                spriteToDraw = 1;
            }
            else
            {
                spriteToDraw = 2;
            }
            SpawnTile(platformParent, topTilePosition,tileset[spriteToDraw], true); 
            Debug.Log("Top tile position is " + topTilePosition);
            topTilePosition.y -= tileSize;
            for(int h = 0; h < info.higth; h++)
            {
                
                Debug.Log("Bottom tile posirion is " + topTilePosition);
                SpawnTile(platformParent, topTilePosition, tileset[spriteToDraw + 3], false);
                topTilePosition.y -= tileSize;
            }
            topTilePosition.x +=tileSize;
            topTilePosition.y = 0;
        }
        platformParentPosition.x += topTilePosition.x;
         
    }
    public void SpawnTile(GameObject _parent, Vector3 _position, Sprite _sprite, bool _isTop)
    {
        //create new tile as game object
       GameObject tile = new GameObject("Tile");
       // set tile parent and position
       tile.transform.SetParent(_parent.transform);
       tile.transform.localPosition = new Vector3(_position.x , _position.y, _position.z);
       // Draw sprite
       tile.AddComponent<SpriteRenderer>();
       SpriteRenderer render = tile.GetComponent<SpriteRenderer>();
       render.sprite = _sprite;
       render.sortingLayerName = "Ground";
       render.sortingOrder = 1;
       tile.transform.tag = "Ground";
       //Add collider if its top tile
       if(_isTop)
       {
           tile.AddComponent<BoxCollider2D>();
       }
    }

   
}

public class PlatformInfo
{
    public int length;
    public int higth;
    public int floor;

    public PlatformInfo(int _length, int _higth, int _floor)
    {
        length = _length;
        higth =_higth;
        floor = _floor;
    }
}
