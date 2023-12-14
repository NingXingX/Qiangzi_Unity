using System.Collections.Generic;

public class Features_buffData
{
	public int Id;
	public int Type;
	public List<object> Param;
	public string FeatureName;
	public string FeatureTips;
	public string FeatureTipsDetail;
}

public class Features_buffDataLoader
{
	static private Features_buffDataLoader instance;
	static public Features_buffDataLoader Instance
	{
		get
		{
			if (instance == null)
			{
				instance = new Features_buffDataLoader();
			}
			return instance;
		}
	}

	private bool dataIsLoad = false;
	public Dictionary<int, Features_buffData> dataDict = new Dictionary<int, Features_buffData>();
	public void LoadData()
	{
		string dataText = JsonLoadHelper.LoadJson("Assets/json/Features_buff.json");
		JsonListNode data = JsonLoadHelper.Parse(dataText);
		foreach(var jsonNode in (List<JsonNode>)data.Value)
		{
			JsonDictNode dictNode = jsonNode as JsonDictNode;
			Dictionary<string,JsonNode> dict = (Dictionary<string,JsonNode>)dictNode.Value;
			Features_buffData dataNode = new Features_buffData();
			JsonLoadHelper.GetValue(dict["Id"],ref dataNode.Id);
			JsonLoadHelper.GetValue(dict["Type"],ref dataNode.Type);
			JsonLoadHelper.GetValue(dict["Param"],ref dataNode.Param);
			JsonLoadHelper.GetValue(dict["FeatureName"],ref dataNode.FeatureName);
			JsonLoadHelper.GetValue(dict["FeatureTips"],ref dataNode.FeatureTips);
			JsonLoadHelper.GetValue(dict["FeatureTipsDetail"],ref dataNode.FeatureTipsDetail);
			dataDict[dataNode.Id]=dataNode;
		}
		dataIsLoad = true;
	}

	public Features_buffData GetData(int Id)
	{
		if(!dataIsLoad)
			LoadData();
		Features_buffData ret;
		if(dataDict.TryGetValue(Id, out ret))
		{
			 return ret;
		}
		return null;
	}
}
