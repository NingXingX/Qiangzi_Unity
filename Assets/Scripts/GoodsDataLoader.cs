using System.Collections.Generic;

public class GoodsData
{
	public int Id;
	public int price_buy_final;
	public int price_sell_final;
	public int GoodsType;
	public int GoodsNum;
	public List<object> GoodsDrop;
}

public class GoodsDataLoader
{
	static private GoodsDataLoader instance;
	static public GoodsDataLoader Instance
	{
		get
		{
			if (instance == null)
			{
				instance = new GoodsDataLoader();
			}
			return instance;
		}
	}

	private bool dataIsLoad = false;
	public Dictionary<int, GoodsData> dataDict = new Dictionary<int, GoodsData>();
	public void LoadData()
	{
		string dataText = JsonLoadHelper.LoadJson("Assets/json/Goods.json");
		JsonListNode data = JsonLoadHelper.Parse(dataText);
		foreach(var jsonNode in (List<JsonNode>)data.Value)
		{
			JsonDictNode dictNode = jsonNode as JsonDictNode;
			Dictionary<string,JsonNode> dict = (Dictionary<string,JsonNode>)dictNode.Value;
			GoodsData dataNode = new GoodsData();
			JsonLoadHelper.GetValue(dict["Id"],ref dataNode.Id);
			JsonLoadHelper.GetValue(dict["price_buy_final"],ref dataNode.price_buy_final);
			JsonLoadHelper.GetValue(dict["price_sell_final"],ref dataNode.price_sell_final);
			JsonLoadHelper.GetValue(dict["GoodsType"],ref dataNode.GoodsType);
			JsonLoadHelper.GetValue(dict["GoodsNum"],ref dataNode.GoodsNum);
			JsonLoadHelper.GetValue(dict["GoodsDrop"],ref dataNode.GoodsDrop);
			dataDict[dataNode.Id]=dataNode;
		}
		dataIsLoad = true;
	}

	public GoodsData GetData(int Id)
	{
		if(!dataIsLoad)
			LoadData();
		GoodsData ret;
		if(dataDict.TryGetValue(Id, out ret))
		{
			 return ret;
		}
		return null;
	}
}
