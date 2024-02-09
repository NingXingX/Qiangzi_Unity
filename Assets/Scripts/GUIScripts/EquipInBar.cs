using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EquipInBar : MonoBehaviour
{
    [Header("�������")]
    public Text equiplevelText;

    [Header("����")]
    public int equipLevel;

    private void Update()
    {
        UpdataEquipBarInformation();
    }

    public void UpdataEquipBarInformation()
    {
        Transform level = transform.Find("װ���ȼ�");
        if ( level != null )
        {
            equiplevelText = level.GetComponent<Text>();
            equiplevelText.text = UIManager.nowEquipGrade.ToString();
        }

    }
}
