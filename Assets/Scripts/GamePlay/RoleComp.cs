using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Playables;
using UnityEngine.Animations;

public class RoleComp : MonoBehaviour
{
    public Role data;

    public Image RoleImage;

    public Slider Health;
    public Image HealthFill;

    private PlayableGraph playable;
    private AnimationPlayableOutput output;

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

        this.InitPlayAble();
    }

    public void InitPlayAble()
    {
        this.playable = PlayableGraph.Create();
        this.output = AnimationPlayableOutput.Create(playable, "Animation", GetComponent<Animator>());
    }

    public void BindData(ulong gid)
    {
        if (this.data != null)
        {
            this.UnBindData();
        }

        Role role = RoleSystem.Instance.GetRoleByGid(gid);
        this.data = role;
        if (role.OwnComp != this)
        {
            role.BindComp(this);
        }
        this.RegisterEvent();
        this.UpdataPosition();
        this.UpdataHealth();
        this.UpdateImage();
    }

    public void UnBindData()
    {
        this.UnRegisterEvent();
    }

    public void RegisterEvent()
    {
        EventDispatcher dispatcher = EventDispatcher.Instance;
        dispatcher.RegisterTargetEvent(this.data.Gid, TargetEvent.RoleAttackEvent, this.PlayAttackAnimation);
    }

    public void UnRegisterEvent()
    {
        EventDispatcher dispatcher = EventDispatcher.Instance;
        dispatcher.UnRegisterTargetEvent(this.data.Gid, TargetEvent.RoleAttackEvent);
    }

    IEnumerator WaitAnimationDone(Action callback)
    {
        while (!this.playable.IsDone())
        {
            yield return null;
        }

        callback.Invoke();
        yield break;
    }

    public void PlayAttackAnimation(object param, Action callback)
    {
        AnimationClip clip = Resources.Load("ArtAssets/Animation/Test1") as AnimationClip;
        var clipPlayable = AnimationClipPlayable.Create(playable, clip);
        this.output.SetSourcePlayable(clipPlayable);
        this.playable.Play();
        this.StartCoroutine(WaitAnimationDone(callback));
    }

    public void UpdateImage()
    {
        string path = "ArtAssets/Character/" + this.data.Id.ToString();

        var obj = Resources.Load(path);
        if (obj == null)
        {
            Debug.LogWarning($"½ÇÉ«{this.data.Id}Í¼Æ¬Î´ÕÒµ½");
            return;
        }
        var tex = obj as Texture2D;
        if (tex == null)
        {
            Debug.LogWarning("½ÇÉ«Í¼Æ¬¼ÓÔØ³ö´í");
            return;
        }
        var sprite = Sprite.Create(tex, new Rect(0, 0, tex.width, tex.height), new Vector2(0.5f, 0.5f));
        if (sprite == null)
        {
            Debug.LogWarning("½ÇÉ«Í¼Æ¬´´½¨³ö´í");
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
