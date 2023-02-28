using UnityEngine;
using UnityEngine.Tilemaps;
using static Cell;

public class GameLogic : MonoBehaviour
{
    private int width = 10;
    private int height = 10;
    private Vector3Int current_mouse_position;

    public Board board;
    private Cell[,] state;
    private Cell[,] shipState;

    public Tilemap waterTilemap, shipTilemap, pegTilemap;
    public int ship_rotation;

    public enum ShipSelection
    {
        Patrol = 2,
        Submarine = 3,
        Destroyer = 3,
        Battleship = 4,
        Carrier = 5,
    }
    public ShipSelection ship;

    private void Awake()
    {
        state = new Cell[width, height]; //initialze 2D array of Cells
        shipState = new Cell[width, height];

        DrawStartingGameBoard();
        AlignCameraToBoard();
    }

    private void Update()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (mousePosition.x >= 0 && mousePosition.x <= 10 && mousePosition.y >= 0 && mousePosition.y <= 10)
        {  
            if (Input.GetMouseButtonDown(0))
            {
                PlaceShip(ship, true);
            }
            else
            {
                PreviewShipPlacement();
            }
        }

    }

    private void DrawStartingGameBoard()
    {
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                state[x, y].tileType = TileType.Water;
            }
        }

        board.DrawBoard(state, waterTilemap);
    }

    private void AlignCameraToBoard()
    {
        Vector3 board_position = new Vector3(width / 2f, height / 2f, -10f);
        Camera.main.transform.position = board_position; //Aligns Camera with game board
    }

    private void PlaceShip(ShipSelection ship, bool isPlaced)
    {
        // Gets grid position from mouse
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3Int starting_position = shipTilemap.WorldToCell(worldPosition);

        // If ship is already placed
        if (shipState[starting_position.x, starting_position.y].shipAttributes.isPlaced) return;

        // New Ship attributes
        int ship_length = (int)ship;
        int ship_direction = ship_rotation;
        Vector3Int[] section_positions = AssignShipSectionPositions(starting_position, ship_length, ship_direction);
        Ship.RotationType section_rotation = GetSectionRotation(ship_direction);

        for (int i = 0; i < section_positions.Length; i++)
        {

            Cell cell = new Cell();

            // Sets ship attributes to new cell
            cell.tileType = TileType.Ship;
            cell.shipAttributes.shipType = Ship.ShipType.Patrol;
            cell.shipAttributes.currentSection = i; //Sections are in consecutive order
            cell.shipAttributes.rotation = GetSectionRotation((int)section_rotation);

            cell.shipAttributes.isPlaced = isPlaced;

            int x_position = section_positions[i].x;
            int y_position = section_positions[i].y;

            shipState[x_position, y_position] = cell;
        }

        // Draws board with new cell attributes
        board.DrawBoard(shipState, shipTilemap);
    }
    private void PreviewShipPlacement()
    {
        // Gets position on grid from mouse.
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3Int starting_position = shipTilemap.WorldToCell(worldPosition);

        PlaceShip(ship, false);
        
        if (current_mouse_position != starting_position)
        {
            ClearShipTilemap();
            current_mouse_position = starting_position;
        }
    }

   /* private Cell.shipAttributes.ShipType GetShipType(ShipSelection ship)
    {
        switch (ship)
        {
            case ShipSelection.Patrol:
                return Cell.ShipType.Patrol;
            case ShipSelection.Submarine:
                return Cell.ShipType.Submarine;
            //case ShipSelection.Destroyer:
            // return Cell.RotationType.Up;
            case ShipSelection.Battleship:
            //return Cell.RotationType.Left;
            case ShipSelection.Carrier:
            //return Cell.RotationType.Left;
            default:
                return 0;
        }
    }
*/


    private Vector3Int[] AssignShipSectionPositions(Vector3Int starting_position, int ship_length, int ship_direction)
    {
        Vector3Int[] position_list = new Vector3Int[ship_length];
        Vector3Int section_offset;

        switch (ship_direction)
        {
            case 0:
                // Down
                section_offset = new Vector3Int(0, -1);
                break;

            case 90:
                // Right
                section_offset = new Vector3Int(1, 0);
                break;
            case 180:
                // Up
                section_offset = new Vector3Int(0, 1);
                break;

            case 270:
                // Left
                section_offset = new Vector3Int(-1, 0);
                break;

            default:
                section_offset = Vector3Int.zero;
                break;
        }


        for (int i = 0; i < ship_length; i++)
        {
            position_list[i] = starting_position + (section_offset * i);
        }

        return position_list;
    }

    private Ship.RotationType GetSectionRotation(int ship_direction)
    {
        switch (ship_direction)
        {
            case 0:
                return Ship.RotationType.Down;
            case 90:
                return Ship.RotationType.Right;
            case 180:
                return Ship.RotationType.Up;
            case 270:
                return Ship.RotationType.Left;
            default:
                return 0;
        }
    }

    private void ClearShipTilemap()
    {
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                Cell cell = new Cell();

                if (shipState[x, y].shipAttributes.isPlaced != true)
                {
                    shipState[x, y] = cell;
                }
            }
        }

        board.DrawBoard(shipState, shipTilemap);
    }

    private void CheckAdjacentShipCells(Cell cell)
    {
        
    }
}

