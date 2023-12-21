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

    public List<MovePlan> CurMovePlan = new List<MovePlan>();
    private Dictionary<(int, int), ulong> curMoveTarget = new Dictionary<(int, int), ulong>();
    private Dictionary<ulong, (int, int)> roleMoveTarget = new Dictionary<ulong, (int, int)>();

    public void EnterNewMoveState()
    {
        this.curMoveTarget.Clear();
        this.roleMoveTarget.Clear();
    }

    public void AddMovePlan(ulong gid, int row, int col)
    {
        if (this.curMoveTarget.ContainsKey((row, col)))
        {
            Debug.Log("目的地已被占用");
            return;
        }
        Role data = RoleSystem.Instance.GetRoleByGid(gid);
        int dis = this.Distance(data, row, col);
        if (dis == 0 || dis > data.Speed)
        {
            Debug.Log("移动距离不能为0或大于速度");
            return;
        }
        this.curMoveTarget[(row, col)] = gid;
        this.roleMoveTarget[gid] = (row, col);
        Debug.Log(string.Format("{0} ready move to {1},{2}", gid, row, col));
    }

    public void GetRoundMove()
    {
        this.CurMovePlan.Clear();
        foreach (var pair in this.roleMoveTarget)
        {
            ulong gid = pair.Key;
            int row = pair.Value.Item1;
            int col = pair.Value.Item2;
            var role = RoleSystem.Instance.GetRoleByGid(gid);
            int dis = this.Distance(role, row, col);
            if (dis == 0)
            {
                continue;
            }
            var curMove = new MovePlan(gid, role.TeamId, role.RowPos, role.ColPos);
            var nxt = GetNextPosition(role, row, col);
            curMove.TargetRow = nxt.Item1;
            curMove.TargetCol = nxt.Item2;
            this.CurMovePlan.Add(curMove);
        }
        this.SortMovePlan();
    }

    private (int, int) GetNextPosition(Role role, int row, int col)
    {
        int tr = role.RowPos;
        int tc = role.ColPos;
        int distance = row - role.RowPos;
        if (distance != 0)
        {
            tr += distance / Mathf.Abs(distance);
        }
        else
        {
            distance = col - role.ColPos;
            tc += distance / Mathf.Abs(distance);
        }
        return (tr, tc);
    }

    private void SortMovePlan()
    {
        //todo
    }

    private int Distance(Role role, int row, int col)
    {
        return Mathf.Abs(row - role.RowPos) + Mathf.Abs(col - role.ColPos);
    }
}
