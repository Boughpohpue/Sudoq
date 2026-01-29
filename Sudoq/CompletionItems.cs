namespace Sudoq;

public class CompletionItems
{
    public List<List<int>> BoxItems { get; set; }
    public List<List<int>> RowItems { get; set; }
    public List<List<int>> ColItems { get; set; }

    public CompletionItems()
    {
        BoxItems = new List<List<int>>();
        RowItems = new List<List<int>>();
        ColItems = new List<List<int>>();
        for (var i = 0; i < 9; i++)
        {
            BoxItems.Add(new List<int>());
            RowItems.Add(new List<int>());
            ColItems.Add(new List<int>());
            for (var j = 0; j < 9; j++)
            {
                RowItems[i].Add(0);
                ColItems[i].Add(0);
            }
        }
    }
}
