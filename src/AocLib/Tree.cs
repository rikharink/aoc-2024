namespace AocLib;

public class Tree<T>(T value)
    where T : notnull
{
    public T Value { get; } = value;
    public List<Tree<T>> Children { get; } = [];

    public bool IsBinary => Children.Count <= 2 && Children.All(c => c.IsBinary);

    public Tree<T> AddChild(T value)
    {
        var child = new Tree<T>(value);
        return AddChild(child);
    }

    public Tree<T> AddChild(Tree<T> child)
    {
        Children.Add(child);
        return child;
    }

    public IEnumerable<T> TraversePreOrder()
    {
        yield return Value;
        foreach (var value in Children.SelectMany(child => child.TraversePreOrder()))
        {
            yield return value;
        }
    }

    public IEnumerable<T> TraversePostOrder()
    {
        foreach (var value in Children.SelectMany(child => child.TraversePostOrder()))
        {
            yield return value;
        }

        yield return Value;
    }

    public IEnumerable<T> TraverseInOrder()
    {
        if (!IsBinary)
        {
            throw new InvalidOperationException("In-order traversal is only supported for binary trees.");
        }

        if (Children.Count > 0)
        {
            foreach (var value in Children[0].TraverseInOrder())
            {
                yield return value;
            }
        }

        yield return Value;
        if (Children.Count <= 1) yield break;

        foreach (var value in Children[1].TraverseInOrder())
        {
            yield return value;
        }
    }

    // ToString adapted from: https://andrewlock.net/creating-an-ascii-art-tree-in-csharp/
    private const string Cross = " ├─";
    private const string Corner = " └─";
    private const string Vertical = " │ ";
    private const string Space = "   ";

    public override string ToString()
    {
        var sb = new StringBuilder();
        ToStringNode(sb, this, "");
        return sb.ToString();

        static void ToStringNode(StringBuilder sb, Tree<T> node, string indent)
        {
            sb.AppendLine($"{node.Value}");
            var numberOfChildren = node.Children.Count;
            for (var i = 0; i < numberOfChildren; i++)
            {
                var isLast = i == numberOfChildren - 1;
                ToStringChildNode(sb, node.Children[i], indent, isLast);
            }
        }

        static void ToStringChildNode(StringBuilder sb, Tree<T> node, string indent, bool isLast)
        {
            sb.Append(indent);
            if (isLast)
            {
                sb.Append(Corner);
                indent += Space;
            }
            else
            {
                sb.Append(Cross);
                indent += Vertical;
            }

            ToStringNode(sb, node, indent);
        }
    }
}