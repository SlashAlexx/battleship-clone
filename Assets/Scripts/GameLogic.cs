using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GameLogic : MonoBehaviour
{
    private int width = 10;
    private int height = 10;

    private Board board;
    private Cell[,] state;

    private void Awake()
    {
        state = new Cell[width, height]; //initialze 2D array of Cells

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
                state[x, y].type = Cell.Type.Water;
            }
        }

        board.DrawBoard(state);
    }
}
