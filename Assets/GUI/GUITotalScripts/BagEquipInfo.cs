using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//��ɫ������װ����Ϣ���Ľű�
public class BagEquipInfo : MonoBehaviour
{
    [Header("��Ϣ���ͨ�����")]
    public Text equipNameText;
    public Text equipTypeText;
    public Text glossaryText1;
    public Text glossaryText2;
    public Text glossaryText3;

    [Header("������װ�����")]
    public Text damageText;
    public Text frequencyText;
    public Text distanceText;
    public Text hitText;
    public Text critText;
    public Text leechText;

    [Header("װ�����������")]
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
        //�õ�װ���������
        var equip = EquipDataLoader.Instance;
        EquipData equipData = equip.GetData(equipid);

        //����װ������
        Transform name = transform.Find("װ�������ı�");
        if ( name != null )
        {
            equipNameText = name.GetComponent<Text>();
            string result = "EquipName_" + equipid.ToString();

            //�õ�Content_text�ı����ݱ�����
            var content = Content_textDataLoader.Instance;
            Content_textData contentData = content.GetData(result);
            equipNameText.text = contentData.ChineseTranslate;

        }

        //����װ������
        Transform type = transform.Find("װ�������ı�");
        if (type != null)
        {
            equipTypeText = type.GetComponent<Text>();
            equipTypeText.text = "����";
        }

        //���������˺�
        Transform damage = transform.Find("�˺��ı�");
        if ( damage != null)
        {
            damageText = damage.GetComponent<Text>();
            damageText.text = equipData.Attack.ToString();
        }

        //��������Ƶ��
        Transform frequency = transform.Find("Ƶ���ı�");
        if (frequency != null)
        {
            frequencyText = frequency.GetComponent<Text>();
            frequencyText.text = equipData.AttackSpeed.ToString();
        }

        //������������
        Transform distance = transform.Find("�����ı�");
        if (distance != null)
        {
            distanceText = distance.GetComponent<Text>();
            distanceText.text = equipData.AttackRange.ToString();
        }

        //������������
        Transform hit = transform.Find("�����ı�");
        if ( hit != null)
        {
            hitText = hit.GetComponent<Text>();
            hitText.text = equipData.HitRate.ToString();
        }

        //������������
        Transform crit = transform.Find("�����ı�");
        if (crit != null)
        {
            critText = crit.GetComponent<Text>();
            critText.text = equipData.CritRate.ToString();
        }

        //����������Ѫ
        Transform leech = transform.Find("��Ѫ�ı�");
        if (leech != null)
        {
            leechText = leech.GetComponent<Text>();
            leechText.text = equipData.HpSteal.ToString();
        }

    }

    //װ����ť����
    public void WearEquipmentButton()
    {
        UIManager.EquipIDArray[UIManager.nowCharacterNumberInUI, UIManager.nowCharacterEquipNumber[UIManager.nowCharacterNumberInUI]] = UIManager.nowEquipID;
        UIManager.nowCharacterEquipNumber[UIManager.nowCharacterNumberInUI]++;
        print("UI�������еĵ�ǰ��ɫװ������Ϊ��" + UIManager.nowCharacterEquipNumber[UIManager.nowCharacterNumberInUI]);
        print("UI��������װ������Ϊ:" + UIManager.EquipIDArray);
    }

    //��ʼʱ�ı�CanvasGroup
    public void ChangeCanvasGroup()
    {
        // ��ȡCanvasGroup���
        CanvasGroup canvasGroup = GetComponent<CanvasGroup>();

        // ����͸����Ϊ0
        canvasGroup.alpha = 0f;

        // ���ý�����
        canvasGroup.interactable = false;
        canvasGroup.blocksRaycasts = false;

        UIManager.isBagEquipInfoPanelActive = false;
    }
}
