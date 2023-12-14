using System.Collections.Generic;
using UnityEngine;

 class MovePlan
{
    public ulong Gid;
    public int Team;
    public int TargetRow;
    public int TargetCol;

    public MovePlan(ulong gid, int team, int row, int col)
    {
        this.Gid = gid;
        this.Team = team;
        this.TargetRow = row;
        this.TargetCol = col;
    }
}

class MovePlanManager
{

    

    private static MovePlanManager instance;
    public static MovePlanManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new MovePlanManager();
            }
            return instance;
        }
    }

    private List<MovePlan> inQueue = new List<MovePlan>();
    public List<MovePlan> CurMovePlan = new List<MovePlan>();

    public void AddMovePlan(ulong gid, int team, int row, int col)
    {
        this.inQueue.Add(new MovePlan(gid, team, row, col));
        Debug.Log(string.Format("{0} ready move to {1},{2}", gid, row, col));
    }

    public void GetRoundMove()
    {
        List<MovePlan> waitMovePlan = new List<MovePlan>();
        this.CurMovePlan.Clear();
        foreach (var move in this.inQueue)
        {
            var role = BoardMapCtrl.Instance.GetRoleCompByGid(move.Gid);
            if (role.RowPos == move.TargetRow && role.ColPos == move.TargetCol)
            {
                continue;
            }
            waitMovePlan.Add(move);
            var curMove = new MovePlan(move.Gid, move.Team, role.RowPos, role.ColPos);
            int distance = move.TargetRow - role.RowPos;
            if (distance != 0)
            {
                curMove.TargetRow += distance / Mathf.Abs(distance);
            }
            else
            {
                distance = move.TargetCol - role.ColPos;
                curMove.TargetCol += distance / Mathf.Abs(distance);
            }
            this.CurMovePlan.Add(curMove);
        }
        this.inQueue = waitMovePlan;
    }

}
