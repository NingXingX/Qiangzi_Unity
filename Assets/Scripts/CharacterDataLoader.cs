using System.Collections.Generic;

public class CharacterData
{
	public int Id;
	public string CharTitle;
	public string CharName;
	public string CharDes;
	public int CharType;
	public int CharSize;
	public int CharAvatar;
	public int CharAttr;
	public int CharFeatures;
	public int CharAI;
	public int EquipWeaponNum;
	public int EquipArmorNum;
	public int EquipJewelNum;
}

public class CharacterDataLoader
{
	static private CharacterDataLoader instance;
	static public CharacterDataLoader Instance
	{
		get
		{
			if (instance == null)
			{
				instance = new CharacterDataLoader();
			}
			return instance;
		}
	}

	private bool dataIsLoad = false;
	public Dictionary<int, CharacterData> dataDict = new Dictionary<int, CharacterData>();
	public void LoadData()
	{
		string dataText = JsonLoadHelper.LoadJson("Assets/json/Character.json");
		JsonListNode data = JsonLoadHelper.Parse(dataText);
		foreach(var jsonNode in (List<JsonNode>)data.Value)
		{
			JsonDictNode dictNode = jsonNode as JsonDictNode;
			Dictionary<string,JsonNode> dict = (Dictionary<string,JsonNode>)dictNode.Value;
			CharacterData dataNode = new CharacterData();
			JsonLoadHelper.GetValue(dict["Id"],ref dataNode.Id);
			JsonLoadHelper.GetValue(dict["CharTitle"],ref dataNode.CharTitle);
			JsonLoadHelper.GetValue(dict["CharName"],ref dataNode.CharName);
			JsonLoadHelper.GetValue(dict["CharDes"],ref dataNode.CharDes);
			JsonLoadHelper.GetValue(dict["CharType"],ref dataNode.CharType);
			JsonLoadHelper.GetValue(dict["CharSize"],ref dataNode.CharSize);
			JsonLoadHelper.GetValue(dict["CharAvatar"],ref dataNode.CharAvatar);
			JsonLoadHelper.GetValue(dict["CharAttr"],ref dataNode.CharAttr);
			JsonLoadHelper.GetValue(dict["CharFeatures"],ref dataNode.CharFeatures);
			JsonLoadHelper.GetValue(dict["CharAI"],ref dataNode.CharAI);
			JsonLoadHelper.GetValue(dict["EquipWeaponNum"],ref dataNode.EquipWeaponNum);
			JsonLoadHelper.GetValue(dict["EquipArmorNum"],ref dataNode.EquipArmorNum);
			JsonLoadHelper.GetValue(dict["EquipJewelNum"],ref dataNode.EquipJewelNum);
			dataDict[dataNode.Id]=dataNode;
		}
		dataIsLoad = true;
	}

	public CharacterData GetData(int Id)
	{
		if(!dataIsLoad)
			LoadData();
		CharacterData ret;
		if(dataDict.TryGetValue(Id, out ret))
		{
			 return ret;
		}
		return null;
	}
}
