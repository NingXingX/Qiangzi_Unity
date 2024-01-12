
//特性类型
public enum FeatureType
{
    //枚举第一项为空 —— —— 0
    NULL, 

    //某个属性N获得百分比(1+X%)加成 —— —— 1
    AddValuePercent,

    //某个属性N获得百分比(1-X%)衰减 —— —— 2
    ReduceStatsPercent,

    //所有武器在攻击时，额外造成N次X%的伤害(相当于伤害=(1+N*X%)*攻击力) —— —— 3
    AllWeaponAttackEffects,

    //某个属性N获得数值上的X加成 —— —— 4
    AddStatsValue,

    //某个属性N获得数值上的X衰减 —— —— 5
    ReduceStatsValue,

    //某个属性固定在X值，且永远不会改变 —— —— 6
    AttributeImmobilization,

    //某个属性获得某个属性A的X%加成 —— —— 7
    AddAttributeConversion,

    //某个属性获得某个属性A的X%衰减 —— —— 8
    ReduceAttributeConversion,

    //所有武器在攻击时，额外造成X%某种伤害 —— —— 9
    WeaponBonusDamage,

    //造成某种伤害时获得百分比加成 —— —— 10
    SpecificDamageUp,

    //造成某种伤害时获得百分比衰减 —— —— 11
    SpecificDamageDown,

    //所有武器在攻击时，额外攻击N次，有X%概率触发 —— —— 12
    ExtraAttackCount

}

public enum IndexToValue
{
    NULL,
    MaxHp,
    HpRegeneration,
    HpSteal,
    MaxShields,
    ShieldsRegeneration,
    ActionNum,//迅捷值
    Speed,//移速
    PhysicalIntensity,
    ManaIntensity,
    ReligiousIntensity,
    ArmorIntensity,
    CritRate,
    HitRate,
    DodgeRate

}



//基础特性,所有BUFF的基类,所有BUFF的基类,所有BUFF的基类,所有BUFF的基类,所有BUFF的基类,所有BUFF的基类
public abstract class BaseFeature
{
    public Role OwnRole;
    public int TargetValueId;
    public float ChangeValue;

    abstract public FeatureType GetFeatureType();

    public abstract void CalcBuff();

    public int GetValue(int index)
    {
        var fieldName = ((IndexToValue)index).ToString();
        var fieldInfo = typeof(Role).GetField(fieldName);

        return (int)fieldInfo.GetValue(this.OwnRole);
    }

    public void SetValue(int index, int value)
    {
        var fieldName = ((IndexToValue)index).ToString();
        var fieldInfo = typeof(Role).GetField(fieldName);

        fieldInfo.SetValue(this.OwnRole, value);
    }
}


//某个属性N获得百分比(1+X%)加成 —— —— 1
class AddValuePercent : BaseFeature
{
    public override FeatureType GetFeatureType()
    {
        return FeatureType.AddValuePercent;
    }
    
    public override void CalcBuff()
    {
        int oldValue = this.GetValue(this.TargetValueId);
        this.SetValue(this.TargetValueId, (int)(oldValue * (1f + this.ChangeValue)));
    }
}

//某个属性N获得百分比(1-X%)衰减 —— —— 2
class ReduceStatsPercent : BaseFeature
{
    public override FeatureType GetFeatureType()
    {
        return FeatureType.ReduceStatsPercent;
    }

    public override void CalcBuff()
    {
        int oldValue = this.GetValue(this.TargetValueId);
        this.SetValue(this.TargetValueId, (int)(oldValue * (1f - this.ChangeValue)));
    }
}

//所有武器在攻击时，额外造成N次X%的伤害(相当于伤害=(1+N*X%)*攻击力) —— —— 3
class AllWeaponAttackEffects : BaseFeature
{
    public override FeatureType GetFeatureType()
    {
        return FeatureType.AllWeaponAttackEffects;
    }

    public override void CalcBuff()
    {

    }
}

//某个属性N获得数值上的X加成 —— —— 4
class AddStatsValue : BaseFeature
{
    public override FeatureType GetFeatureType()
    {
        return FeatureType.AddStatsValue;
    }

    public override void CalcBuff()
    {
        int oldValue = this.GetValue(this.TargetValueId);
        this.SetValue(this.TargetValueId, (int)(oldValue + this.ChangeValue));
    }
}

//某个属性N获得数值上的X衰减 —— —— 5
class ReduceStatsValue : BaseFeature
{
    public override FeatureType GetFeatureType()
    {
        return FeatureType.ReduceStatsValue;
    }

    public override void CalcBuff()
    {
        int oldValue = this.GetValue(this.TargetValueId);
        this.SetValue(this.TargetValueId, (int)(oldValue - this.ChangeValue));
    }
}

//某个属性固定在X值，且永远不会改变 —— —— 6
class AttributeImmobilization : BaseFeature
{
    public override FeatureType GetFeatureType()
    {
        return FeatureType.AttributeImmobilization;
    }

    public override void CalcBuff()
    {
        int oldValue = this.GetValue(this.TargetValueId);
        this.SetValue(this.TargetValueId, (int)(this.ChangeValue));
    }
}

//某个属性获得某个属性A的X%加成 —— —— 7
class AddAttributeConversion : BaseFeature
{
    public override FeatureType GetFeatureType()
    {
        return FeatureType.AddAttributeConversion;
    }

    public override void CalcBuff()
    {
        int oldValue = this.GetValue(this.TargetValueId);
        this.SetValue(this.TargetValueId, (int)(oldValue + this.ChangeValue));
    }
}

//某个属性获得某个属性A的X%衰减 —— —— 8
class ReduceAttributeConversion : BaseFeature
{
    public override FeatureType GetFeatureType()
    {
        return FeatureType.ReduceAttributeConversion;
    }

    public override void CalcBuff()
    {

    }
}

//所有武器在攻击时，额外造成X%某种伤害 —— —— 9
class WeaponBonusDamage : BaseFeature
{
    public override FeatureType GetFeatureType()
    {
        return FeatureType.WeaponBonusDamage;
    }

    public override void CalcBuff()
    {

    }
}

//造成某种伤害时获得百分比加成 —— —— 10
class SpecificDamageUp : BaseFeature
{
    public override FeatureType GetFeatureType()
    {
        return FeatureType.SpecificDamageUp;
    }

    public override void CalcBuff()
    {

    }
}

//造成某种伤害时获得百分比衰减 —— —— 11
class SpecificDamageDown : BaseFeature
{
    public override FeatureType GetFeatureType()
    {
        return FeatureType.SpecificDamageDown;
    }

    public override void CalcBuff()
    {

    }
}

//所有武器在攻击时，额外攻击N次，有X%概率触发 —— —— 12
class ExtraAttackCount : BaseFeature
{
    public override FeatureType GetFeatureType()
    {
        return FeatureType.ExtraAttackCount;
    }

    public override void CalcBuff()
    {

    }
}


