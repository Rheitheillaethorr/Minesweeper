using System;
namespace Minesweeper
{
    public class MinesweeperGame
    {
        public void Start()
        {
            UserInput userInput = new UserInput();
            var boardColumns = userInput.GetBoardWidth();
            var boardRows = userInput.GetBoardHeight();
            var minesCount = userInput.GetMinesCount();
            //Mines MinesArrangement = new Mines(boardColumns, boardRows, minesCount);
            //MinesArrangement.SetMines();
            //MinesArrangement.CheckArray();
            Board GameBoard = new Board(boardColumns, boardRows, minesCount);
            GameBoard.CreateBoard();
            GameBoard.CheckBoardMines();
            GameBoard.CheckBoard();
            while (true)
            {
                Console.Clear();
                var fieldSelectedByTheUser = userInput.GetFieldFromTheUser(userInput.GetColumnFromTheUser(), userInput.GetRowFromTheUser());
                Console.ReadKey();
            }
        }
    }
}