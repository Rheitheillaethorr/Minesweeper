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

        public Board(int width, int height, int Cmines)
        {
            boardWidth = width;
            boardHeight = height;
            minesCount = Cmines;
            gameBoard = new int[boardWidth+2, boardHeight+2];
            whereMines = new bool[boardWidth, boardHeight];
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
        public void CheckBoard()
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
        public void CheckBoardX()
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
    }
}