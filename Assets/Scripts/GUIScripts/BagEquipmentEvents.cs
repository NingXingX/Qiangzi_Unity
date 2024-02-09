using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//处于背包内装备的预制体脚本
public class BagEquipmentEvents : MonoBehaviour
{
    [Header("装备变量")]
    //这个装备的ID
    public int thisEquipID;
    //这个装备的类型
    public int thisEquipType = 1;
    //装备品质（等级）
    public int thisEquipGrade;

    [Header("引用组件")]
    public Text levelText;
    public GameObject equipInfoPanel;



    void Start()
    {
        GenerateRandomEquipID();
        DisplayEquipInfo(thisEquipID);
    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale = new Vector3(1f, 1f, 1f);
        equipInfoPanel = GameObject.Find("背包装备信息面板");
    }

    public void GenerateRandomEquipID()
    {
        thisEquipID = Random.Range(10011,10017);
        thisEquipGrade = Random.Range(1,6);
    }

    //更新信息到面板
    public void DisplayEquipInfo(int equipmentID)
    {

        Transform level = transform.Find("背包装备等级文本");
        if ( level != null )
        {
            var equipValue = EquipDataLoader.Instance;
            EquipData equip = equipValue.GetData(equipmentID);
            levelText = level.GetComponent<Text>();
            levelText.text = equip.Grade.ToString();
        }
    }

    public void SendEquipIDToUIManager()
    {
        UIManager.nowEquipID = thisEquipID;
        print("UI管理器中当前的武器ID为：" + UIManager.nowEquipID);
    }

    public void EquipController()
    {
        //当装备面板不可见时，要让他可见
        if ( UIManager.isBagEquipInfoPanelActive == false )
        {
            //得到背包装备信息面板上的CanvasGroup组件
            GameObject equipInfoPanel = GameObject.Find("背包装备信息面板");
            CanvasGroup canvasGroup = equipInfoPanel.GetComponent<CanvasGroup>();

            // 设置透明度为0
            canvasGroup.alpha = 1f;

            // 禁用交互性
            canvasGroup.interactable = true;
            canvasGroup.blocksRaycasts = true;

            //改变变量
            UIManager.isBagEquipInfoPanelActive = true;

        }
        /*//当面板可见时，如果是点击其他的装备，不能关闭
        else if ( UIManager.isBagEquipInfoPanelActive == true )
        {
            //得到背包装备信息面板上的CanvasGroup组件
            GameObject equipInfoPanel = GameObject.Find("背包装备信息面板");
            CanvasGroup canvasGroup = equipInfoPanel.GetComponent<CanvasGroup>();

            // 设置透明度为0
            canvasGroup.alpha = 0f;

            // 禁用交互性
            canvasGroup.interactable = false;
            canvasGroup.blocksRaycasts = false;

            //改变变量
            UIManager.isBagEquipInfoPanelActive = false;
        }*/
    }
}
