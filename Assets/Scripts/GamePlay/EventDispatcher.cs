using System;
using System.Collections.Generic;

public enum GoblalEvent
{
    PlayVFXEvent,
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
    private Dictionary<GoblalEvent, Action<object, Action>> goblalTable = new Dictionary<GoblalEvent, Action<object, Action>>();

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


    public void RegisterGoblalEvent(GoblalEvent et, Action<object, Action> func)
    {
        Action<object, Action> cur;
        if (this.goblalTable.TryGetValue(et, out cur))
        {
            this.goblalTable[et] += func;
            return;
        }
        this.goblalTable[et] = func;
    }

    public void UnRegisterGoblalEvent(GoblalEvent et, Action<object, Action> func)
    {
        this.goblalTable[et] -= func;
    }

    public void DispatchGoblalEvent(GoblalEvent et, object param = null, Action callback = null)
    {
        Action<object, Action> cur;
        if (!this.goblalTable.TryGetValue(et, out cur))
        {
            return;
        }

        cur.Invoke(param, callback);
    }

}
