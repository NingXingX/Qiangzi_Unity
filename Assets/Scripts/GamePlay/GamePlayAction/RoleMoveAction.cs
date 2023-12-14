using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HutongGames.PlayMaker;

[ActionCategory("GamePlay")]
public class RoleMoveAction : FsmStateAction
{
    private List<MovePlan> moveList;
    private int cnt;

    public override void OnEnter()
    {
        cnt = 0;
        moveList = MovePlanManager.Instance.CurMovePlan;
        StartCoroutine(StartMove());
    }

    private IEnumerator StartMove()
    {
        foreach (var move in this.moveList)
        {
            StartCoroutine(MoveFunc(move));
            yield return new WaitForSeconds(0.5f);
        }
        while (true)
        {
            if (cnt == moveList.Count)
            {
                this.Finish();
                yield break;
            }
            Debug.Log(string.Format("WaitMove {0}/{1}", cnt, moveList.Count));
            yield return new WaitForSeconds(0.5f);
        }
    }

    private IEnumerator MoveFunc(MovePlan move)
    {
        var role = BoardMapCtrl.Instance.GetRoleCompByGid(move.Gid);
        Vector2 curPos = BoardMapCtrl.Instance.CalcCellLocalPos(role.RowPos, role.ColPos);
        Vector2 toPos = BoardMapCtrl.Instance.CalcCellLocalPos(move.TargetRow, move.TargetCol);
        float t = 0;
        var rect = role.transform as RectTransform;
        while (t <= 1)
        {
            t += Time.deltaTime;
            rect.anchoredPosition = Vector2.Lerp(curPos, toPos, Mathf.Clamp01(t));
            yield return null;
        }
        role.RowPos = move.TargetRow;
        role.ColPos = move.TargetCol;
        ++cnt;
        yield break;
    }
}
