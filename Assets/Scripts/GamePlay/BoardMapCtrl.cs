using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class VFXParam
{
    public string VFXName;
    public float Length;
    public List<Vector2> Path;
    public float AwaitTime;
}

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

    private Dictionary<ulong, RoleComp> roleCompDic = new Dictionary<ulong, RoleComp>();

    public CellComp ChooseTarget;

    private int cellWidth;
    private int cellHeght;
    private CellComp[,] cellMap;

    private void Awake()
    {
        instance = this;
        this.InitVFX();
    }

    void Start()
    {
        this.ChooseTarget = null;
        this.InstantiateBoard();
    }

    private void OnDestroy()
    {
        this.UninitVFX();
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
        this.roleCompDic[gid] = comp;
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
    public RoleComp GetRoleByGid(ulong gid)
    {
        RoleComp ret;
        if (this.roleCompDic.TryGetValue(gid, out ret))
        {
            return ret;
        }
        return null;
    }

    public Vector2 GetRolePosByGid(ulong gid)
    {
        RoleComp role = this.GetRoleByGid(gid);
        if (role == null)
        {
            return Vector2.zero;
        }
        return new Vector2(role.data.RowPos, role.data.ColPos);
    }

    public Vector2 GetRoleLocalPosByGid(ulong gid)
    {
        RoleComp role = this.GetRoleByGid(gid);
        if (role == null)
        {
            return Vector2.zero;
        }
        return this.CalcCellLocalPos(role.data.RowPos, role.data.ColPos);
    }

    public void OnCellClick(int row, int col)
    {
        Debug.Log((row, col));
        var newTarget = this.cellMap[row, col];
        var oldTarget = this.ChooseTarget;
        this.ChooseTarget = newTarget;
        this.ChooseTargetChange?.Invoke(oldTarget, newTarget);
    }

    #region VFX

    public void InitVFX()
    {
        EventDispatcher.Instance.RegisterGoblalEvent(GoblalEvent.PlayVFXEvent, BeginPlayVFX);
    }

    public void BeginPlayVFX(object param, Action callback)
    {
        VFXParam vfxParam = param as VFXParam;
        if (vfxParam == null)
        {
            return;
        }
        StartCoroutine(PlayVFX(vfxParam));
        //callback.Invoke();
    }

    IEnumerator PlayVFX(VFXParam param)
    {
        float t = 0;
        while (t < param.AwaitTime)
        {
            yield return null;
            t += Time.deltaTime;
        }
        GameObject vfxPrefab = Resources.Load("ArtAssets/VFX/" + param.VFXName) as GameObject;
        VFXComp vfxObject = Instantiate(vfxPrefab, this.transform).GetComponent<VFXComp>();

        vfxObject.Path = param.Path;
        vfxObject.Length = param.Length;

        yield break;
    }

    private void UninitVFX()
    {
        EventDispatcher.Instance.UnRegisterGoblalEvent(GoblalEvent.PlayVFXEvent, BeginPlayVFX);
    }
    #endregion

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
