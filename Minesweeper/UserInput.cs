using System;

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
}