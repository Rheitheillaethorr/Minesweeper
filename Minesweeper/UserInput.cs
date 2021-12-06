using System;
using System.Linq;
namespace Minesweeper
{
    public class UserInput
    {
        public int boardWidth { set; get; }
        public int boardHeight { set; get; }
        public int minesCount { set; get; }

        public UserInput()
        {
            boardWidth = 0;
            boardHeight = 0;
            minesCount = 0;
        }
        public int GetBoardWidth()
        {
            Console.WriteLine("Number of columns: ");
            int parsedInt;
            bool successfullyParsed = Int32.TryParse(Console.ReadLine(), out parsedInt);
            if (successfullyParsed)
            {
                boardWidth = parsedInt;
                return boardWidth;
            }
            else
            {
                Console.WriteLine("error, try again");
                return GetBoardWidth();
            }
        }
        public int GetBoardHeight()
        {
            Console.WriteLine("Number of rows: ");
            int parsedInt;
            bool successfullyParsed = Int32.TryParse(Console.ReadLine(), out parsedInt);
            if (successfullyParsed)
            {
                boardHeight = parsedInt;
                return boardHeight;
            }
            else
            {
                Console.WriteLine("error, try again");
                return GetBoardHeight();
            }
        }
        public int GetMinesCount()
        {
            Console.WriteLine("Number of mines: ");
            int parsedInt;
            bool successfullyParsed = Int32.TryParse(Console.ReadLine(), out parsedInt);
            if (successfullyParsed)
            {
                minesCount = parsedInt;
                return minesCount;
            }
            else
            {
                Console.WriteLine("error, try again");
                return GetBoardWidth();
            }
        }
        public int GetColumnFromTheUser()
        {
            Console.WriteLine("Choose column: ");
            Console.WriteLine("Possible choices: 1-" + boardWidth);
            int parsedInt;
            bool successfullyParsed = Int32.TryParse(Console.ReadLine(), out parsedInt);
            if (successfullyParsed && Enumerable.Range(1, boardWidth).Contains(parsedInt))
            { 
                return parsedInt;
            }
            else
            {
                Console.WriteLine("error, try again");
                return GetColumnFromTheUser();
            }
        }
        public int GetRowFromTheUser()
        {
            Console.WriteLine("Choose row: ");
            Console.WriteLine("Possible choices: 1-" + boardHeight);
            int parsedInt;
            bool successfullyParsed = Int32.TryParse(Console.ReadLine(), out parsedInt);
            if (successfullyParsed && Enumerable.Range(1, boardHeight).Contains(parsedInt))
            {
                return parsedInt;
            }
            else
            {
                Console.WriteLine("error, try again");
                return GetRowFromTheUser();
            }
        }

        public string GetFieldFromTheUser(int selectedColumn, int selectedRow)
        {
            Board FieldChecker = new Board(boardWidth, boardHeight, minesCount);
            if (FieldChecker.WhetherFieldIsKnown(selectedColumn, selectedRow))
            {
                Console.WriteLine("This field was already used, choose other field");
                return GetFieldFromTheUser(GetColumnFromTheUser(), GetRowFromTheUser());
            }
            else
            {
                FieldChecker.MarkFieldAsKnown(selectedColumn, selectedRow);
            }
            FieldChecker.CheckField(selectedColumn, selectedRow);
            string connectedField = "(" + selectedColumn + "," + selectedRow + ")";
            Console.WriteLine(connectedField);
            return connectedField;
        }
    }
}
