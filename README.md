# Sudoq

A lightweight C# library exposing functions for generating sudoku boards at different levels of difficulty.

## Generating boards

**Sudoq** can generate plain boards and boards with 10 difficulty levels (1-10)


## Examples

**Simple sudoku board:**

```csharp
Console.WriteLine($"{SudokuGenerator.GenerateBoard()}");
```

Output:
```bash
  3    9    1      2    5    6      4    7    8

  5    8    7      1    9    4      3    2    6

  6    4    2      7    3    8      9    5    1


  8    2    3      4    6    5      7    1    9

  4    7    6      9    8    1      2    3    5

  9    1    5      3    7    2      8    6    4


  1    3    4      6    2    9      5    8    7

  2    6    8      5    4    7      1    9    3

  7    5    9      8    1    3      6    4    2
```


**Example sudoku board at difficulty level = 5:**

```csharp
Console.WriteLine($"{SudokuGenerator.GenerateBoard(5)}");
```

Output:
```bash
  1    _    3      _    8    _      _    4    _

  _    _    _      9    1    4      7    _    _

  _    _    _      _    _    _      8    1    9


  _    3    _      _    9    _      6    _    _

  6    _    _      _    _    8      5    _    _

  _    7    _      _    _    _      3    _    _


  _    _    _      1    _    5      4    _    _

  4    _    _      8    2    9      _    _    _

  _    _    _      4    _    _      _    _    _
```



