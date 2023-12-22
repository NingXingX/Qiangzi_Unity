using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//��ɫ������Ԥ����Ľű�
public class CharacterDataPrefab : MonoBehaviour
{
    [Header("���Ա���")]
    //�����������
    public Text nameText;
    //������ֵ���
    public Text valueText;
    //������ֵ������
    public Slider valueSlider;
    //�������ƣ����ڶ�ȡContent_text��
    public string statsNameInText;

    private Role nowRole;

    void Start()
    {
        
    }

    
    void Update()
    {
        Read_CharacterData_Info(this.nowRole,statsNameInText);
    }

    //��ȡ��ɫ������Ϣ
    public void Read_CharacterData_Info(Role role,string statsname)
    {
        this.nowRole = role;
        if (this.nowRole == null)
        {
            return;
        }


        //�ı���������
        Transform name = transform.Find("��������");
        if( name != null)
        {
            var statsText = Content_textDataLoader.Instance;
            Content_textData statsData_Text = statsText.GetData(statsname);
            nameText = name.GetComponent<Text>();
            nameText.text = statsData_Text.ChineseTranslate;
        }

        //�ı�������ֵ
        Transform value = transform.Find("������ֵ");
        if( value != null)
        {
            int needID1 = role.GroupID * 100 + role.Level;
            var valuetext = Character_attributeDataLoader.Instance;
            //Character_attributeData valueData_Text = valuetext.GetData(role.GroupID, needID1);
            valueText = value.GetComponent<Text>();
            //�������������ҵ���Ӧ�����ԣ�����ʾ��Ӧ��ֵ
            switch(statsNameInText)
            {
                case "AttrName_001":
                    int result01 = role.Level;
                    valueText.text = result01.ToString();
                    break;

                case "AttrName_002":
                    int result02 = role.Hp;
                    valueText.text = result02.ToString();
                    break;

                case "AttrName_003":
                    int result03 = role.HpRegeneration;
                    valueText.text = result03.ToString();
                    break;

                case "AttrName_004":
                    int result04 = role.HpSteal;
                    valueText.text = result04.ToString();
                    break;

                case "AttrName_005":
                    int result05 = role.Shields;
                    valueText.text = result05.ToString();
                    break;

                case "AttrName_006":
                    int result06 = role.ShieldsRegeneration;
                    valueText.text = result06.ToString();
                    break;

                case "AttrName_007":
                    int result07 = role.ActionNum;
                    valueText.text = "lv." + result07.ToString();
                    break;

                case "AttrName_008":
                    int result08 = role.Speed;
                    valueText.text = result08.ToString();
                    break;

                case "AttrName_009":
                    int result09 = role.PhysicalIntensity;
                    valueText.text = result09.ToString();
                    break;

                case "AttrName_010":
                    int result10 = role.ManaIntensity;
                    valueText.text = result10.ToString();
                    break;

                case "AttrName_011":
                    int result11 = role.ReligiousIntensity;
                    valueText.text = result11.ToString();
                    break;

                case "AttrName_012":
                    int result12 = role.ArmorIntensity;
                    valueText.text = result12.ToString();
                    break;

                case "AttrName_013":
                    int result13 = role.CritRate;
                    valueText.text = result13.ToString();
                    break;

                case "AttrName_014":
                    int result14 = role.HitRate;
                    valueText.text = result14.ToString();
                    break;

                case "AttrName_015":
                    int result15 = role.DodgeRate;
                    valueText.text = result15.ToString();
                    break;

            }
        }

        //�ı们��������ֵ
        Transform slider = transform.Find("���Խ�����");
        if (slider != null)
        {
            int needID2 = role.GroupID * 100 + role.Level;
            var sliderValue = Character_attributeDataLoader.Instance;
            //Character_attributeData data = sliderValue.GetData(role.GroupID, needID2);
            valueSlider = slider.GetComponent<Slider>();

            switch (statsNameInText)
            {
                case "AttrName_001":
                    float result01 = role.Level * 1.0f / 10;
                    valueSlider.value = result01;
                    break;

                case "AttrName_002":
                    float result02 = role.Hp * 1.0f / 300;
                    valueSlider.value = result02;
                    break;

                case "AttrName_003":
                    float result03 = role.HpRegeneration * 1.0f / 20;
                    valueSlider.value = result03;
                    break;

                case "AttrName_004":
                    float result04 = role.HpSteal * 1.0f / 10;
                    valueSlider.value = result04;
                    break;

                case "AttrName_005":
                    float result05 = role.Shields * 1.0f / 50;
                    valueSlider.value = result05;
                    break;

                case "AttrName_006":
                    float result06 = role.ShieldsRegeneration * 1.0f / 50;
                    valueSlider.value = result06;
                    break;

                case "AttrName_007":
                    float result07 = role.ActionNum * 1.0f / 5;
                    valueSlider.value = result07;
                    break;

                case "AttrName_008":
                    float result08 = role.Speed * 1.0f / 5;
                    valueSlider.value = result08;
                    break;

                case "AttrName_009":
                    float result09 = role.PhysicalIntensity * 1.0f / 100;
                    valueSlider.value = result09;
                    break;

                case "AttrName_010":
                    float result10 = role.ManaIntensity * 1.0f / 100;
                    valueSlider.value = result10;
                    break;

                case "AttrName_011":
                    float result11 = role.ReligiousIntensity * 1.0f / 100;
                    valueSlider.value = result11;
                    break;

                case "AttrName_012":
                    float result12 = role.ArmorIntensity * 1.0f / 100;
                    valueSlider.value = result12;
                    break;

                case "AttrName_013":
                    float result13 = role.CritRate * 1.0f / 300;
                    valueSlider.value = result13;
                    break;

                case "AttrName_014":
                    float result14 = role.HitRate * 1.0f / 100;
                    valueSlider.value = result14;
                    break;

                case "AttrName_015":
                    float result15 = role.DodgeRate * 1.0f / 100;
                    valueSlider.value = result15;
                    break;

            }
        }

    }

   
}
