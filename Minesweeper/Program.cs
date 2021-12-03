using System;

namespace Minesweeper
{
    class Program
    {
        static void Main(string[] args)
        {
            UserInput userInput = new UserInput();
            var boardColumns = userInput.GetBoardWidth();
            var boardRows = userInput.GetBoardHeight();
            var minesCount = userInput.GetMinesCount();
            Mines MinesArrangement = new Mines(boardColumns, boardRows, minesCount);
            MinesArrangement.SetMines();
            MinesArrangement.CheckArray();
        }
    }
}
