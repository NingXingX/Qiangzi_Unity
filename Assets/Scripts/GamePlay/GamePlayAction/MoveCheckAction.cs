using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HutongGames.PlayMaker;

[ActionCategory("GamePlay")]
public class MoveCheckAction : FsmStateAction
{
    public override void OnEnter()
    {
        MovePlanManager.Instance.GetRoundMove();
        var movePlan = MovePlanManager.Instance.CurMovePlan;
        if (movePlan.Count == 0)
        {
            Debug.Log("MoveFinish");
            this.Finish();
            return;
        }
        this.Fsm.BroadcastEvent("NEEDMOVE");
    }
}
