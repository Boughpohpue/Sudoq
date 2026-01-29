namespace Sudoq;

public static class SudokuGenerator
{
    private static readonly Random Rand = new();

    public static Board GenerateBoard()
    {
        return ValuesToBoard(GenerateBoardValues());
    }

    public static Board GenerateBoard(int level)
    {
        var board = GenerateBoard();
        board.AddMask(GenerateBoardMask(level));
        return board;
    }

    private static List<List<int>> GenerateBoardValues()
    {
        var retval = new List<List<int>>();
        
        var completionItems = new CompletionItems();
        
        var lineCombos = GenerateLines(9);

        var boxRowModifier = 0;
        
        while (retval.Count < 9)
        {
            if (retval.Count == 0)
            {
                retval.Add(lineCombos[Rand.Next(0, lineCombos.Count)]);
            }
            else
            {
                var subCombos =
                    lineCombos.Where(x =>
                        !completionItems.ColItems[0].Contains(x[0])
                        && !completionItems.ColItems[1].Contains(x[1])
                        && !completionItems.ColItems[2].Contains(x[2])
                        && !completionItems.ColItems[3].Contains(x[3])
                        && !completionItems.ColItems[4].Contains(x[4])
                        && !completionItems.ColItems[5].Contains(x[5])
                        && !completionItems.ColItems[6].Contains(x[6])
                        && !completionItems.ColItems[7].Contains(x[7])
                        && !completionItems.ColItems[8].Contains(x[8])
                        && !completionItems.BoxItems[boxRowModifier].Contains(x[0])
                        && !completionItems.BoxItems[boxRowModifier].Contains(x[1])
                        && !completionItems.BoxItems[boxRowModifier].Contains(x[2])
                        && !completionItems.BoxItems[boxRowModifier + 1].Contains(x[3])
                        && !completionItems.BoxItems[boxRowModifier + 1].Contains(x[4])
                        && !completionItems.BoxItems[boxRowModifier + 1].Contains(x[5])
                        && !completionItems.BoxItems[boxRowModifier + 2].Contains(x[6])
                        && !completionItems.BoxItems[boxRowModifier + 2].Contains(x[7])
                        && !completionItems.BoxItems[boxRowModifier + 2].Contains(x[8])
                    ).ToList();

                if (subCombos.Count == 0)
                {
                    throw new Exception($"Error while generating sudoku at line {retval.Count}!");
                }
                else if (subCombos.Count == 1)
                {
                    retval.Add(subCombos[0]);
                }
                else
                {
                    retval.Add(subCombos[Rand.Next(0, subCombos.Count)]);
                }
            }

            var addedLine = retval.Last();

            for (var i = 0; i < 9; i++)
            {
                completionItems.ColItems[i][retval.Count - 1] = addedLine[i];
                completionItems.RowItems[retval.Count - 1][i] = addedLine[i];
            }

            completionItems.BoxItems[boxRowModifier].AddRange(addedLine.GetRange(0, 3));
            completionItems.BoxItems[boxRowModifier + 1].AddRange(addedLine.GetRange(3, 3));
            completionItems.BoxItems[boxRowModifier + 2].AddRange(addedLine.GetRange(6, 3));

            if (retval.Count % 3 == 0)
                boxRowModifier += 3;
        }

        return retval;
    }
    
    private static Board ValuesToBoard(List<List<int>> sudokuValues)
    {
        var board = new Board();

        for (var row = 0; row < sudokuValues.Count; row++)
        {
            for (var col = 0; col < sudokuValues[row].Count; col++)
            {
                board.AddCell(new Cell(row, col, sudokuValues[row][col]));
            }
        }

        return board;
    }

    private static List<List<int>> GenerateLines(int length)
    {
        var retval = new List<List<int>>();

        var item = new List<int>();

        for (var x = 0; x < length; x++)
            item.Add(0);

        retval.Add(item);

        return UpdateLines(retval);
    }

    private static List<List<int>> UpdateLines(List<List<int>> lines, int number = 1)
    {
        var retval = new List<List<int>>();

        foreach (var line in lines)
            retval.AddRange(UpdateLine(line, number));

        return retval;
    }

    private static List<List<int>> UpdateLine(List<int> line, int number = 1)
    {
        var retval = new List<List<int>>();

        for (var x = 0; x < line.Count; x++)
        {
            if (line[x] > 0)
                continue;

            var item = new List<int>();
            item.AddRange(line);
            item[x] = number;
            retval.Add(item);
        }

        if (number == line.Count)
            return retval;

        return UpdateLines(retval, number + 1);
    }

    private static List<Coordinates2D> GenerateBoardMask(int level)
    {
        var mask = new List<Coordinates2D>();

        var lvl = Math.Min(Math.Max(level, 1), 9);
        var toHide = 39 + (3 * lvl);
        while (mask.Count < toHide)
        {
            var coordinates = new Coordinates2D(Rand.Next(9), Rand.Next(9));
            if (mask.Any(m => m.Column == coordinates.Column && m.Row == coordinates.Row))
                continue;
            mask.Add(coordinates);
        }

        return mask;
    }
}
