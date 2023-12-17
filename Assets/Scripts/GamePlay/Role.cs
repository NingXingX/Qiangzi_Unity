using System.Collections.Generic;

public class Role
{
    private CharacterData character;
    private Character_attributeData attribute;

    public int Id = 0;
    public int Level = 0;
    public int Hp = 0;
    public int Shields = 0;
    public int ActionNum = 0;
    public List<RoleEquip> EquipList;

    public RoleComp OwnComp;


    public void Init(int characterID, RoleComp ownComp, int level = 1)
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

        this.Id = characterID;
        this.Level = level;
        this.Hp = this.attribute.Hp;
        this.Shields = this.attribute.Shields;
        this.ActionNum = this.attribute.ActionNum;
        this.EquipList = new List<RoleEquip>();

        this.OwnComp = ownComp;
    }

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
}