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
        var roleDic = BoardMapCtrl.Instance.GetRoleDic();
        foreach (var pair in roleDic)
        {
            ulong gid = pair.Key;
            RoleComp comp = pair.Value;
            yield return StartCoroutine(RoleFighting(comp));
        }
        this.Finish();
        yield break;
    }

    private IEnumerator RoleFighting(RoleComp comp)
    {
        var equipList = comp.data.EquipList;
        for (int i = 0; i < equipList.Count; ++i)
        {
            yield return StartCoroutine(RoleUseEquip(comp, i));
        }
        yield break;
    }

    private IEnumerator RoleUseEquip(RoleComp comp, int equipIndex)
    {
        Debug.Log(string.Format("Role:{0} use Equip:{1}", comp.Gid, comp.data.EquipList[equipIndex].Id));
        yield break;
    }
}