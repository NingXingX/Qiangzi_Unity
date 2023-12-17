using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(BoardMapCtrl))]
public class BoardMapCtrlEditor:Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        BoardMapCtrl script = (BoardMapCtrl)target;

        if(GUILayout.Button("预览地图"))
        {
            script.InstantiateBoard();
        }
        if (GUILayout.Button("结束预览"))
        {
            script.DestoryBoard();
        }
    }
}
