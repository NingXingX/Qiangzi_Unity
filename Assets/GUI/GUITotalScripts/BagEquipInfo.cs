using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//角色背包内装备信息面板的脚本
public class BagEquipInfo : MonoBehaviour
{
    [Header("信息面板通用组件")]
    public Text equipNameText;
    public Text equipTypeText;
    public Text glossaryText1;
    public Text glossaryText2;
    public Text glossaryText3;

    [Header("武器类装备组件")]
    public Text damageText;
    public Text frequencyText;
    public Text distanceText;
    public Text hitText;
    public Text critText;
    public Text leechText;

    [Header("装备栏引用组件")]
    public GameObject equipBar;
    public GameObject equipBarItemPrefab;

    private void Start()
    {
        ChangeCanvasGroup();
    }

    private void Update()
    {
        DisplayEquipInfomation(UIManager.nowEquipID);
    }

    public void DisplayEquipInfomation(int equipid)
    {
        //得到装备表的数据
        var equip = EquipDataLoader.Instance;
        EquipData equipData = equip.GetData(equipid);

        //更新装备名称
        Transform name = transform.Find("装备名称文本");
        if ( name != null )
        {
            equipNameText = name.GetComponent<Text>();
            string result = "EquipName_" + equipid.ToString();

            //得到Content_text文本内容表数据
            var content = Content_textDataLoader.Instance;
            Content_textData contentData = content.GetData(result);
            equipNameText.text = contentData.ChineseTranslate;

        }

        //更新装备类型
        Transform type = transform.Find("装备类型文本");
        if (type != null)
        {
            equipTypeText = type.GetComponent<Text>();
            equipTypeText.text = "武器";
        }

        //更新武器伤害
        Transform damage = transform.Find("伤害文本");
        if ( damage != null)
        {
            damageText = damage.GetComponent<Text>();
            damageText.text = equipData.Attack.ToString();
        }

        //更新武器频率
        Transform frequency = transform.Find("频率文本");
        if (frequency != null)
        {
            frequencyText = frequency.GetComponent<Text>();
            frequencyText.text = equipData.AttackSpeed.ToString();
        }

        //更新武器距离
        Transform distance = transform.Find("距离文本");
        if (distance != null)
        {
            distanceText = distance.GetComponent<Text>();
            distanceText.text = equipData.AttackRange.ToString();
        }

        //更新武器命中
        Transform hit = transform.Find("命中文本");
        if ( hit != null)
        {
            hitText = hit.GetComponent<Text>();
            hitText.text = equipData.HitRate.ToString();
        }

        //更新武器暴击
        Transform crit = transform.Find("暴击文本");
        if (crit != null)
        {
            critText = crit.GetComponent<Text>();
            critText.text = equipData.CritRate.ToString();
        }

        //更新武器吸血
        Transform leech = transform.Find("吸血文本");
        if (leech != null)
        {
            leechText = leech.GetComponent<Text>();
            leechText.text = equipData.HpSteal.ToString();
        }

    }

    //装备按钮函数
    public void WearEquipmentButton()
    {
        UIManager.EquipIDArray[UIManager.nowCharacterNumberInUI, UIManager.nowCharacterEquipNumber[UIManager.nowCharacterNumberInUI]] = UIManager.nowEquipID;
        UIManager.nowCharacterEquipNumber[UIManager.nowCharacterNumberInUI]++;
        print("UI管理器中的当前角色装备数量为：" + UIManager.nowCharacterEquipNumber[UIManager.nowCharacterNumberInUI]);
        print("UI管理器的装备数组为:" + UIManager.EquipIDArray);
    }

    //开始时改变CanvasGroup
    public void ChangeCanvasGroup()
    {
        // 获取CanvasGroup组件
        CanvasGroup canvasGroup = GetComponent<CanvasGroup>();

        // 设置透明度为0
        canvasGroup.alpha = 0f;

        // 禁用交互性
        canvasGroup.interactable = false;
        canvasGroup.blocksRaycasts = false;

        UIManager.isBagEquipInfoPanelActive = false;
    }
}
