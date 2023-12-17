
public class RoleEquip
{
    private EquipData equip;

    public RoleComp OwnComp;

    public int Id;

    public void Init(int equipId, RoleComp ownComp)
    {
        this.equip = EquipDataLoader.Instance.GetData(equipId);
        if (this.equip == null)
        {
            return;
        }
        this.Id = equipId;

        this.OwnComp = ownComp;
    }
}