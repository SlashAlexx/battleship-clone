using UnityEngine;
using UnityEngine.Tilemaps;

public class Board : MonoBehaviour
{
    public Tile tileWater;
    public Tile tileRedPeg;
    public Tile tileWhitePeg;

    public Tilemap tilemap;

    [Space(15)]
    public Tile[] tilePatrol;
    public Tile[] tileDestroyer;
    public Tile[] tileSubmarine;
    public Tile[] tileBattleship;
    public Tile[] tileCarrier;


    public void DrawBoard(Cell[,] all_cells)
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
            }
        }

    }

    private Tile GetCellType(Cell cell)
    {
        if (cell.type == Cell.Type.Water)
        {
            return tileWater;
        }
        else
        {
            return null;
        }


    }
}
