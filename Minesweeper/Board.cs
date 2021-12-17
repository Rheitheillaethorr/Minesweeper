using System;
namespace Minesweeper
{
    public class Board
    {

        public int[,] gameBoard { get; set; }
        public int boardWidth { get; set; }
        public int boardHeight { get; set; }
        public int minesCount { get; set; }
        public bool[,] whereMines { get; set; }
        public bool[,] knownFieldsByTheUser { get; set; }

        public Board(int width, int height, int Cmines)
        {
            boardWidth = width;
            boardHeight = height;
            minesCount = Cmines;
            gameBoard = new int[boardWidth+2, boardHeight+2];
            whereMines = new bool[boardWidth, boardHeight];
            knownFieldsByTheUser = new bool[boardWidth+2, boardHeight+2];
        }
        public void CreateBoard()
        {
            Mines MinesArrangement = new Mines(boardWidth, boardHeight, minesCount);
            whereMines = MinesArrangement.SetMines();
            for (int i = 1; i < boardWidth+1; i++)
            {
                int n = i + 2;
                for (int j = 1; j < boardHeight+1; j++)
                {
                    int m = j + 2;
                    if (whereMines[i-1, j-1] == true)
                    {
                        gameBoard[i, j] += 10;
                        for (int o = i-1; o < i+2; o++)
                        {
                            for (int p = j-1; p < j+2; p++)
                            {
                                gameBoard[o, p]++;
                            }
                        }
                    }
                }
            }
        }
        public void CheckBoardMines()
        {
            for (int i = 0; i < boardWidth; i++)
            {
                for (int j = 0; j < boardHeight; j++)
                {
                    Console.Write("(" + i + "," + j + ") = " + whereMines[i, j]);
                }
                Console.Write("\n");
            }
        }
        public void CheckBoard()
        {
            for (int i = 1; i < boardWidth+1; i++)
            {
                for (int j = 1; j < boardHeight+1; j++)
                {
                    if (gameBoard[i, j] > 9)
                    {
                        Console.Write("(" + i + "," + j + ") = m");
                    }
                    else
                    {
                        Console.Write("(" + i + "," + j + ") = " + gameBoard[i, j]);
                    }
                }
                Console.Write("\n");
            }
        }
        public bool WhetherFieldIsKnown(int selectedColumn, int selectedRow)
        {
            return knownFieldsByTheUser[selectedColumn, selectedRow] ;
        }
        public void MarkFieldAsKnown(int selectedColumn, int selectedRow)
        {
            knownFieldsByTheUser[selectedColumn, selectedRow] = true;
        }
        //public void CheckField(int selectedColumn, int selectedRow)
        //{
        //    //Tool to check if field was used before, returns true/false
        //    Console.WriteLine(knownFieldsByTheUser[selectedColumn, selectedRow]);
        //}
        public int CheckField(int selectedColumn, int selectedRow)
        {
           return gameBoard[selectedColumn, selectedRow];
        }
        public void BoardDisplay()
        {
            for (int i = 1; i < boardWidth + 1; i++)
            {
                for (int j = 1; j < boardHeight + 1; j++)
                {
                    if (knownFieldsByTheUser[i, j])
                    {
                        Console.Write("(" + i + "," + j + ") = " + gameBoard[i, j]);
                    }
                    else
                    {
                        Console.Write("(" + i + "," + j + ") = ?");
                    }
                }
                Console.Write("\n");
            }
        }
    }
}