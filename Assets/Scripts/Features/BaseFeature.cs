
//特性类型
public enum FeatureType
{

    //某个属性N获得百分比(1+X%)加成 —— —— 1
    AddStatsPercent,

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


//基础特性,所有BUFF的基类,所有BUFF的基类,所有BUFF的基类,所有BUFF的基类,所有BUFF的基类,所有BUFF的基类
public abstract class BaseFeature
{
    public Role OwnRole;

    abstract public FeatureType GetFeatureType();
}


//某个属性N获得百分比(1+X%)加成 —— —— 1
class AddValuePercent : BaseFeature
{
    public override FeatureType GetFeatureType()
    {
        return FeatureType.AddStatsPercent;
    }

    public virtual void CalcBuff()
    {
        
    }
}

//某个属性N获得百分比(1-X%)衰减 —— —— 2
class ReduceValuePercent : BaseFeature
{
    public override FeatureType GetFeatureType()
    {
        return FeatureType.ReduceStatsPercent;
    }

    public virtual void CalcBuff()
    {

    }
}

//所有武器在攻击时，额外造成N次X%的伤害(相当于伤害=(1+N*X%)*攻击力) —— —— 3
class AllWeaponEffect : BaseFeature
{
    public override FeatureType GetFeatureType()
    {
        return FeatureType.AllWeaponAttackEffects;
    }

    public virtual void CalcBuff()
    {

    }
}

//某个属性N获得数值上的X加成 —— —— 4
class StatsAddValue : BaseFeature
{
    public override FeatureType GetFeatureType()
    {
        return FeatureType.AddStatsValue;
    }

    public virtual void CalcBuff()
    {

    }
}

//某个属性N获得数值上的X衰减 —— —— 5
class StatsReduceValue : BaseFeature
{
    public override FeatureType GetFeatureType()
    {
        return FeatureType.ReduceStatsValue;
    }

    public virtual void CalcBuff()
    {

    }
}

//某个属性固定在X值，且永远不会改变 —— —— 6
class ImmobilizationStats : BaseFeature
{
    public override FeatureType GetFeatureType()
    {
        return FeatureType.AttributeImmobilization;
    }

    public virtual void CalcBuff()
    {

    }
}

//某个属性获得某个属性A的X%加成 —— —— 7
class AttributeConversionAdd : BaseFeature
{
    public override FeatureType GetFeatureType()
    {
        return FeatureType.AddAttributeConversion;
    }

    public virtual void CalcBuff()
    {

    }
}

//某个属性获得某个属性A的X%衰减 —— —— 8
class AttributeConversionReduce : BaseFeature
{
    public override FeatureType GetFeatureType()
    {
        return FeatureType.ReduceAttributeConversion;
    }

    public virtual void CalcBuff()
    {

    }
}

//所有武器在攻击时，额外造成X%某种伤害 —— —— 9
class WeaponDamageBonus : BaseFeature
{
    public override FeatureType GetFeatureType()
    {
        return FeatureType.WeaponBonusDamage;
    }

    public virtual void CalcBuff()
    {

    }
}

//造成某种伤害时获得百分比加成 —— —— 10
class UpSpecificDamage : BaseFeature
{
    public override FeatureType GetFeatureType()
    {
        return FeatureType.SpecificDamageUp;
    }

    public virtual void CalcBuff()
    {

    }
}

//造成某种伤害时获得百分比衰减 —— —— 11
class DownSpecificDamage : BaseFeature
{
    public override FeatureType GetFeatureType()
    {
        return FeatureType.SpecificDamageDown;
    }

    public virtual void CalcBuff()
    {

    }
}

//所有武器在攻击时，额外攻击N次，有X%概率触发 —— —— 12
class ExtraCountAttack : BaseFeature
{
    public override FeatureType GetFeatureType()
    {
        return FeatureType.ExtraAttackCount;
    }

    public virtual void CalcBuff()
    {

    }
}


//———————————————————————— 以下为具体BUFF ——————————————————————————————————————

//直接增加最大生命值的数值类BUFF
/*class AddMaxHPValue : AddValueBuffFeature
{

    public float num = 0.3f;//这里读取这个Buff的数值

    public override void CalcBuff()
    {
        this.OwnRole.MaxHp = (int)(this.OwnRole.MaxHp * (1 + num));
    }
}*/

