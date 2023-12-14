using System.Collections.Generic;

public class CurrencyData
{
	public int Id;
	public string CurrencyName;
	public string CurrencyDes;
}

public class CurrencyDataLoader
{
	static private CurrencyDataLoader instance;
	static public CurrencyDataLoader Instance
	{
		get
		{
			if (instance == null)
			{
				instance = new CurrencyDataLoader();
			}
			return instance;
		}
	}

	private bool dataIsLoad = false;
	public Dictionary<int, CurrencyData> dataDict = new Dictionary<int, CurrencyData>();
	public void LoadData()
	{
		string dataText = JsonLoadHelper.LoadJson("Assets/json/Currency.json");
		JsonListNode data = JsonLoadHelper.Parse(dataText);
		foreach(var jsonNode in (List<JsonNode>)data.Value)
		{
			JsonDictNode dictNode = jsonNode as JsonDictNode;
			Dictionary<string,JsonNode> dict = (Dictionary<string,JsonNode>)dictNode.Value;
			CurrencyData dataNode = new CurrencyData();
			JsonLoadHelper.GetValue(dict["Id"],ref dataNode.Id);
			JsonLoadHelper.GetValue(dict["CurrencyName"],ref dataNode.CurrencyName);
			JsonLoadHelper.GetValue(dict["CurrencyDes"],ref dataNode.CurrencyDes);
			dataDict[dataNode.Id]=dataNode;
		}
		dataIsLoad = true;
	}

	public CurrencyData GetData(int Id)
	{
		if(!dataIsLoad)
			LoadData();
		CurrencyData ret;
		if(dataDict.TryGetValue(Id, out ret))
		{
			 return ret;
		}
		return null;
	}
}
