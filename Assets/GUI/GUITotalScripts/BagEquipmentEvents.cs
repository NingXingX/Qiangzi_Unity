using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//���ڱ�����װ����Ԥ����ű�
public class BagEquipmentEvents : MonoBehaviour
{
    [Header("װ������")]
    //���װ����ID
    public int thisEquipID;
    //���װ��������
    public int thisEquipType = 1;
    //װ��Ʒ�ʣ��ȼ���
    public int thisEquipGrade;

    [Header("�������")]
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
        equipInfoPanel = GameObject.Find("����װ����Ϣ���");
    }

    public void GenerateRandomEquipID()
    {
        thisEquipID = Random.Range(10011,10017);
        thisEquipGrade = Random.Range(1,6);
    }

    //������Ϣ�����
    public void DisplayEquipInfo(int equipmentID)
    {

        Transform level = transform.Find("����װ���ȼ��ı�");
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
        print("UI�������е�ǰ������IDΪ��" + UIManager.nowEquipID);
    }

    public void EquipController()
    {
        //��װ����岻�ɼ�ʱ��Ҫ�����ɼ�
        if ( UIManager.isBagEquipInfoPanelActive == false )
        {
            //�õ�����װ����Ϣ����ϵ�CanvasGroup���
            GameObject equipInfoPanel = GameObject.Find("����װ����Ϣ���");
            CanvasGroup canvasGroup = equipInfoPanel.GetComponent<CanvasGroup>();

            // ����͸����Ϊ0
            canvasGroup.alpha = 1f;

            // ���ý�����
            canvasGroup.interactable = true;
            canvasGroup.blocksRaycasts = true;

            //�ı����
            UIManager.isBagEquipInfoPanelActive = true;

        }
        /*//�����ɼ�ʱ������ǵ��������װ�������ܹر�
        else if ( UIManager.isBagEquipInfoPanelActive == true )
        {
            //�õ�����װ����Ϣ����ϵ�CanvasGroup���
            GameObject equipInfoPanel = GameObject.Find("����װ����Ϣ���");
            CanvasGroup canvasGroup = equipInfoPanel.GetComponent<CanvasGroup>();

            // ����͸����Ϊ0
            canvasGroup.alpha = 0f;

            // ���ý�����
            canvasGroup.interactable = false;
            canvasGroup.blocksRaycasts = false;

            //�ı����
            UIManager.isBagEquipInfoPanelActive = false;
        }*/
    }
}
