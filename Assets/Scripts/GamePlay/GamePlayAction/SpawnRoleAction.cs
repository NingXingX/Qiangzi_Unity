using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HutongGames.PlayMaker;

[ActionCategory("GamePlay")]
public class SpawnRoleAction : FsmStateAction
{

    public GameObject RoleObject;

    public override void OnEnter()
    {
        var board = BoardMapCtrl.Instance;

        //��������Ҫ�Ľ�ɫ��������,�����Ӧ������
        this.DebugSpawnRole(10003, 1, 1, 1, 1, new List<int> { 10017 }, new List<int> { 1000301,1000302 });//����
        this.DebugSpawnRole(10004, 1, 1, 0, 2, new List<int> { 10011 }, new List<int> { 1000401, 1000402, 1000403 });//��ʿ
        this.DebugSpawnRole(10005, 1, 2, 5, 3, new List<int> { 10012 }, new List<int> { 1000501,1000502 });//���ױ�������test��

        //this.DebugSpawnRole(10001, 1, 1, 0, 2, new List<int> { 10011, 10012 });
        //this.DebugSpawnRole(10001, 2, 1, 5, 5, new List<int> { 10013 });

        this.Finish();
    }

    private void DebugSpawnRole(int characterId, int teamId, int level, int row, int col, List<int> equips, List<int> features = null)
    {
        ulong gid = BoardMapCtrl.Instance.SpawnRole(this.RoleObject, teamId, characterId, level, row, col);
        Role role = RoleSystem.Instance.GetRoleByGid(gid);
        foreach(var equipId in equips)
        {
            role.AddEquip(equipId);
        }
        if (features != null)
        {
            foreach (var featureId in equips)
            {
                role.AddBuff(featureId);
            }
        }
    }
}
