using System;
namespace Minesweeper
{
    public class MinesweeperGame
    {
        UserInput userInput = new UserInput();
        private Board GameBoard;
        public void Start()
        {
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
                CheckField();
            }
        }
        private void CheckField()
        {
            Console.Clear();
            var selectedColumn = userInput.GetColumnFromTheUser();
            var selectedRow = userInput.GetRowFromTheUser();
            if (GameBoard.WhetherFieldIsKnown(selectedColumn, selectedRow))
            {
                Console.WriteLine("This field was already used, choose other field");
                return GetFieldFromTheUser(GetColumnFromTheUser(), GetRowFromTheUser());
            }
            else
            {
                GameBoard.MarkFieldAsKnown(selectedColumn, selectedRow);
            }
            Console.ReadKey();
        }
    }
}