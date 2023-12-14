using System.Collections.Generic;

public class EquipData
{
	public int Id;
	public int EuipType;
	public int Grade;
	public string EquipName;
	public int price_buy;
	public int price_sell;
	public int Attack;
	public float AttackBonus01;
	public float AttackBonus02;
	public float AttackBonus03;
	public float AttackBonus04;
	public float AttackSpeed;
	public float AttackSpeedBonus;
	public int AttackRange;
	public float HitRate;
	public float CritRate;
	public float HpSteal;
	public List<object> WeaponBuff;
	public List<object> WeaponFeatures;
	public int Armor;
	public int ArmorRegeneration;
	public List<object> ArmorBuff;
	public List<object> ArmorFeatures;
	public List<object> JewelBuff;
	public List<object> JewelFeatures;
}

public class EquipDataLoader
{
	static private EquipDataLoader instance;
	static public EquipDataLoader Instance
	{
		get
		{
			if (instance == null)
			{
				instance = new EquipDataLoader();
			}
			return instance;
		}
	}

	private bool dataIsLoad = false;
	public Dictionary<int, EquipData> dataDict = new Dictionary<int, EquipData>();
	public void LoadData()
	{
		string dataText = JsonLoadHelper.LoadJson("Assets/json/Equip.json");
		JsonListNode data = JsonLoadHelper.Parse(dataText);
		foreach(var jsonNode in (List<JsonNode>)data.Value)
		{
			JsonDictNode dictNode = jsonNode as JsonDictNode;
			Dictionary<string,JsonNode> dict = (Dictionary<string,JsonNode>)dictNode.Value;
			EquipData dataNode = new EquipData();
			JsonLoadHelper.GetValue(dict["Id"],ref dataNode.Id);
			JsonLoadHelper.GetValue(dict["EuipType"],ref dataNode.EuipType);
			JsonLoadHelper.GetValue(dict["Grade"],ref dataNode.Grade);
			JsonLoadHelper.GetValue(dict["EquipName"],ref dataNode.EquipName);
			JsonLoadHelper.GetValue(dict["price_buy"],ref dataNode.price_buy);
			JsonLoadHelper.GetValue(dict["price_sell"],ref dataNode.price_sell);
			JsonLoadHelper.GetValue(dict["Attack"],ref dataNode.Attack);
			JsonLoadHelper.GetValue(dict["AttackBonus01"],ref dataNode.AttackBonus01);
			JsonLoadHelper.GetValue(dict["AttackBonus02"],ref dataNode.AttackBonus02);
			JsonLoadHelper.GetValue(dict["AttackBonus03"],ref dataNode.AttackBonus03);
			JsonLoadHelper.GetValue(dict["AttackBonus04"],ref dataNode.AttackBonus04);
			JsonLoadHelper.GetValue(dict["AttackSpeed"],ref dataNode.AttackSpeed);
			JsonLoadHelper.GetValue(dict["AttackSpeedBonus"],ref dataNode.AttackSpeedBonus);
			JsonLoadHelper.GetValue(dict["AttackRange"],ref dataNode.AttackRange);
			JsonLoadHelper.GetValue(dict["HitRate"],ref dataNode.HitRate);
			JsonLoadHelper.GetValue(dict["CritRate"],ref dataNode.CritRate);
			JsonLoadHelper.GetValue(dict["HpSteal"],ref dataNode.HpSteal);
			JsonLoadHelper.GetValue(dict["WeaponBuff"],ref dataNode.WeaponBuff);
			JsonLoadHelper.GetValue(dict["WeaponFeatures"],ref dataNode.WeaponFeatures);
			JsonLoadHelper.GetValue(dict["Armor"],ref dataNode.Armor);
			JsonLoadHelper.GetValue(dict["ArmorRegeneration"],ref dataNode.ArmorRegeneration);
			JsonLoadHelper.GetValue(dict["ArmorBuff"],ref dataNode.ArmorBuff);
			JsonLoadHelper.GetValue(dict["ArmorFeatures"],ref dataNode.ArmorFeatures);
			JsonLoadHelper.GetValue(dict["JewelBuff"],ref dataNode.JewelBuff);
			JsonLoadHelper.GetValue(dict["JewelFeatures"],ref dataNode.JewelFeatures);
			dataDict[dataNode.Id]=dataNode;
		}
		dataIsLoad = true;
	}

	public EquipData GetData(int Id)
	{
		if(!dataIsLoad)
			LoadData();
		EquipData ret;
		if(dataDict.TryGetValue(Id, out ret))
		{
			 return ret;
		}
		return null;
	}
}
