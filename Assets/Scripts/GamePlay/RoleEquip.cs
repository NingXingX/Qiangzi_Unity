
public class RoleEquip
{
    private EquipData equip;

    public RoleComp OwnComp;

    public int Id;
    public int Type;
    public int BaseAttack;
    public float AttackSpeed;
    public int AttackRange;

    //初始化装备到角色上
    public void Init(int equipId, RoleComp ownComp)
    {
        this.equip = EquipDataLoader.Instance.GetData(equipId);
        if (this.equip == null)
        {
            return;
        }
        this.Id = equipId;

        this.OwnComp = ownComp;
        this.BaseAttack = this.equip.Attack;
        this.AttackSpeed = this.equip.AttackSpeed;
        this.AttackRange = this.equip.AttackRange;
        this.Type = this.equip.EuipType;
    }
}