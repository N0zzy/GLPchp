using Godot;
using Pchp.Core;

namespace GLPchp;

public sealed class UFunc: Service.UvPhpCallable
{
    public static Callable Add(PhpCallable action, PhpArray args = null)
    {
        return Callable.From(() =>
        {
            action.Invoke(null, PhpValueArgs(args));
        });
    }
    
    public static Callable Bind(PhpValue current, string func, PhpArray args = null)
    {
        return Callable.From(() =>
        {
            CallableInvoke(current, func, _bindingFlagsBasic, args);
        });
    }
    
    public static Callable BindAll(PhpValue current, string func, PhpArray args = null)
    {
        return Callable.From(() =>
        {
            CallableInvoke(current, func, _bindingFlagsAll, args);
        });
    }
    
    public static Callable Listener(PhpArray listener, PhpArray args = null)
    {
        return Callable.From(() =>
        {
            CallableListener(listener, _bindingFlagsBasic, args);
        });
    }
    
    public static Callable ListenerAll(PhpArray listener, PhpArray args = null)
    {
        return Callable.From(() =>
        {
            CallableListener(listener, _bindingFlagsAll, args);
        });
    }
}