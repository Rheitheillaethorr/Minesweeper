using System;
namespace Minesweeper
{
    public class Mines
    {
        public bool[,] minesBoard { get; set; }
        public int boardWidth { get; set; }
        public int boardHeight { get; set; }
        public int minesCount { get; set; }
        public Mines(int width, int height, int Cmines)
        {
            boardWidth = width;
            boardHeight = height;
            minesCount = Cmines;
            minesBoard = new bool[boardWidth, boardHeight];
        }
        public bool[,] SetMines()
        {
            if (minesCount > 0)
            {
                for (int i = 0; i < boardWidth; i++)
                {
                    for (int j = 0; j < boardHeight; j++)
                    {
                        Random rnd = new Random();
                        int RandomNumber = rnd.Next(0, boardHeight);
                        if (minesBoard[i, j] != true)
                        {
                            if (RandomNumber == 1 && minesCount > 0)
                            {
                                minesBoard[i, j] = true;
                                minesCount--;
                            }
                            else
                            {
                                minesBoard[i, j] = false;
                            }
                        }
                    }
                }
                if (minesCount > 0)
                {
                    SetMines();
                }
            }
            return minesBoard;
        }
        public void CheckArray()
        {
            for (int i = 0; i < boardWidth; i++)
            {
                for (int j = 0; j < boardHeight; j++)
                {
                    Console.Write("(" + i + "," + j + ") = " + minesBoard[i, j]);
                }
                Console.Write("\n");
            }
            Console.Write("mines to use = " + minesCount);
        }
    }
}
