
//特性类型
public enum FeatureType
{
    //增加属性数值
    AddStatsValue,
    //增加属性数值百分比
    AddStatsPercent,
    //减少属性数值
    ReduceStatsValue,
    //减少属性数值百分比
    ReduceStatsPercent,
    //攻击移动受击等时刻(概率或非概率)触发的特性
    ProbabilisticTrigger,
    //改变承受或造成伤害类型
    ChangeDamageType,
    //附带攻击特效类
    AttackEffect,
    //属性转化类，比如： 获得 物理强度20% 的 防御强度
    AttributeConversion,
    //固定某项属性
    AttributeImmobilization,
    //角色装备特定装备后触发的特性
    EquipBySpecial

}


//基础特性,所有BUFF的基类,所有BUFF的基类,所有BUFF的基类,所有BUFF的基类,所有BUFF的基类,所有BUFF的基类
public abstract class BaseFeature
{
    public Role OwnRole;

    abstract public FeatureType GetFeatureType();
}


//增加某项属性数值类
class AddValueBuffFeature : BaseFeature
{
    public override FeatureType GetFeatureType()
    {
        return FeatureType.AddStatsValue;
    }

    public virtual void CalcBuff()
    {
        
    }
}

//增加属性数值百分比类
class AddValuePercentBuffFeature : BaseFeature
{
    public override FeatureType GetFeatureType()
    {
        return FeatureType.AddStatsPercent;
    }

    public virtual void CalcBuff()
    {

    }
}

//属性转化类
class AttributeConversion : BaseFeature
{
    public override FeatureType GetFeatureType()
    {
        return FeatureType.AttributeConversion;
    }

    public virtual void CalcBuff()
    {

    }
}

//概率触发类
class ProbabilisticBuff : BaseFeature
{
    public override FeatureType GetFeatureType()
    {
        return FeatureType.ProbabilisticTrigger;
    }

    public virtual void CalcBuff()
    {

    }
}

//固定属性数值
class AttributeImmobilizationBuff : BaseFeature
{
    public override FeatureType GetFeatureType()
    {
        return FeatureType.AttributeImmobilization;
    }

    public virtual void CalcBuff()
    {

    }
}


//———————————————————————— 以下为具体BUFF ——————————————————————————————————————

//直接增加最大生命值的数值类BUFF
class AddMaxHPValue : AddValueBuffFeature
{

    public float num = 0.3f;//这里读取这个Buff的数值

    public override void CalcBuff()
    {
        this.OwnRole.MaxHp = (int)(this.OwnRole.MaxHp * (1 + num));
    }
}

//获得 X% **强度 的 ** 强度
class ConvertAtoB : AttributeConversion
{
    public float num = 0.2f;//转换数值的百分比 , 这里用物理强度的20%转化为防御强度举例子

    public override void CalcBuff()
    {
        this.OwnRole.ArmorIntensity = (int)(1 + this.OwnRole.PhysicalIntensity * num);
    }
}

//直接增加数值类百分比BUFF
class AddArmorIntensityPercent : AddValuePercentBuffFeature
{
    public float num = 1f;//这里读取这个Buff的数值

    public override void CalcBuff()
    {
        this.OwnRole.ArmorIntensity = (int)(1 + this.OwnRole.ArmorIntensity * num);
    }
}

//攻击时概率触发的技能
class AttackProbabilistic : ProbabilisticBuff
{
    public float num = 0.15f;//触发概率的值, 这里用15%再攻击一次演示

    public override void CalcBuff()
    {
        
    }

}


//固定某项属性大小
class ImmobilizationSpeed : AttributeImmobilizationBuff
{
    public float num = 1f;//固定属性的值, 这里用 移速固定为 1 演示

    public override void CalcBuff()
    {
        this.OwnRole.Speed = (int)(num);
    }

}

