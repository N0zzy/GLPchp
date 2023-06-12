using System.Reflection;
using Godot;
using Pchp.Core;
using static System.Reflection.BindingFlags;

namespace GLPchp;

public class CallableFunc
{
    private static readonly BindingFlags _bindingFlagsBasic =
        Instance | Static | NonPublic;
    private static readonly BindingFlags _bindingFlagsAll =
        Instance | Static | Public | NonPublic;
    
    /// <summary>
    ///
    /// </summary>
    /// <param name="event"></param>
    /// <param name="current"></param>
    /// <param name="func"></param>
    /// <param name="args"></param>
    public void On(string @event, PhpValue current, PhpCallable func, PhpValue[] args = null)
    {
        GodotObject gObj = (GodotObject)current.AsObject(); 
        gObj.Connect(new StringName(@event), Callable.From(() =>
        {
            func.Invoke(null, args);
        }));
    }
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="event"></param>
    /// <param name="current"></param>
    /// <param name="listener"></param>
    /// <param name="args"></param>
    public void OnListener(string @event, PhpValue current, PhpArray listener, PhpValue[] args = null)
    {
        GodotObject gObj = (GodotObject)current.AsObject(); 
        gObj.Connect(new StringName(@event), Callable.From(() =>
        {
            ExecuteListener(listener, _bindingFlagsBasic, args);
        }));
    }
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="event"></param>
    /// <param name="current"></param>
    /// <param name="listener"></param>
    /// <param name="args"></param>
    public void OnListenerAll(string @event, PhpValue current, PhpArray listener, PhpValue[] args = null)
    {
        GodotObject gObj = (GodotObject)current.AsObject(); 
        gObj.Connect(new StringName(@event), Callable.From(() =>
        {
            ExecuteListener(listener, _bindingFlagsAll, args);
        }));
    }
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="action"></param>
    /// <param name="args"></param>
    /// <returns></returns>
    public static Callable Get(PhpCallable action, PhpValue[] args = null)
    {
        return Callable.From(() =>
        {
            action.Invoke(null, args);
        });
    }
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="current"></param>
    /// <param name="func"></param>
    /// <param name="args"></param>
    /// <returns></returns>
    public static Callable GetBind(object current, string func, PhpValue[] args = null)
    {
        return Callable.From(() =>
        {
            __InvokeGet(current,_bindingFlagsBasic, func, args);
        });
    }
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="current"></param>
    /// <param name="func"></param>
    /// <param name="args"></param>
    /// <returns></returns>
    public static Callable GetBindAll(object current, string func, PhpValue[] args = null)
    {
        return Callable.From(() =>
        {
            __InvokeGet(current,_bindingFlagsAll, func, args);
        });
    }
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="listener"></param>
    /// <param name="args"></param>
    /// <returns></returns>
    public static Callable GetListener(PhpArray listener, PhpValue[] args = null)
    {
        return Callable.From(() =>
        {
            ExecuteListener(listener, _bindingFlagsBasic, args);
        });
    }
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="listener"></param>
    /// <param name="args"></param>
    /// <returns></returns>
    public static Callable GetListenerAll(PhpArray listener, PhpValue[] args = null)
    {
        return Callable.From(() =>
        {
            ExecuteListener(listener, _bindingFlagsAll, args);
        });
    }

    /// <summary>
    /// 
    /// </summary>
    public void Off()
    {
        
    }
    
    private static void ExecuteListener(PhpArray listener, BindingFlags flags, PhpValue[] args = null)
    {
        var listenerObject = listener[0].AsObject();
        var listenerFuncName = listener[1].ToString();
        __InvokeListener(listenerObject, listenerFuncName, flags, args);
    }

    private static void __InvokeGet(object current, BindingFlags flags, string func, PhpValue[] args)
    {
        var methodInfo = current.GetType().GetMethod(func, _bindingFlagsAll);
        if (methodInfo != null) methodInfo.Invoke(current, CombineArgs(args));
    }

    private static void __InvokeListener(object listenerObject, string listenerFuncName, BindingFlags flags, PhpValue[] args)
    {
        listenerObject.GetType().GetMethod(listenerFuncName, flags)?.Invoke(listenerObject, CombineArgs(args));
    }

    private static object[] CombineArgs(PhpValue[] args)
    {
        object[] o= {};
        if (args == null)
        {
            o = null;
        }
        else
        {
            for (int i = 0; i < args.Length; i++)
            {
                o[i] = args[i];
            }
        }

        return o;
    }
}