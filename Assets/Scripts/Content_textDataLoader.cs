using System.Collections.Generic;

public class Content_textData
{
	public string TextName;
	public int ContentType;
	public string ChineseTranslate;
	public string EnglishTranslate;
}

public class Content_textDataLoader
{
	static private Content_textDataLoader instance;
	static public Content_textDataLoader Instance
	{
		get
		{
			if (instance == null)
			{
				instance = new Content_textDataLoader();
			}
			return instance;
		}
	}

	private bool dataIsLoad = false;
	public Dictionary<string, Content_textData> dataDict = new Dictionary<string, Content_textData>();
	public void LoadData()
	{
		string dataText = JsonLoadHelper.LoadJson("Assets/json/Content_text.json");
		JsonListNode data = JsonLoadHelper.Parse(dataText);
		foreach(var jsonNode in (List<JsonNode>)data.Value)
		{
			JsonDictNode dictNode = jsonNode as JsonDictNode;
			Dictionary<string,JsonNode> dict = (Dictionary<string,JsonNode>)dictNode.Value;
			Content_textData dataNode = new Content_textData();
			JsonLoadHelper.GetValue(dict["TextName"],ref dataNode.TextName);
			JsonLoadHelper.GetValue(dict["ContentType"],ref dataNode.ContentType);
			JsonLoadHelper.GetValue(dict["ChineseTranslate"],ref dataNode.ChineseTranslate);
			JsonLoadHelper.GetValue(dict["EnglishTranslate"],ref dataNode.EnglishTranslate);
			dataDict[dataNode.TextName]=dataNode;
		}
		dataIsLoad = true;
	}

	public Content_textData GetData(string TextName)
	{
		if(!dataIsLoad)
			LoadData();
		Content_textData ret;
		if(dataDict.TryGetValue(TextName, out ret))
		{
			 return ret;
		}
		return null;
	}
}
