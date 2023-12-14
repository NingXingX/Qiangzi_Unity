using System;
using System.IO;
using System.Text;
using System.Collections.Generic;

public abstract class JsonNode
{
    public abstract string GetType();
    public object Value;
}

public class JsonListNode : JsonNode
{
    public override string GetType()
    {
        return "List";
    }
    public JsonListNode()
    {
        Value = new List<JsonNode>();
    }
}

public class JsonDictNode : JsonNode
{
    public override string GetType()
    {
        return "Dict";
    }
    public JsonDictNode()
    {
        Value = new Dictionary<string, JsonNode>();
    }
}

public class JsonStringNode : JsonNode
{
    public override string GetType()
    {
        return "String";
    }
}

public class JsonIntNode : JsonNode
{
    public override string GetType()
    {
        return "Int";
    }
}

public class JsonFloatNode : JsonNode
{
    public override string GetType()
    {
        return "Float";
    }
}

public class JsonLoadHelper
{
    static public string LoadJson(string jsonPath)
    {
        StreamReader sr = new StreamReader(jsonPath);
        StringBuilder jsonText = new StringBuilder();
        string line;
        while ((line = sr.ReadLine()) != null)
        {
            for (int i = 0; i < line.Length; ++i)
            {
                jsonText.Append(line[i]);
            }
        }
        return jsonText.ToString();
    }

    static public JsonListNode Parse(string dataText)
    {
        int index = 0;
        JsonListNode list = ParseList(dataText, ref index);
        return list;
    }

    static public JsonListNode ParseList(string dataText, ref int i)
    {
        ++i;
        JsonListNode ret = new JsonListNode();

        while (i < dataText.Length)
        {
            while (dataText[i] == ' ')
                ++i;
            if (dataText[i] == ']')
            {
                break;
            }
            else if (dataText[i] == '[')
            {
                var list = ParseList(dataText, ref i);
                ((List<JsonNode>)ret.Value).Add(list);
                ++i;
            }
            else if (dataText[i] == '{')
            {
                var dict = ParseDict(dataText, ref i);
                ((List<JsonNode>)ret.Value).Add(dict);
            }
            else if (dataText[i] == '"')
            {
                var str = ParseString(dataText, ref i);
                ((List<JsonNode>)ret.Value).Add(str);
            }
            else
            {
                var value = ParseValue(dataText, ref i);
                ((List<JsonNode>)ret.Value).Add(value);
            }
            while (dataText[i] != ',' && dataText[i] != ']')
                ++i;
            if (dataText[i] == ']')
                break;
            ++i;
        }

        return ret;
    }

    static public JsonDictNode ParseDict(string dataText, ref int i)
    {
        ++i;
        JsonDictNode ret = new JsonDictNode();

        while (i < dataText.Length)
        {
            while (dataText[i] != '"')
                ++i;
            string key = (string)ParseString(dataText, ref i).Value;

            while (dataText[i] != ':')
                ++i;
            ++i;
            while (dataText[i] == ' ')
                ++i;
            JsonNode value;
            if (dataText[i] == '[')
            {
                value = ParseList(dataText, ref i);
            }
            else if (dataText[i] == '{')
            {
                value = ParseDict(dataText, ref i);
                ++i;
            }
            else if (dataText[i] == '"')
            {
                value = ParseString(dataText, ref i);
            }
            else
            {
                value = ParseValue(dataText, ref i);
            }
            ((Dictionary<string, JsonNode>)ret.Value)[key] = value;
            while (dataText[i] != ',' && dataText[i] != '}')
                ++i;
            if (dataText[i] == '}')
                break;
            ++i;
        }

        return ret;
    }

    static public JsonStringNode ParseString(string dataText, ref int i)
    {
        ++i;
        int f = i;
        while (dataText[i] != '"')
        {
            if (dataText[i] == '\\')
                ++i;
            ++i;
        }
        string value = dataText.Substring(f, i - f);
        JsonStringNode ret = new JsonStringNode();
        ret.Value = value;
        return ret;
    }

    static public JsonNode ParseValue(string dataText, ref int i)
    {
        int value = 0;
        bool negtive = dataText[i] == '-';
        int point = 0;
        if (negtive)
            ++i;
        while (dataText[i] == '.' || (dataText[i] >= '0' && dataText[i] <= '9'))
        {
            if (dataText[i] == '.')
                point = 1;
            else
            {
                value *= 10;
                value += dataText[i] - '0';
                if (point >= 0)
                    point *= 10;
            }
            ++i;
        }
        if (point == 0)
        {
            JsonIntNode ret = new JsonIntNode();
            ret.Value = value;
            return ret;
        }
        else
        {
            JsonFloatNode ret = new JsonFloatNode();
            ret.Value = value * 1.0f / point;
            return ret;
        }
    }

    static public void GetValue(JsonNode node, ref int value)
    {
        value = GetInt(node);
    }
    static public void GetValue(JsonNode node, ref string value)
    {
        value = GetString(node);
    }
    static public void GetValue(JsonNode node, ref float value)
    {
        value = GetFloat(node);
    }
    static public void GetValue(JsonNode node, ref List<object> value)
    {
        value = GetList(node);
    }

    static public int GetInt(JsonNode node)
    {
        if (node.GetType() == "Int")
            return (int)node.Value;
        return (int)((float)node.Value);
    }

    static public float GetFloat(JsonNode node)
    {
        if (node.GetType() == "Float")
            return (float)node.Value;
        return (float)((int)node.Value);
    }

    static public string GetString(JsonNode node)
    {
        return (string)node.Value;
    }

    static public List<object> GetList(JsonNode node)
    {
        List<JsonNode> list = (List<JsonNode>)node.Value;
        List<object> ret = new List<object>();
        foreach (var listNodeValue in list)
        {
            if (listNodeValue.GetType() == "Int")
            {
                var intNode = listNodeValue as JsonIntNode;
                ret.Add(intNode.Value);
            }
            else if (listNodeValue.GetType() == "Float")
            {
                var floatNode = listNodeValue as JsonFloatNode;
                ret.Add(floatNode.Value);
            }
            else
            {
                var listNode = listNodeValue as JsonListNode;
                ret.Add(GetList(listNode));
            }
        }
        return ret;
    }
}
