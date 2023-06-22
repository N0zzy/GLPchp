using Godot;

namespace GLPchp;

public sealed class UxScene
{
    private Node Node;

    public UxScene(Node2D node)
    {
        Node = node.GetTree().CurrentScene;
    }

    public Node GetNode(string path, string prefix = ".")
    {
        return UElement.GetNode(Node, path, prefix);
    }

    public T GetNode<T>(string path, string prefix = ".") where T: Node
    {
        return UElement.GetNode<T>(Node, path, prefix);
    }

    public Node Current()
    {
        return Node;
    }
}