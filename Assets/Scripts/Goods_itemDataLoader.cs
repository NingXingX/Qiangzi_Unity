using System.Collections.Generic;

public class Goods_itemData
{
	public int Id;
	public int price_buy_base;
	public int price_sell_base;
	public int goodsLevel;
	public int GoodsType;
	public int GoodsParam;
}

public class Goods_itemDataLoader
{
	static private Goods_itemDataLoader instance;
	static public Goods_itemDataLoader Instance
	{
		get
		{
			if (instance == null)
			{
				instance = new Goods_itemDataLoader();
			}
			return instance;
		}
	}

	private bool dataIsLoad = false;
	public Dictionary<int, Goods_itemData> dataDict = new Dictionary<int, Goods_itemData>();
	public void LoadData()
	{
		string dataText = JsonLoadHelper.LoadJson("Assets/json/Goods_item.json");
		JsonListNode data = JsonLoadHelper.Parse(dataText);
		foreach(var jsonNode in (List<JsonNode>)data.Value)
		{
			JsonDictNode dictNode = jsonNode as JsonDictNode;
			Dictionary<string,JsonNode> dict = (Dictionary<string,JsonNode>)dictNode.Value;
			Goods_itemData dataNode = new Goods_itemData();
			JsonLoadHelper.GetValue(dict["Id"],ref dataNode.Id);
			JsonLoadHelper.GetValue(dict["price_buy_base"],ref dataNode.price_buy_base);
			JsonLoadHelper.GetValue(dict["price_sell_base"],ref dataNode.price_sell_base);
			JsonLoadHelper.GetValue(dict["goodsLevel"],ref dataNode.goodsLevel);
			JsonLoadHelper.GetValue(dict["GoodsType"],ref dataNode.GoodsType);
			JsonLoadHelper.GetValue(dict["GoodsParam"],ref dataNode.GoodsParam);
			dataDict[dataNode.Id]=dataNode;
		}
		dataIsLoad = true;
	}

	public Goods_itemData GetData(int Id)
	{
		if(!dataIsLoad)
			LoadData();
		Goods_itemData ret;
		if(dataDict.TryGetValue(Id, out ret))
		{
			 return ret;
		}
		return null;
	}
}
