using System.Collections.Generic;

public class Character_attributeData
{
	public int GroupID;
	public int Id;
	public int Level;
	public int Hp;
	public int HpRegeneration;
	public int HpSteal;
	public int Shields;
	public int ShieldsRegeneration;
	public int ActionNum;
	public int Speed;
	public int PhysicalIntensity;
	public int ManaIntensity;
	public int ReligiousIntensity;
	public int ArmorIntensity;
	public int CritRate;
	public int HitRate;
	public int DodgeRate;
}

public class Character_attributeDataLoader
{
	static private Character_attributeDataLoader instance;
	static public Character_attributeDataLoader Instance
	{
		get
		{
			if (instance == null)
			{
				instance = new Character_attributeDataLoader();
			}
			return instance;
		}
	}

	private bool dataIsLoad = false;
	public Dictionary<(int,int), Character_attributeData> dataDict = new Dictionary<(int,int), Character_attributeData>();
	public void LoadData()
	{
		string dataText = JsonLoadHelper.LoadJson("Assets/json/Character_attribute.json");
		JsonListNode data = JsonLoadHelper.Parse(dataText);
		foreach(var jsonNode in (List<JsonNode>)data.Value)
		{
			JsonDictNode dictNode = jsonNode as JsonDictNode;
			Dictionary<string,JsonNode> dict = (Dictionary<string,JsonNode>)dictNode.Value;
			Character_attributeData dataNode = new Character_attributeData();
			JsonLoadHelper.GetValue(dict["GroupID"],ref dataNode.GroupID);
			JsonLoadHelper.GetValue(dict["Id"],ref dataNode.Id);
			JsonLoadHelper.GetValue(dict["Level"],ref dataNode.Level);
			JsonLoadHelper.GetValue(dict["Hp"],ref dataNode.Hp);
			JsonLoadHelper.GetValue(dict["HpRegeneration"],ref dataNode.HpRegeneration);
			JsonLoadHelper.GetValue(dict["HpSteal"],ref dataNode.HpSteal);
			JsonLoadHelper.GetValue(dict["Shields"],ref dataNode.Shields);
			JsonLoadHelper.GetValue(dict["ShieldsRegeneration"],ref dataNode.ShieldsRegeneration);
			JsonLoadHelper.GetValue(dict["ActionNum"],ref dataNode.ActionNum);
			JsonLoadHelper.GetValue(dict["Speed"],ref dataNode.Speed);
			JsonLoadHelper.GetValue(dict["PhysicalIntensity"],ref dataNode.PhysicalIntensity);
			JsonLoadHelper.GetValue(dict["ManaIntensity"],ref dataNode.ManaIntensity);
			JsonLoadHelper.GetValue(dict["ReligiousIntensity"],ref dataNode.ReligiousIntensity);
			JsonLoadHelper.GetValue(dict["ArmorIntensity"],ref dataNode.ArmorIntensity);
			JsonLoadHelper.GetValue(dict["CritRate"],ref dataNode.CritRate);
			JsonLoadHelper.GetValue(dict["HitRate"],ref dataNode.HitRate);
			JsonLoadHelper.GetValue(dict["DodgeRate"],ref dataNode.DodgeRate);
			dataDict[(dataNode.GroupID,dataNode.Id)]=dataNode;
		}
		dataIsLoad = true;
	}

	public Character_attributeData GetData(int GroupID, int Id)
	{
		if(!dataIsLoad)
			LoadData();
		Character_attributeData ret;
		if(dataDict.TryGetValue((GroupID, Id), out ret))
		{
			 return ret;
		}
		return null;
	}
}
