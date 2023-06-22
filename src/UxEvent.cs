using Godot;
using Pchp.Core;

namespace GLPchp;

public sealed class UxEvent: Service.UvPhpCallable
{
    public void On(string @event, PhpValue current, PhpCallable func, PhpArray args = null)
    {
        Execute(@event, current, Callable.From(() => {
            func.Invoke(null, args);
        }));
    }
    
    public void OnListener(string @event, PhpValue current, PhpArray listener, PhpArray args = null)
    {
        listener = GetActive(current, listener);
        Execute(@event, current, Callable.From(() => {
            CallableListener(listener, _bindingFlagsAll, args);
        }));
    }
    
    public void OnScope(string @event, PhpValue current, PhpArray listener, PhpArray args = null)
    {
        listener = GetActive(current, listener);
        Execute(@event, current, Callable.From(() => {
            CallableListener(listener, _bindingFlagsBasic, args);
        }));
    }

    private void Execute(string @event, PhpValue current, Callable callable)
    {
        GodotObject gObj = (GodotObject)current.AsObject(); 
        gObj.Connect(new StringName(@event), callable);
    }
    
    private PhpArray GetActive(PhpValue current, PhpArray listener)
    {
        return (listener[0].IsEmpty) ? new PhpArray() {
            current, 
            listener[1]
        } : listener;
    }
}