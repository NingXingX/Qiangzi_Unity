
public enum FeatureType
{
    BUFF,
    ATTACK,
}


public abstract class BaseFeature
{
    public Role OwnRole;

    abstract public FeatureType GetFeatureType();
}


//修改数值类
class BuffFeature : BaseFeature
{
    public override FeatureType GetFeatureType()
    {
        return FeatureType.BUFF;
    }

    public virtual void CalcBuff()
    {
        
    }
}


class HPBuff : BuffFeature
{

    public float num = 0.3f;

    public override void CalcBuff()
    {
        this.OwnRole.MaxHp = (int)(this.OwnRole.MaxHp * (1 + num));
    }
}
