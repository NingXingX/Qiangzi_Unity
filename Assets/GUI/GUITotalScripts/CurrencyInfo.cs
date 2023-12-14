using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CurrencyInfo : MonoBehaviour
{
    //货币名称
    public string CurrencyName;
    //货币描述
    public string CurrencyDes;
    //货币描述文本组件
    public Text desText;
    //货币名称文本组件
    public Text nameText;

    private void Start()
    {
        Read_Currency_Info();
    }


    public void Read_Currency_Info()
    {
        //读取名称和描述信息
      
        Transform name = transform.Find("货币名称");
        if(name != null)
        {
            var nameData = Content_textDataLoader.Instance;
            Content_textData nameDataText = nameData.GetData(CurrencyName);
            nameText = name.GetComponent<Text>();
            nameText.text = nameDataText.ChineseTranslate;
        }

        Transform des = transform.Find("货币提示文本");
        if(des != null)
        {
            var desData = Content_textDataLoader.Instance;
            Content_textData desDataText = desData.GetData(CurrencyDes);
            desText = des.GetComponent<Text>();
            desText.text = desDataText.ChineseTranslate;
        }
    }

}
