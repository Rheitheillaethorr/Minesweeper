using System;
namespace Minesweeper
{
    public class MinesweeperGame
    {
        UserInput userInput = new UserInput();
        public Board GameBoard;
        public void Start()
        {
            int boardColumns = userInput.GetBoardWidth();
            int boardRows = userInput.GetBoardHeight();
            int minesCount = userInput.GetMinesCount();
            //Mines MinesArrangement = new Mines(boardColumns, boardRows, minesCount);
            //MinesArrangement.SetMines();
            //MinesArrangement.CheckArray();
            Board GameBoard = new Board(boardColumns, boardRows, minesCount);
            GameBoard.CreateBoard();
            GameBoard.CheckBoardMines();
            GameBoard.CheckBoard();
            Console.ReadKey();
            bool continueGameCondition = true;
            bool gameWinOrLose = false;
            int possibleCountOfChecks = (boardColumns * boardRows) - minesCount;
            int countOfChecks = 0;
            while (continueGameCondition)
            {
                Console.Clear();
                GameBoard.BoardDisplay();
                if (possibleCountOfChecks == countOfChecks)
                {
                    gameWinOrLose = true;
                    continueGameCondition = false;
                    break;
                }
                var selectedColumn = userInput.GetColumnFromTheUser();
                var selectedRow = userInput.GetRowFromTheUser();
                if (GameBoard.WhetherFieldIsKnown(selectedColumn, selectedRow))
                {
                    Console.WriteLine("This field was already used, choose other field");
                }
                else
                {
                    if (GameBoard.CheckField(selectedColumn, selectedRow) < 9)
                    {

                    }
                    else
                    {
                        continueGameCondition = false;
                    }
                    countOfChecks++;
                    GameBoard.MarkFieldAsKnown(selectedColumn, selectedRow);
                }
                Console.ReadKey();
            }
            if (gameWinOrLose == false)
            {
                Console.WriteLine("Boom, Game is over, you failed!");
            }
            else
            {
                Console.WriteLine("You did well today!");
            }
        }
        
    //    public void CheckField()
    //    {
    //        Console.Clear();
    //        var selectedColumn = userInput.GetColumnFromTheUser();
    //        var selectedRow = userInput.GetRowFromTheUser();
            
    //        if (GameBoard.WhetherFieldIsKnown(selectedColumn, selectedRow))
    //        {
    //            Console.WriteLine("This field was already used, choose other field");
    //            CheckField();
    //        }
    //        else
    //        {
    //            GameBoard.MarkFieldAsKnown(selectedColumn, selectedRow);
    //        }
    //        Console.ReadKey();
    //    }
    }
}