using System.Collections;
using UnityEngine;
using HutongGames.PlayMaker;

[ActionCategory("GamePlay")]
public class FightAction:FsmStateAction
{
    public override void OnEnter()
    {
        base.OnEnter();
        StartCoroutine(Fighting());
    }

    private IEnumerator Fighting()
    {
        var roleDic = RoleSystem.Instance.GetRoleDic();
        foreach (var pair in roleDic)
        {
            ulong gid = pair.Key;
            Role role = pair.Value;
            yield return StartCoroutine(RoleFighting(role));
        }
        this.Finish();
        yield break;
    }

    private IEnumerator RoleFighting(Role role)
    {
        var equipList = role.EquipList;
        for (int i = 0; i < equipList.Count; ++i)
        {
            yield return StartCoroutine(RoleUseEquip(role, i));
        }
        yield break;
    }

    private IEnumerator RoleUseEquip(Role role, int equipIndex)
    {
        //Debug.Log(string.Format("Role:{0} use Equip:{1}", role.Gid, role.EquipList[equipIndex].Id));
        RoleEquip equip = role.EquipList[equipIndex];
        var roleDic = RoleSystem.Instance.GetRoleDic();
        foreach (var pair in roleDic)
        {
            ulong gid = pair.Key;
            if (gid == role.Gid)
            {
                continue;
            }
            Role other = pair.Value;
            if (other.TeamId == role.TeamId)
            {
                continue;
            }
            if (this.Distance(role, other) > equip.AttackRange)
            {
                continue;
            }
            for (int i = 0; i < equip.AttackSpeed; ++i)
            {
                yield return StartCoroutine(RoleAttack(role, equip, other));
            }
            break;
        }
        yield break;
    }

    private IEnumerator RoleAttack(Role role, RoleEquip equip, Role target)
    {
        target.GetHurt(equip.BaseAttack);
        Debug.Log(string.Format("{0} use {1} attack {2}. damage{3} hurter leave {4}", role.Gid, equip.Id, target.Gid, equip.BaseAttack,target.Hp));
        yield return new WaitForSeconds(0.3f);
    }

    private int Distance(Role role1, Role role2)
    {
        return Mathf.Abs(role2.RowPos - role1.RowPos) + Mathf.Abs(role2.ColPos - role1.ColPos);
    }
}