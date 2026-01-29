namespace Sudoq;

public class Board
{
    public List<Cell> Cells { get; set; }
    public List<Coordinates2D> Mask { get; set; }


    public Board()
    {
        Cells = new List<Cell>();
        Mask = new List<Coordinates2D>();
    }
    
    
    public void AddCell(Cell b)
    {
        if (HasCellAt(b.Coordinates))
        {
            throw new Exception($"Sudoku already contains rect ({b})!");
        }

        Cells.Add(b);
    }

    public void AddMask(List<Coordinates2D> mask)
    {
        Mask = mask;
    }

    public bool HasCellAt(int row, int col)
    {
        return Cells.Any(x => x.Row == row && x.Column == col);
    }
    
    public bool HasCellAt(Coordinates2D c)
    {
        return HasCellAt(c.Row, c.Column);
    }

    public int GetValueAt(int row, int col)
    {
        var rect = Cells.FirstOrDefault(x => x.Row == row && x.Column == col);

        return rect == null ? 0 : rect.Value;
    }

    public override string ToString()
    {
        var retval = string.Empty;

        for (var x = 0; x < 9; x++)
        {
            if (x == 3 || x == 6)
            {
                retval += Environment.NewLine;
            }

            var line = string.Empty;
            for (var y = 0; y < 9; y++)
            {
                if (y == 3 || y == 6)
                {
                    line += "  ";
                }

                var value = $"{GetValueAt(x, y)}";
                if (Mask.Any(m => m.Row == y && m.Column == x))
                {
                    value = "_";
                }
                line += $"  {value}  ";
            }

            retval += Environment.NewLine;
            retval += line;
            retval += Environment.NewLine;
        }

        return retval;
    }
}
