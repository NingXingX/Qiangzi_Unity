using System;
using System.Collections.Generic;

public enum GoblalEvent
{
    
}

public enum TargetEvent
{
    RoleAttackEvent,
}

public class EventDispatcher
{
    static private EventDispatcher instance;

    static public EventDispatcher Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new EventDispatcher();
            }
            return instance;
        }
    }
    private Dictionary<(ulong, TargetEvent), Action<object, Action>> targetTable = new Dictionary<(ulong, TargetEvent), Action<object, Action>>();

    public void RegisterTargetEvent(ulong gid, TargetEvent et, Action<object, Action> func)
    {
        this.targetTable[(gid, et)] = func;
    }

    public void UnRegisterTargetEvent(ulong gid, TargetEvent et)
    {
        this.targetTable[(gid, et)] = null;
    }

    public void DispatchTargetEvent(ulong gid, TargetEvent et, object param = null, Action callback = null)
    {
        Action<object, Action> cur;
        if (!this.targetTable.TryGetValue((gid, et), out cur))
        {
            return;
        }

        cur.Invoke(param, callback);
    }

}
