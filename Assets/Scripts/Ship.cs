using UnityEngine;

public struct Ship
{
    public enum ShipType
    {
        Patrol,
        Submarine,
        Destroyer,
        Battleship,
        Carrier,
    }

    public enum RotationType
    {
        Up = 180,
        Down = 0,
        Left = 270,
        Right = 90,
    }

    public ShipType shipType;
    public RotationType rotation;
    public int currentSection; //Updates through board script
    public bool isPlaced;

}
