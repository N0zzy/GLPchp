using System;
using Godot;

namespace GLPchp;

public class CallableFunc
{
    public Callable From(Action action)
    {
        return Callable.From(action);
    }
}