using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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



    void Start()
    {
        GenerateRandomEquipID();
        DisplayEquipInfo(thisEquipID);
    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale = new Vector3(1f, 1f, 1f);
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
}
