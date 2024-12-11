namespace Aoc2024.Test;

public class TreeTests
{
    [Fact]
    public void PreOrderTest()
    {
        var tree = BuildTree();
        int[] expected = [1, 2, 4, 5, 3, 6, 7];
        var actual = tree.TraversePreOrder().ToArray();
        actual.Should().Equal(expected);
    }

    [Fact]
    public void InOrderTest()
    {
        var tree = BuildTree();
        int[] expected = [4, 2, 5, 1, 6, 3, 7];
        var actual = tree.TraverseInOrder().ToArray();
        actual.Should().Equal(expected);
    }

    [Fact]
    public void PostOrderTest()
    {
        var tree = BuildTree();
        int[] expected = [4, 5, 2, 6, 7, 3, 1];
        var actual = tree.TraversePostOrder().ToArray();
        actual.Should().Equal(expected);
    }

    [Fact]
    public void ToStringTest()
    {
        var tree = BuildTree();
        var actual = tree.ToString();
        const string expected = """
                                1
                                 ├─2
                                 │  ├─4
                                 │  └─5
                                 └─3
                                    ├─6
                                    └─7

                                """;
        actual.Should().Be(expected);
    }

    private static Tree<int> BuildTree()
    {
        var tree = new Tree<int>(1);
        var two = tree.AddChild(2);
        var three = tree.AddChild(3);
        two.AddChild(4);
        two.AddChild(5);
        three.AddChild(6);
        three.AddChild(7);
        return tree;
    }
}