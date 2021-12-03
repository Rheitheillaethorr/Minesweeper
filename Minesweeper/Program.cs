using System;

namespace Minesweeper
{
    class Program
    {
        static void Main(string[] args)
        {
            int width = 4;
            int height = 4;
            int Cmines = 5;
            Mines MinesArrangement = new Mines(width, height, Cmines);
            MinesArrangement.SetMines();
            MinesArrangement.CheckArray();
        }
    }
}
