using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

class CharacterEquipViewComp:MonoBehaviour
{
    public GameObject EquipImage;
    private Role cacheRole;

    public int ShowEquipType;

    private List<(int, Image)> showImage = new List<(int, Image)>(); 
    private List<Image> poolImage = new List<Image>();

    void Start()
    {
        UICharacterStateViewComp.Instance.OnRoleSelectEvent += this.UpdateEquipShow;
    }

    private void Update()
    {
        this.UpdateEquipShow(this.cacheRole);
    }

    private void UpdateEquipShow(Role role)
    {
        this.cacheRole = role;
        if (this.cacheRole == null)
        {
            return;
        }

        var equilList = role.GetEquipByType(this.ShowEquipType);
        while (this.showImage.Count > equilList.Count)
        {
            this.DeleteImageObjectOnBack();
        }
        for (int i = 0; i < this.showImage.Count; ++i)
        {
            if (equilList[i].Id != this.showImage[i].Item1)
            {
                this.UpdateImage(this.showImage[i].Item2, equilList[i].Id);
                this.showImage[i] = (equilList[i].Id, this.showImage[i].Item2);
            }
        }
        while (this.showImage.Count < equilList.Count)
        {
            int cur = this.showImage.Count;
            Image ni = GetNewImageObject();
            this.UpdateImage(ni, equilList[cur].Id);
            this.showImage.Add((equilList[cur].Id, ni));
        }
    }

    private void UpdateImage(Image image, int id)
    {
        string name = string.Format("tile{0:D3}", id % 1000);
        string path = "ArtAssets/Equip/" + name;

        var obj = Resources.Load(path);
        if (obj == null)
        {
            Debug.LogWarning($"武器{name}图片未找到");
            return;
        }
        var tex = obj as Texture2D;
        if (tex == null)
        {
            Debug.LogWarning("武器图片加载出错");
            return;
        }
        var sprite = Sprite.Create(tex, new Rect(0, 0, tex.width, tex.height), new Vector2(0.5f, 0.5f));
        if (sprite == null)
        {
            Debug.LogWarning("武器图片创建出错");
            return;
        }
        image.sprite = sprite;
    }

    Image GetNewImageObject()
    {
        if (this.poolImage.Count > 0)
        {
            Image ret = this.poolImage[this.poolImage.Count - 1];
            this.poolImage.RemoveAt(this.poolImage.Count - 1);
            ret.gameObject.SetActive(true);
            return ret;
        }
        Image ni = Instantiate(EquipImage).GetComponent<Image>();
        ni.transform.SetParent(this.transform);
        ni.transform.localScale = Vector3.one;
        return ni;
    }

    void DeleteImageObjectOnBack()
    {
        Image re = this.showImage[this.showImage.Count - 1].Item2;
        re.gameObject.SetActive(false);
        this.poolImage.Add(re);
        this.showImage.RemoveAt(this.showImage.Count - 1);
    }
}
