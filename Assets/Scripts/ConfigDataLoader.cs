using System.Collections.Generic;

public class ConfigData
{
	public int Id;
	public string ParamName;
	public string ParamValue;
}

public class ConfigDataLoader
{
	static private ConfigDataLoader instance;
	static public ConfigDataLoader Instance
	{
		get
		{
			if (instance == null)
			{
				instance = new ConfigDataLoader();
			}
			return instance;
		}
	}

	private bool dataIsLoad = false;
	public Dictionary<string, ConfigData> dataDict = new Dictionary<string, ConfigData>();
	public void LoadData()
	{
		string dataText = JsonLoadHelper.LoadJson("Assets/json/Config.json");
		JsonListNode data = JsonLoadHelper.Parse(dataText);
		foreach(var jsonNode in (List<JsonNode>)data.Value)
		{
			JsonDictNode dictNode = jsonNode as JsonDictNode;
			Dictionary<string,JsonNode> dict = (Dictionary<string,JsonNode>)dictNode.Value;
			ConfigData dataNode = new ConfigData();
			JsonLoadHelper.GetValue(dict["Id"],ref dataNode.Id);
			JsonLoadHelper.GetValue(dict["ParamName"],ref dataNode.ParamName);
			JsonLoadHelper.GetValue(dict["ParamValue"],ref dataNode.ParamValue);
			dataDict[dataNode.ParamName]=dataNode;
		}
		dataIsLoad = true;
	}

	public ConfigData GetData(string ParamName)
	{
		if(!dataIsLoad)
			LoadData();
		ConfigData ret;
		if(dataDict.TryGetValue(ParamName, out ret))
		{
			 return ret;
		}
		return null;
	}
}
