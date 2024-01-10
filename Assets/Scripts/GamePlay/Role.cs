using System.Collections.Generic;
using UnityEngine;
using System;

public class Role
{
    private CharacterData character;
    private Character_attributeData attribute;

    public ulong Gid = 0;
    public int TeamId = 0;
    public int Id = 0;
    public int Level = 0;
    public int Hp = 0;
    public int MaxHp = 0;
    public int MaxShield = 0;
    public int Shields = 0;
    public int ActionNum = 0;
    public int Speed;
    public int RowPos;
    public int ColPos;
    public List<RoleEquip> EquipList;
    public string CharTitle;
    public string CharName;

    //角色特性Buff列表
    public List<BaseFeature> features = new List<BaseFeature>();

    //新增的变量
    public int GroupID = 0;
    public int HpRegeneration;
    public int HpSteal;
    public int ShieldsRegeneration;
    public int PhysicalIntensity;
    public int ManaIntensity;
    public int ReligiousIntensity;
    public int ArmorIntensity;
    public int CritRate;
    public int HitRate;
    public int DodgeRate;


    public RoleComp OwnComp;

    //初始化
    public void Init(ulong gid, int teamId, int characterID, int level = 1, int rowPos = 0, int colPos = 0)
    {
        this.character = CharacterDataLoader.Instance.GetData(characterID);
        if (this.character == null)
        {
            return;
        }
        this.attribute = Character_attributeDataLoader.Instance.GetData(characterID, characterID * 100 + level);
        if (this.attribute == null)
        {
            this.character = null;
            return;
        }

        this.Gid = gid;
        this.TeamId = teamId;
        this.RowPos = rowPos;
        this.ColPos = colPos;
        this.Speed = this.attribute.Speed;
        this.Id = characterID;
        this.Level = level;
        this.Hp = this.attribute.Hp;
        this.MaxHp = this.attribute.Hp;
        this.MaxShield = this.attribute.Shields;
        this.Shields = this.attribute.Shields;
        this.ActionNum = this.attribute.ActionNum;
        this.EquipList = new List<RoleEquip>();
        this.CharTitle = this.character.CharTitle;
        this.CharName = this.character.CharName;

        //新增变量
        this.GroupID = this.attribute.GroupID;
        this.HpRegeneration = this.attribute.HpRegeneration;
        this.HpSteal = this.attribute.HpSteal;
        this.ShieldsRegeneration = this.attribute.ShieldsRegeneration;
        this.PhysicalIntensity = this.attribute.PhysicalIntensity;
        this.ManaIntensity = this.attribute.ManaIntensity;
        this.ReligiousIntensity = this.attribute.ReligiousIntensity;
        this.ArmorIntensity = this.attribute.ArmorIntensity;
        this.CritRate = this.attribute.CritRate;
        this.HitRate = this.attribute.HitRate;
        this.DodgeRate = this.attribute.DodgeRate;


        this.OwnComp = null;
    }

    //绑定游戏对象
    public void BindComp(RoleComp ownComp)
    {
        this.OwnComp = ownComp;
        if (ownComp.data != this)
        {
            ownComp.BindData(this.Gid);
        }
    }

    //添加装备（暂时没有检查）
    public void AddEquip(int equipId)
    {
        var equipData = new RoleEquip();
        if (equipData == null)
        {
            return;
        }
        equipData.Init(equipId, this.OwnComp);
        this.EquipList.Add(equipData);
    }

    //受伤
    public void GetHurt(int damage)
    {
        int realDamage = Mathf.Min(this.Hp, damage);
        this.Hp -= realDamage;
        //Debug.Log(string.Format("{0} get hurt {1}", this.Gid, realDamage));
        this.OwnComp.UpdataHealth();
    }

    //添加buff给角色
    public void AddBuff(int buffId)
    {
        var buffData = Features_buffDataLoader.Instance.GetData(buffId);

        string buffClassName = "";

        if (buffClassName == null || buffClassName == "")
        {
            return;
        }

        var buffType = Type.GetType(buffClassName);
        var newBuff = Activator.CreateInstance(buffType) as BaseFeature;

        newBuff.OwnRole = this;
        this.features.Add(newBuff);

        this.UpdataState();
    }
    public void AddBuff(string buffClassName)
    {
        if (buffClassName == null || buffClassName == "")
        {
            return;
        }

        var buffType = Type.GetType(buffClassName);
        var newBuff = Activator.CreateInstance(buffType) as BaseFeature;

        newBuff.OwnRole = this;
        this.features.Add(newBuff);

        this.UpdataState();
    }

    //更新状态
    public void UpdataState()
    {
        //在这里写上所有会被buff影响的属性数值
        this.MaxHp = this.attribute.Hp;
        this.Speed = this.attribute.Speed;
        this.MaxShield = this.attribute.Shields;
        this.ActionNum = this.attribute.ActionNum;
        this.HpRegeneration = this.attribute.HpRegeneration;
        this.HpSteal = this.attribute.HpSteal;
        this.ShieldsRegeneration = this.attribute.ShieldsRegeneration;
        this.PhysicalIntensity = this.attribute.PhysicalIntensity;//物理强度
        this.ManaIntensity = this.attribute.ManaIntensity;//魔法强度
        this.ReligiousIntensity = this.attribute.ReligiousIntensity;//虔诚强度
        this.ArmorIntensity = this.attribute.ArmorIntensity;//防御强度
        this.CritRate = this.attribute.CritRate;
        this.HitRate = this.attribute.HitRate;
        this.DodgeRate = this.attribute.DodgeRate;//闪避率


        foreach (var feature in this.features)
        {
            if (feature.GetFeatureType() == FeatureType.AddStatsValue)
            {
                var buff = feature as AddMaxHPValue;
                buff.CalcBuff();
            }
        }
    }
}