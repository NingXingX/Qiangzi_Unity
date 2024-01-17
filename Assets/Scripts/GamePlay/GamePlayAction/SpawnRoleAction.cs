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
        /*this.DebugSpawnRole(10003, 1, 1, 1, 1, new List<int> { 10017 }, new List<int> { 1000301,1000302 });//����
        this.DebugSpawnRole(10004, 1, 1, 0, 2, new List<int> { 10011 }, new List<int> { 1000401,1000402, 1000403 });//��ʿ
        this.DebugSpawnRole(10005, 2, 1, 4, 5, new List<int> { 10012 }, new List<int> { 1000501, 1000502 });//���ױ������ˣ�*/

        int friendindex = 3;
        int enemyindex = 2;
        for ( int i = 0; i < friendindex; i ++)
        {
            TestRoleSpawn(1);
        }
        for (int i = 0; i < enemyindex; i++)
        {
            TestRoleSpawn(2);
        }

        /*this.DebugSpawnRole(10003, 1, 1, 1, 1, new List<int> { 10017 }, new List<int> { 1000301,1000302 });//����
        this.DebugSpawnRole(10004, 1, 1, 0, 2, new List<int> { 10011 }, new List<int> { 1000401, 1000402, 1000403 });//��ʿ
        this.DebugSpawnRole(10005, 1, 2, 5, 3, new List<int> { 10012 }, new List<int> { 1000501,1000502 });//���ױ�������test��*/

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
            foreach (var featureId in features)
            {
                role.AddBuff(featureId);
            }
        }
    }

    //�����ã�����һ�������ɫ�����̣�����DebugSpawnRole����
    public void TestRoleSpawn(int team)
    {
        int cha = Random.Range(10003,10006);//�����ɫ
        //int team = Random.Range(1, 3);//�������
        int row1 = Random.Range(0, 8); //�����
        int col1 = Random.Range(0, 14);//�����
        List<int> equip = new List<int>();
        List<int> fea = new List<int>();

        if ( cha == 10003 )
        {
            equip = new List<int> { 10017 };
            fea = new List<int> { 1000301, 1000302 };
        }
        else if ( cha == 10004 )
        {
            equip = new List<int> { 10011 };
            fea = new List<int> { 1000401, 1000402, 1000403 };
        }
        else if ( cha == 10005 )
        {
            equip = new List<int> { 10012 };
            fea = new List<int> { 1000501, 1000502 };
        }

        //���������ɫ������
        DebugSpawnRole(cha, team, 1, row1, col1, equip, fea);
    }
}
