using Sudoq;


Console.WriteLine("Example sudoku board:");
Console.WriteLine($"{SudokuGenerator.GenerateBoard()}");

Console.WriteLine();

Console.WriteLine("Example sudoku board at difficulty level = 5:");
Console.WriteLine("Available levels: 1-10");
Console.WriteLine($"{SudokuGenerator.GenerateBoard(5)}");
