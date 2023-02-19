using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UIElements;

public class Board : MonoBehaviour
{
    public Tile tileWater;
    public Tile tileRedPeg;
    public Tile tileWhitePeg;

    [Space(15)]
    public Tile[] tilePatrol;
    public Tile[] tileDestroyer;
    public Tile[] tileSubmarine;
    public Tile[] tileBattleship;
    public Tile[] tileCarrier;


    public void DrawBoard(Cell[,] all_cells, Tilemap tilemap)
    {
        int width = all_cells.GetLength(0);
        int height = all_cells.GetLength(1);

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                Cell current_cell = all_cells[x,y];
                current_cell.position = new Vector3Int(x, y, 0);

                tilemap.SetTile(current_cell.position, GetCellType(current_cell));
                //tilemap.SetTransformMatrix(current_cell.position, Matrix4x4.TRS(Vector3.zero, Quaternion.Euler(0, 0, (int)current_cell.rotation), Vector3.one)); // Sets rotation for ships
            }
        }

    }

    private Tile GetCellType(Cell cell)
    {
        if (cell.tileType == Cell.TileType.Water)
        {
            return tileWater;
        }
        else
        {
            return null;
        }

    }

    private Tile GetShipSection(Ship cell)
    {
        if (cell.shipType == Ship.ShipType.Patrol)
        {
            return tilePatrol[cell.section];
        }

        switch (cell.shipType)
        {
            case Ship.ShipType.Patrol:
                return tilePatrol[cell.section];

            case Ship.ShipType.Submarine:
                return tileSubmarine[cell.section];
        }

        return null;
    }
}
