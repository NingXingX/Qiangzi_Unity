using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CurrencyInfo : MonoBehaviour
{
    //��������
    public string CurrencyName;
    //��������
    public string CurrencyDes;
    //���������ı����
    public Text desText;
    //���������ı����
    public Text nameText;

    private void Start()
    {
        Read_Currency_Info();
    }


    public void Read_Currency_Info()
    {
        //��ȡ���ƺ�������Ϣ
      
        Transform name = transform.Find("��������");
        if(name != null)
        {
            var nameData = Content_textDataLoader.Instance;
            Content_textData nameDataText = nameData.GetData(CurrencyName);
            nameText = name.GetComponent<Text>();
            nameText.text = nameDataText.ChineseTranslate;
        }

        Transform des = transform.Find("������ʾ�ı�");
        if(des != null)
        {
            var desData = Content_textDataLoader.Instance;
            Content_textData desDataText = desData.GetData(CurrencyDes);
            desText = des.GetComponent<Text>();
            desText.text = desDataText.ChineseTranslate;
        }
    }

}
