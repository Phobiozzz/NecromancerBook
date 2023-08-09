using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TileType
{
    Wall,
    Floor,
    Door
}

public enum WallPosition
{
    NotAWAll,
    LeftDownCorner,
    left,
    LeftUpCorner,
    Up,
    RigthUpCorner,
    Rigth,
    RigthDownCorner,
    Down
}

public class Tile
{
    public string id;
    public TileType type;
    public WallPosition wallType;
    public Vector3 tileLocalPosition;

    public Tile(WallPosition _wallType, string _id, TileType _type, Vector3 _localPos)
    {
        wallType = _wallType;
        id = _id;
        type = _type;
        tileLocalPosition = _localPos;
    }
}
