using Godot;
using Pchp.Core;

namespace GLPchp;

public sealed class UxEvent: Service.Utils
{
    public void On(string @event, PhpValue current, PhpCallable func, PhpArray args = null)
    {
        Execute(@event, current, Callable.From(() => {
            func.Invoke(null, args);
        }));
    }
    
    public void OnListener(string @event, PhpValue current, PhpArray listener, PhpArray args = null)
    {
        Execute(@event, current, Callable.From(() => {
            CallableListener(listener, _bindingFlagsBasic, args);
        }));
    }
    
    public void OnListenerAll(string @event, PhpValue current, PhpArray listener, PhpArray args = null)
    {
        Execute(@event, current, Callable.From(() => {
            CallableListener(listener, _bindingFlagsAll, args);
        }));
    }

    private void Execute(string @event, PhpValue current, Callable callable)
    {
        GodotObject gObj = (GodotObject)current.AsObject(); 
        gObj.Connect(new StringName(@event), callable);
    }
}