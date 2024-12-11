namespace AocLib.Test;

public class GridTests
{
    [Fact]
    public void GetNeighboursTest()
    {
        var grid = new Grid<char>(3, 3, ['A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I']);

        var neighboursMiddle = grid.GetNeighbours((1, 1), true);
        neighboursMiddle.Should().BeEquivalentTo<char>(['A', 'B', 'C', 'D', 'F', 'G', 'H', 'I']);
        var neighboursMiddleNoDiagonal = grid.GetNeighbours((1, 1), false);
        neighboursMiddleNoDiagonal.Should().BeEquivalentTo<char>(['B', 'D', 'F', 'H']);

        var neighboursTopLeft = grid.GetNeighbours((0, 0), true);
        neighboursTopLeft.Should().BeEquivalentTo<char>(['B', 'D', 'E']);
        var neighboursTopLeftNoDiagonal = grid.GetNeighbours((0, 0), false);
        neighboursTopLeftNoDiagonal.Should().BeEquivalentTo<char>(['B', 'D']);
    }

    [Fact]
    public void GetDiagonalNeighboursTest()
    {
        var grid = new Grid<char>(3, 3, ['A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I']);

        var neighboursMiddle = grid.GetDiagonalNeighbours((1, 1));
        neighboursMiddle.Should().BeEquivalentTo<char>(['A', 'C', 'G', 'I']);

        var neighboursTopLeft = grid.GetDiagonalNeighbours((0, 0));
        neighboursTopLeft.Should().BeEquivalentTo<char>(['E']);
    }

    [Fact]
    public void GetRunTest()
    {
        var grid = new Grid<char>(8, 8,
        [
            'X', 'M', 'A', 'S', 'S', 'A', 'M', 'X',
            'X', 'M', 'A', 'S', 'S', 'A', 'M', 'X',
            'X', 'M', 'A', 'S', 'S', 'A', 'M', 'X',
            'X', 'M', 'A', 'S', 'S', 'A', 'M', 'X',
            'X', 'M', 'A', 'S', 'S', 'A', 'M', 'X',
            'X', 'M', 'A', 'S', 'S', 'A', 'M', 'X',
            'X', 'M', 'A', 'S', 'S', 'A', 'M', 'X',
            'X', 'M', 'A', 'S', 'S', 'A', 'M', 'X'
        ]);

        var runRight = grid.GetRun((0, 0), Direction.Right, 4);
        runRight.Should().BeEquivalentTo<char>(['X', 'M', 'A', 'S']);

        var runDown = grid.GetRun((0, 0), Direction.Down, 4);
        runDown.Should().BeEquivalentTo<char>(['X', 'X', 'X', 'X']);

        var runDiagonal = grid.GetRun((0, 0), Direction.DownRight, 4);
        runDiagonal.Should().BeEquivalentTo<char>(['X', 'M', 'A', 'S']);
    }

    [Fact]
    public void GridEquals()
    {
        const string input = """
                             ....#.....
                             .........#
                             ..........
                             ..#.......
                             .......#..
                             ..........
                             .#..^.....
                             ........#.
                             #.........
                             ......#...
                             """;
        var grid1A = input.ToGrid();
        var grid1B = input.ToGrid();
        Assert.Equal(grid1A, grid1B);

        var grid2A = input.ToGrid();
        var grid2B = grid2A.Clone();
        Assert.Equal(grid2A, grid2B);

        var grid3A = input.ToGrid();
        grid3A[1, 1] = 'X';
        var grid3B = input.ToGrid();
        grid3B[1, 1] = 'X';
        Assert.Equal(grid3A, grid3B);


        var grid4A = input.ToGrid();
        var grid4B = input.ToGrid();
        Assert.Equal(grid4A.GetHashCode(), grid4B.GetHashCode());
    }
}