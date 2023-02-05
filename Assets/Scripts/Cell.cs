using Unity.VisualScripting;
using UnityEngine;

public struct Cell
{
    public enum Type
    {
        Water,
        Ship,
    }

    public Vector3Int position;
    public Type type;
    public bool hit;
    public bool missed;
}
