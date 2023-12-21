using System.Collections.Generic;

public class RoleSystem
{
    #region Singleton
    static private RoleSystem instance;

    static public RoleSystem Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new RoleSystem();
                instance.Init();
            }
            return instance;
        }
    }
    #endregion

    private ulong gidCnt;
    private Dictionary<ulong, Role> roleDic;

    private void Init()
    {
        this.gidCnt = 1000000;
        this.roleDic = new Dictionary<ulong, Role>();
    }

    public ulong SpawnRole(int team, int characterId, int level = 1, int rowPos = 0, int colPos = 0)
    {
        var role = new Role();
        ulong curGid = this.gidCnt++;
        role.Init(curGid, team, characterId, level, rowPos, colPos);
        this.roleDic[curGid] = role;
        return curGid;
    }

    public Role GetRoleByGid(ulong gid)
    {
        Role ret;
        if (this.roleDic.TryGetValue(gid, out ret))
        {
            return ret;
        }
        return null;
    }

    public Dictionary<ulong, Role> GetRoleDic()
    {
        return this.roleDic;
    }
}