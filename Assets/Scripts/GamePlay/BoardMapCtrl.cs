using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BoardMapCtrl : MonoBehaviour
{
    private static BoardMapCtrl instance;
    public static BoardMapCtrl Instance
    {
        get
        {
            return instance;
        }
    }

    public int ColNum = 16;
    public int RowNum = 9;
    public int Width = 1280;
    public int Height = 720;
    public GameObject CellObject;

    public UnityAction<CellComp, CellComp> ChooseTargetChange;

    public CellComp ChooseTarget;

    private int cellWidth;
    private int cellHeght;
    private CellComp[,] cellMap;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        this.ChooseTarget = null;
        this.InstantiateBoard();
    }

    public Vector2 CalcCellLocalPos(int row, int col)
    {
        int cellWidth = this.Width / this.ColNum;
        int cellHeght = this.Height / this.RowNum;
        return new Vector2(col * cellWidth, row * cellHeght);
    }

    public void SpawnRoleObject(GameObject role, ulong gid)
    {
        var roleObject = Instantiate(role, this.transform);
        var comp = roleObject.GetComponent<RoleComp>();
        comp.InitObject(this.cellWidth, this.cellHeght);
        comp.BindData(gid);
    }

    public ulong SpawnRole(GameObject role, int team, int characterId, int level = 1, int rowPos = 0, int colPos = 0)
    {
        ulong gid = RoleSystem.Instance.SpawnRole(team, characterId, level, rowPos, colPos);
        this.SpawnRoleObject(role, gid);
        return gid;
    }

    public ulong GetRoleGidAtPos(int row, int col)
    {
        foreach (var pair in RoleSystem.Instance.GetRoleDic())
        {
            ulong gid = pair.Key;
            var comp = pair.Value;
            if (comp.RowPos == row && comp.ColPos == col)
            {
                return gid;
            }
        }
        return 0;
    }

    public void OnCellClick(int row, int col)
    {
        Debug.Log((row, col));
        var newTarget = this.cellMap[row, col];
        var oldTarget = this.ChooseTarget;
        this.ChooseTarget = newTarget;
        this.ChooseTargetChange?.Invoke(oldTarget, newTarget);
    }

    #region Editor
    public void InstantiateBoard()
    {
        this.DestoryBoard();
        var boardRect = this.transform as RectTransform;
        boardRect.sizeDelta = new Vector2(this.Width, this.Height);
        this.cellWidth = this.Width / this.ColNum;
        this.cellHeght = this.Height / this.RowNum;
        this.cellMap = new CellComp[this.RowNum, this.ColNum];
        for (int i = 0; i < this.RowNum; ++i)
        {
            for (int j = 0; j < this.ColNum; ++j)
            {
                Vector2 pos = this.CalcCellLocalPos(i, j);
                var cell = Instantiate(CellObject, this.transform);
                var cellRect = cell.transform as RectTransform;
                cellRect.anchoredPosition = pos;
                cellRect.pivot = Vector2.zero;
                cellRect.anchorMin = Vector2.zero;
                cellRect.anchorMax = Vector2.zero;
                var comp = cell.GetComponent<CellComp>();
                comp.Init(i, j, new Vector2(cellWidth, cellHeght), this);
                cellMap[i, j] = comp;
            }
        }
    }
    public void DestoryBoard()
    {
        if (this.cellMap != null)
        {
            foreach (var cell in cellMap)
            {
                if (cell != null)
                {
                    DestroyImmediate(cell.gameObject);
                }
            }
            this.cellMap = null;
        }
        var cellList = this.transform.GetComponentsInChildren<CellComp>();
        foreach (var cell in cellList)
        {
            DestroyImmediate(cell.gameObject);
        }
    }
    #endregion
}
