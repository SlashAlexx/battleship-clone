using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;
using static Cell;

public class GameLogic : MonoBehaviour
{
    private int width = 10;
    private int height = 10;

    private Board board;
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

    public ShipSelection Ship;

    private void Awake()
    {
        DrawStartingGameBoard();
        AlignCameraToBoard();
    }

    private void AlignCameraToBoard()
    {
        Vector3 board_position = new Vector3(width / 2f, height / 2f, -10f);
        Camera.main.transform.position = board_position; //Aligns Camera with game board
    }

    private void DrawStartingGameBoard()
    {
        board = GetComponentInChildren<Board>();

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                state[x, y].tileType = Cell.TileType.Water;
            }
        }

        board.DrawBoard(state, waterTilemap);
    }

/*
    private void PlaceShips()
    {
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Vector3Int starting_position = shipTilemap.WorldToCell(worldPosition);
        int shipType = (int)Ship;
        int ship_length = (int)Ship;
        int ship_direction = ship_rotation;

        Vector3Int[] section_positions = AssignShipSectionPositions(starting_position, ship_length, ship_direction);
        Cell.RotationType section_rotation = GetSectionRotation(ship_direction);

        for (int i = 0; i < section_positions.Length; i++)
        {
            Cell cell = new Cell();

            cell.tileType = Cell.TileType.Ship;
            cell.shipType = Cell.ShipType.Patrol;
            cell.section = i; //Sections are in consecutive order
            cell.rotation = section_rotation;

            int x_position = (int)section_positions[i].x;
            int y_position = (int)section_positions[i].y;

            shipState[x_position, y_position] = cell;
        }

        board.DrawBoard(shipState, shipTilemap);
    }

    private Cell.ShipType GetShipType(ShipSelection ship)
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

    private Vector3Int[] AssignShipSectionPositions(Vector3Int starting_position, int ship_length, int ship_direction)
    {
        Vector3Int[] patrol_positions = new Vector3Int[ship_length];
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
            patrol_positions[i] = starting_position + (section_offset * i);
        }

        return patrol_positions;
    }

    private Cell.RotationType GetSectionRotation(int ship_direction)
    {
        switch (ship_direction)
        {
            case 0:
                return Cell.RotationType.Down;
            case 90:
                return Cell.RotationType.Right;
            case 180:
                return Cell.RotationType.Up;
            case 270:
                return Cell.RotationType.Left;
            default:
                return 0;
        }
    }

    private void PreviewShipPlacement()
    {
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Vector3Int starting_position = shipTilemap.WorldToCell(worldPosition);
        int shipType = (int)Ship;
        int ship_length = (int)Ship;
        int ship_direction = ship_rotation;

        Vector3Int[] section_positions = AssignShipSectionPositions(starting_position, ship_length, ship_direction);
        Cell.RotationType section_rotation = GetSectionRotation(ship_direction);

        for (int i = 0; i < section_positions.Length; i++)
        {
            Cell cell = new Cell();

            cell.tileType = Cell.TileType.Ship;
            cell.shipType = Cell.ShipType.Patrol;
            cell.section = i; //Sections are in consecutive order
            cell.rotation = section_rotation;

            int x_position = (int)section_positions[i].x;
            int y_position = (int)section_positions[i].y;

            shipState[x_position, y_position] = cell;
        }

        board.DrawBoard(shipState, shipTilemap);
    }*/
}

