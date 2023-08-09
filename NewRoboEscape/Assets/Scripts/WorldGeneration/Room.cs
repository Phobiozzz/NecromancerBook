using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room 
{
    public string roomID;
    public Vector3 roomPosition;
    public List<Vector3> tilesPosition = new List<Vector3>();
    public List<Tile> tiles = new List<Tile>();

    public float roomWidth;
    public float roomHeigth;

    public Room(string _roomID, Vector3 _position ,float _width, float _heigth)
    {
        roomID = _roomID;
        roomPosition = _position;
        roomWidth = _width;
        roomHeigth = _heigth;

        for (int w = 0; w < roomWidth; w++)
        {
            float wPosition = 0;
            if (_width % 2 == 0)
            {
                wPosition = w - (_width / 2 - 0.5f);
                //Debug.Log("Width is odd. " + _width + "W is " + w + ". Wposition = w- width/2 - 0.5f is " + wPosition);
            }
            else if (_width % 2 > 0)
            {
                wPosition = w - (_width / 2 - 0.5f);
                //Debug.Log("Width is not odd. " + _width + "W is " + w + ". Wposition = w- width/2 - 0.5f is " + wPosition);
            }

            for (int h = 0; h < roomHeigth; h++)
            {
                
                float hPosition = 0;

                
                if (_heigth % 2 == 0)
                {
                    hPosition = h -( _heigth / 2 - 0.5f);
                }
                else if (_heigth % 2 > 0)
                {
                    hPosition = h -( _heigth / 2 - 0.5f);
                }
                //Debug.Log("New tile position is " + new Vector3(wPosition, 1, hPosition));
                
                WallPosition wallTile = new WallPosition();
                TileType tileType = new TileType();
                Vector3 tilePosition = new Vector3(wPosition, 1, hPosition);
                if (h == 0 && w == 0)
                {
                    tileType = TileType.Wall;
                    wallTile = WallPosition.LeftDownCorner;
                }
                else if (h == _heigth - 1 && w == 0)
                {
                    tileType = TileType.Wall;
                    wallTile = WallPosition.LeftUpCorner;
                }
                else if (h == _heigth - 1 && w == _width - 1)
                {
                    tileType = TileType.Wall;
                    wallTile = WallPosition.RigthUpCorner;
                }
                else if (h == 0 && w == _width - 1)
                {
                    tileType = TileType.Wall;
                    wallTile = WallPosition.RigthDownCorner;
                }
                else if (h == 0)
                {
                    tileType = TileType.Wall;
                    wallTile = WallPosition.Down;
                }
                else if (h == roomHeigth - 1)
                {
                    tileType = TileType.Wall;
                    wallTile = WallPosition.Up;
                }
                else if (w == 0)
                {
                    tileType = TileType.Wall;
                    wallTile = WallPosition.left;
                }
                else if (w == _width - 1)
                {
                    tileType = TileType.Wall;
                    wallTile = WallPosition.Rigth;
                }
                else
                {
                    tileType = TileType.Floor;
                    wallTile = WallPosition.NotAWAll;
                }
                string tileId = roomID + "W" + w + "H" + h + "Wall Pos " + wallTile;
                Tile tile = new Tile(wallTile, tileId, tileType, tilePosition);
                tiles.Add(tile);
                tilesPosition.Add(tilePosition);
            }
        }
    }
}
