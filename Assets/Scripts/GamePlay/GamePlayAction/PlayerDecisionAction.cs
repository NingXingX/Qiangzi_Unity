using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HutongGames.PlayMaker;

[ActionCategory("GamePlay")]
public class PlayerDecisionAction : FsmStateAction
{


    public override void OnEnter()
    {
        Debug.Log("EnterPlayerDecision");
        BoardMapCtrl.Instance.ChooseTargetChange = SetRoleMovePlan;
        MovePlanManager.Instance.EnterNewMoveState();
    }

    public override void OnExit()
    {
        BoardMapCtrl.Instance.ChooseTargetChange -= SetRoleMovePlan;
    }

    public override void OnUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            this.Finish();
        }
        var test = RoleSystem.Instance.GetRoleDic();
    }

    private void SetRoleMovePlan(CellComp lst, CellComp nxt)
    {
        if (lst == null || nxt == null)
        {
            return;
        }
        Debug.Log((lst.Row_Id, lst.Col_Id, nxt.Row_Id, nxt.Col_Id));
        ulong roleGid = BoardMapCtrl.Instance.GetRoleGidAtPos(lst.Row_Id, lst.Col_Id);
        if (roleGid == 0)
        {
            return;
        }
        MovePlanManager.Instance.AddMovePlan(roleGid, nxt.Row_Id, nxt.Col_Id);
        BoardMapCtrl.Instance.ChooseTarget = null;
    }
}
