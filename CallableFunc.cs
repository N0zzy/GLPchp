using System;
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
    
    public void On(string @event, PhpValue current, PhpCallable func, PhpValue[] args = null)
    {
        GodotObject gObj = (GodotObject)current.AsObject(); 
        gObj.Connect(new StringName(@event), Callable.From(() =>
        {
            func.Invoke(null, args);
        }));
    }
    
    public void OnListener(string @event, PhpValue current, PhpArray listener, object[] args = null)
    {
        GodotObject gObj = (GodotObject)current.AsObject(); 
        gObj.Connect(new StringName(@event), Callable.From(() =>
        {
            ExecuteListener(listener, _bindingFlagsBasic, args);
        }));
    }
    
    public void OnListenerAll(string @event, PhpValue current, PhpArray listener, object[] args = null)
    {
        GodotObject gObj = (GodotObject)current.AsObject(); 
        gObj.Connect(new StringName(@event), Callable.From(() =>
        {
            ExecuteListener(listener, _bindingFlagsAll, args);
        }));
    }
    
    public static Callable Get(PhpCallable action, PhpValue[] args = null)
    {
        return Callable.From(() =>
        {
            action.Invoke(null, args);
        });
    }
    
    public static Callable GetBind(object current, string func, object[] args = null)
    {
        return Callable.From(() =>
        {
            var methodInfo = current.GetType().GetMethod(func, _bindingFlagsBasic);
            if (methodInfo != null) methodInfo.Invoke(current, args);
        });
    }
    
    public static Callable GetBindAll(object current, string func, object[] args = null)
    {
        return Callable.From(() =>
        {
            var methodInfo = current.GetType().GetMethod(func, _bindingFlagsAll);
            if (methodInfo != null) methodInfo.Invoke(current, args);
        });
    }
    
    public static Callable GetListener(PhpArray listener, object[] args = null)
    {
        return Callable.From(() =>
        {
            ExecuteListener(listener, _bindingFlagsBasic, args);
        });
    }
    
    public static Callable GetListenerAll(PhpArray listener, object[] args = null)
    {
        return Callable.From(() =>
        {
            ExecuteListener(listener, _bindingFlagsAll, args);
        });
    }

    public void Off()
    {
        
    }
    
    private static void ExecuteListener(PhpArray listener, BindingFlags flags, object[] args)
    {
        var listenerObject = listener[0].AsObject();
        var listenerFuncName = listener[1].ToString();
        listenerObject.GetType().GetMethod(listenerFuncName, flags)?.Invoke(listenerObject, args);
    }
}