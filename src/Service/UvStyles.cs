using Godot;

namespace GLPchp.Service;

public abstract class UvStyles: UvStyleTransform
{
    public static Texture2D Icon(string name, string path, bool localTopScene = false)
    {
        return new Texture2D()
        {
            ResourceName = name,
            ResourcePath = path,
            ResourceLocalToScene = localTopScene,
        };
    }
}