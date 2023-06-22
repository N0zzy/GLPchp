using Godot;

namespace GLPchp;

public sealed class UElement
{
    public static Node GetNode(Node node, string path, string prefix = ".")
    {
        return node.GetNode(new NodePath($"{prefix}{GetParseNodePath(path)}"));
    }
    
    public static T GetNode<T>(Node node, string path, string prefix = ".") where T : Node
    { 
        return node.GetNode<T>(new NodePath($"{prefix}{GetParseNodePath(path)}"));
    }
    
    private static string GetParseNodePath(string path)
    {
        if (path.StartsWith(".") || path.StartsWith("/"))
        {
            path = path.Substring(1);
        }
        return "/" + path.Replace('.', '/');
    }

}