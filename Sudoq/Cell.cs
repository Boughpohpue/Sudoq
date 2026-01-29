namespace Sudoq;

public class Cell
{
    private int _value;
    private Coordinates2D _coordinates;


    public Cell(Coordinates2D coordinates, int value)
    {
        _value = value;
        _coordinates = coordinates;
    }

    public Cell(int row, int col, int value)
    {
        _value = value; 
        _coordinates = new Coordinates2D(row, col);
    }


    public int Value => _value;
    public int Row => _coordinates.Row;
    public int Column => _coordinates.Column;
    public Coordinates2D Coordinates => _coordinates;
}
