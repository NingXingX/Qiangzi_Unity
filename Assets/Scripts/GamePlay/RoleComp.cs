using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoleComp : MonoBehaviour
{
    public Role data;

    public Slider Health;
    public Image HealthFill;

    private RectTransform root;

    public void InitObject(int cellWidth, int cellHeight)
    {
        this.data = new Role();

        this.root = transform as RectTransform;
        this.root.pivot = Vector2.zero;
        this.root.anchorMin = Vector2.zero;
        this.root.anchorMax = Vector2.zero;
        this.root.sizeDelta = new Vector2(cellWidth, cellHeight);
        this.root.anchoredPosition = Vector2.zero;
    }

    public void BindData(ulong gid)
    {
        Role role = RoleSystem.Instance.GetRoleByGid(gid);
        this.data = role;
        if (role.OwnComp != this)
        {
            role.BindComp(this);
        }
        this.UpdataPosition();
        this.UpdataHealth();
    }

    public void UpdataHealth()
    {
        this.HealthFill.color = this.data.TeamId == 1 ? Color.green : Color.red;
        this.Health.value = this.data.Hp * 1.0f / this.data.MaxHp;
    }

    public void UpdataPosition()
    {
        this.root.anchoredPosition = BoardMapCtrl.Instance.CalcCellLocalPos(this.data.RowPos, this.data.ColPos);
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.UpdataHealth();
    }
}
