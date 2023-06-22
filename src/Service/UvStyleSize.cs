using Godot;

namespace GLPchp.Service;

public abstract class UvStyleSize
{
    public static Vector2 Size(float x, float y)
    {
        return new Vector2(x,y);
    }
}