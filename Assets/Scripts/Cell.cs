using Unity.VisualScripting;
using UnityEngine;

public struct Cell
{
    public enum TileType
    {
        Water,
        Ship,
    }

    public TileType tileType;
    public Ship shipAttributes;

    public Vector3Int position;
    public bool hit;
    public bool missed;
}
