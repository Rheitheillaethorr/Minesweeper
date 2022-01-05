using System;
using System.Media;
namespace Minesweeper
{
    public class MinesweeperGame
    {
        UserInput userInput = new UserInput();
        public Board GameBoard;
        public void Start()
        {
            Console.WriteLine("Press any key to play!");
            Console.ReadKey();
            SoundPlayer mainSong = new SoundPlayer(@"D:\Programy\VisualStudio\Projects\Minesweeper\Minesweeper\sound\song2.wav");
            mainSong.Play();
            int boardColumns = userInput.GetBoardWidth();
            int boardRows = userInput.GetBoardHeight();
            int minesCount = userInput.GetMinesCount();
            while (minesCount > (boardColumns * boardRows)-1 || minesCount<1)
            {
                Console.WriteLine("Incorrect number of mines! You can use number between 1-" + ((boardColumns * boardRows)-1));
                minesCount = userInput.GetMinesCount();
            }
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
            while (continueGameCondition)
            {
                //userInput.ActionOfUser();
                Console.Clear();
                GameBoard.BoardDisplay("?");
                if (possibleCountOfChecks == GameBoard.CountNumberOfChecked())
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
                        GameBoard.MarkFieldAsKnown(selectedColumn, selectedRow);
                        GameBoard.CheckForZeroAround(selectedColumn, selectedRow);
                    }
                    else
                    {
                        continueGameCondition = false;
                    } 
                }
                Console.ReadKey();
            }
            if (gameWinOrLose == false)
            {
                Console.WriteLine("Boom, game is over, you failed!");
            }
            else
            {
                Console.Clear();
                Console.WriteLine("You did well today!");
                GameBoard.BoardDisplay("m");
                Console.ReadKey();
            }
        }
    }
}