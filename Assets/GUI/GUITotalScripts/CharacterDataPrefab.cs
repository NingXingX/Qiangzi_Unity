using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterDataPrefab : MonoBehaviour
{
    [Header("属性变量")]
    //属性名称组件
    public Text nameText;
    //属性数值组件
    public Text valueText;
    //属性数值进度条
    public Slider valueSlider;
    //属性名称（用于读取Content_text表）
    public string statsNameInText;

    void Start()
    {
        
    }

    
    void Update()
    {
        Read_CharacterData_Info(CharacterManager.nowChaID, CharacterManager.nowChaLevel, statsNameInText);
    }

    //读取角色属性信息
    public void Read_CharacterData_Info(int GroupID,int Lv,string statsname)
    {
        //改变属性名称
        Transform name = transform.Find("属性名称");
        if( name != null)
        {
            var statsText = Content_textDataLoader.Instance;
            Content_textData statsData_Text = statsText.GetData(statsname);
            nameText = name.GetComponent<Text>();
            nameText.text = statsData_Text.ChineseTranslate;
        }

        //改变属性数值
        Transform value = transform.Find("属性数值");
        if( value != null)
        {
            int needID1 = GroupID * 100 + Lv;
            var valuetext = Character_attributeDataLoader.Instance;
            Character_attributeData valueData_Text = valuetext.GetData(GroupID, needID1);
            valueText = value.GetComponent<Text>();
            //根据属性名称找到对应的属性，并显示对应数值
            switch(statsNameInText)
            {
                case "AttrName_001":
                    int result01 = valueData_Text.Level;
                    valueText.text = result01.ToString();
                    break;

                case "AttrName_002":
                    int result02 = valueData_Text.Hp;
                    valueText.text = result02.ToString();
                    break;

                case "AttrName_003":
                    int result03 = valueData_Text.HpRegeneration;
                    valueText.text = result03.ToString();
                    break;

                case "AttrName_004":
                    int result04 = valueData_Text.HpSteal;
                    valueText.text = result04.ToString();
                    break;

                case "AttrName_005":
                    int result05 = valueData_Text.Shields;
                    valueText.text = result05.ToString();
                    break;

                case "AttrName_006":
                    int result06 = valueData_Text.ShieldsRegeneration;
                    valueText.text = result06.ToString();
                    break;

                case "AttrName_007":
                    int result07 = valueData_Text.ActionNum;
                    valueText.text = "lv." + result07.ToString();
                    break;

                case "AttrName_008":
                    int result08 = valueData_Text.Speed;
                    valueText.text = result08.ToString();
                    break;

                case "AttrName_009":
                    int result09 = valueData_Text.PhysicalIntensity;
                    valueText.text = result09.ToString();
                    break;

                case "AttrName_010":
                    int result10 = valueData_Text.ManaIntensity;
                    valueText.text = result10.ToString();
                    break;

                case "AttrName_011":
                    int result11 = valueData_Text.ReligiousIntensity;
                    valueText.text = result11.ToString();
                    break;

                case "AttrName_012":
                    int result12 = valueData_Text.ArmorIntensity;
                    valueText.text = result12.ToString();
                    break;

                case "AttrName_013":
                    int result13 = valueData_Text.CritRate;
                    valueText.text = result13.ToString();
                    break;

                case "AttrName_014":
                    int result14 = valueData_Text.HitRate;
                    valueText.text = result14.ToString();
                    break;

                case "AttrName_015":
                    int result15 = valueData_Text.DodgeRate;
                    valueText.text = result15.ToString();
                    break;

            }
        }

        //改变滑动条的数值
        Transform slider = transform.Find("属性进度条");
        if (slider != null)
        {
            int needID2 = GroupID * 100 + Lv;
            var sliderValue = Character_attributeDataLoader.Instance;
            Character_attributeData data = sliderValue.GetData(GroupID, needID2);
            valueSlider = slider.GetComponent<Slider>();

            switch (statsNameInText)
            {
                case "AttrName_001":
                    float result01 = data.Level * 1.0f / 10;
                    valueSlider.value = result01;
                    break;

                case "AttrName_002":
                    float result02 = data.Hp * 1.0f / 300;
                    valueSlider.value = result02;
                    break;

                case "AttrName_003":
                    float result03 = data.HpRegeneration * 1.0f / 20;
                    valueSlider.value = result03;
                    break;

                case "AttrName_004":
                    float result04 = data.HpSteal * 1.0f / 10;
                    valueSlider.value = result04;
                    break;

                case "AttrName_005":
                    float result05 = data.Shields * 1.0f / 50;
                    valueSlider.value = result05;
                    break;

                case "AttrName_006":
                    float result06 = data.ShieldsRegeneration * 1.0f / 50;
                    valueSlider.value = result06;
                    break;

                case "AttrName_007":
                    float result07 = data.ActionNum * 1.0f / 5;
                    valueSlider.value = result07;
                    break;

                case "AttrName_008":
                    float result08 = data.Speed * 1.0f / 5;
                    valueSlider.value = result08;
                    break;

                case "AttrName_009":
                    float result09 = data.PhysicalIntensity * 1.0f / 100;
                    valueSlider.value = result09;
                    break;

                case "AttrName_010":
                    float result10 = data.ManaIntensity * 1.0f / 100;
                    valueSlider.value = result10;
                    break;

                case "AttrName_011":
                    float result11 = data.ReligiousIntensity * 1.0f / 100;
                    valueSlider.value = result11;
                    break;

                case "AttrName_012":
                    float result12 = data.ArmorIntensity * 1.0f / 100;
                    valueSlider.value = result12;
                    break;

                case "AttrName_013":
                    float result13 = data.CritRate * 1.0f / 300;
                    valueSlider.value = result13;
                    break;

                case "AttrName_014":
                    float result14 = data.HitRate * 1.0f / 100;
                    valueSlider.value = result14;
                    break;

                case "AttrName_015":
                    float result15 = data.DodgeRate * 1.0f / 100;
                    valueSlider.value = result15;
                    break;

            }
        }

    }

   
}
