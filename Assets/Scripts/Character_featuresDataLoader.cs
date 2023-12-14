using System.Collections.Generic;

public class Character_featuresData
{
	public int Id;
	public string Name;
	public int Icon;
	public string Des;
	public int Buff;
}

public class Character_featuresDataLoader
{
	static private Character_featuresDataLoader instance;
	static public Character_featuresDataLoader Instance
	{
		get
		{
			if (instance == null)
			{
				instance = new Character_featuresDataLoader();
			}
			return instance;
		}
	}

	private bool dataIsLoad = false;
	public Dictionary<int, Character_featuresData> dataDict = new Dictionary<int, Character_featuresData>();
	public void LoadData()
	{
		string dataText = JsonLoadHelper.LoadJson("Assets/json/Character_features.json");
		JsonListNode data = JsonLoadHelper.Parse(dataText);
		foreach(var jsonNode in (List<JsonNode>)data.Value)
		{
			JsonDictNode dictNode = jsonNode as JsonDictNode;
			Dictionary<string,JsonNode> dict = (Dictionary<string,JsonNode>)dictNode.Value;
			Character_featuresData dataNode = new Character_featuresData();
			JsonLoadHelper.GetValue(dict["Id"],ref dataNode.Id);
			JsonLoadHelper.GetValue(dict["Name"],ref dataNode.Name);
			JsonLoadHelper.GetValue(dict["Icon"],ref dataNode.Icon);
			JsonLoadHelper.GetValue(dict["Des"],ref dataNode.Des);
			JsonLoadHelper.GetValue(dict["Buff"],ref dataNode.Buff);
			dataDict[dataNode.Id]=dataNode;
		}
		dataIsLoad = true;
	}

	public Character_featuresData GetData(int Id)
	{
		if(!dataIsLoad)
			LoadData();
		Character_featuresData ret;
		if(dataDict.TryGetValue(Id, out ret))
		{
			 return ret;
		}
		return null;
	}
}
