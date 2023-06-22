using Godot;

namespace GLPchp.Service;

public abstract class UvStyleTransform: UvStyleSize
{
    public static Vector2 Position(float x, float y)
    {
        return new Vector2(x,y);
    }
    public static Vector3 Position(float x, float y, float z)
    {
        return new Vector3(x,y,z);
    }
    public static Vector4 Position(float x, float y, float z, float w)
    {
        return new Vector4(x,y,z,w);
    }
    
    public static Vector2 Scale(float x = 1, float y = 1)
    {
        return new Vector2(x,y);
    }
}