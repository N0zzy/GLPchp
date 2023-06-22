using System;
using System.Reflection;
using Godot;
using Pchp.Core;

namespace GLPchp.Service;

public abstract class UvPhpCallable
{
    protected static readonly BindingFlags _bindingFlagsBasic =
        BindingFlags.Instance | BindingFlags.NonPublic;
    protected static readonly BindingFlags _bindingFlagsAll =
        BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic;

    protected static object[] ObjectArgs(PhpArray args = null)
    {
        object[] o = new object[]{};
        if (args != null)
        {
            Array.Resize(ref o, args.Count);
            var i = 0;
            foreach (var value in args.Values)
            {
                o[i] = value;
                i++;
            }
        }
        return o;
    }

    protected static PhpValue[] PhpValueArgs(PhpArray args = null)
    {
        PhpValue[] o = new PhpValue[]{};
        if (args != null)
        {
            Array.Resize(ref o, args.Count);
            var i = 0;
            foreach (var value in args.Values)
            {
                o[i] = value;
                i++;
            }
        }
        return o;
    }
    
    protected static void CallableListener(PhpArray listener, BindingFlags flags, PhpArray args = null)
    {
        var listenerObject = listener[0];
        var listenerFuncName = listener[1].ToString();
        CallableInvoke(listenerObject, listenerFuncName, flags, args);
    }

    protected static void CallableInvoke(PhpValue current, string func, BindingFlags flags, PhpArray args = null)
    {
        MethodInfo m = current.AsObject().GetType().GetMethod(func, flags);
        if (m == null) return;
        m!.Invoke(current.AsObject(), ObjectArgs(args));
    }
}