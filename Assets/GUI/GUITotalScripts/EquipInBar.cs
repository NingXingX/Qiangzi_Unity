using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EquipInBar : MonoBehaviour
{
    [Header("引用组件")]
    public Text equiplevelText;

    [Header("变量")]
    public int equipLevel;

    private void Update()
    {
        UpdataEquipBarInformation();
    }

    public void UpdataEquipBarInformation()
    {
        Transform level = transform.Find("装备等级");
        if ( level != null )
        {
            equiplevelText = level.GetComponent<Text>();
            equiplevelText.text = UIManager.nowEquipGrade.ToString();
        }

    }
}
