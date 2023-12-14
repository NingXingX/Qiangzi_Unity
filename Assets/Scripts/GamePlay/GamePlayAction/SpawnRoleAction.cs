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
        board.SpawnRole(RoleObject, 1, 1, 1);
        board.SpawnRole(RoleObject, 8, 8, 2);
        this.Finish();
    }
}
