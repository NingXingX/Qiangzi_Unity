using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HutongGames.PlayMaker;

[ActionCategory("GamePlay")]
public class RoleMoveAction : FsmStateAction
{
    private List<MovePlan> moveList;

    public override void OnEnter()
    {
        this.moveList = MovePlanManager.Instance.CurMovePlan;
        StartCoroutine(StartMove());
    }

    private IEnumerator StartMove()
    {
        foreach (var move in this.moveList)
        {
            yield return StartCoroutine(MoveFunc(move));
        }
        this.Finish();
        yield break;
    }

    private IEnumerator MoveFunc(MovePlan move)
    {
        var role = RoleSystem.Instance.GetRoleByGid(move.Gid);
        Vector2 curPos = BoardMapCtrl.Instance.CalcCellLocalPos(role.RowPos, role.ColPos);
        Vector2 toPos = BoardMapCtrl.Instance.CalcCellLocalPos(move.TargetRow, move.TargetCol);
        float t = 0;
        var rect = role.OwnComp.transform as RectTransform;
        while (t <= 1)
        {
            t += Time.deltaTime;
            rect.anchoredPosition = Vector2.Lerp(curPos, toPos, Mathf.Clamp01(t));
            yield return null;
        }
        role.RowPos = move.TargetRow;
        role.ColPos = move.TargetCol;
        yield break;
    }
}
