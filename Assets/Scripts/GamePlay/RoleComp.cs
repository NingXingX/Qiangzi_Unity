using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoleComp : MonoBehaviour
{
    public Role data;

    public Image RoleImage;

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
        this.UpdateImage();
    }

    public void UpdateImage()
    {
        string path = "ArtAssets/Character/" + this.data.Id.ToString();

        var obj = Resources.Load(path);
        if (obj == null)
        {
            Debug.LogWarning($"角色{this.data.Id}图片未找到");
            return;
        }
        var tex = obj as Texture2D;
        if (tex == null)
        {
            Debug.LogWarning("角色图片加载出错");
            return;
        }
        var sprite = Sprite.Create(tex, new Rect(0, 0, tex.width, tex.height), new Vector2(0.5f, 0.5f));
        if (sprite == null)
        {
            Debug.LogWarning("角色图片创建出错");
            return;
        }
        this.RoleImage.sprite = sprite;
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
