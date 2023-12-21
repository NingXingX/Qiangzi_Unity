using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIEvents : MonoBehaviour
{

    [Header("�õ���Ϸ����")]
    //�õ��������
    public GameObject settingPanel;
    public bool isSettingPanelActive = false;

    //�õ���ɫװ�����
    public GameObject chaEquipPanel;
    public bool isEquipPanelActive = false;


 


    public void ToLevelSelect()
    {
        SceneManager.LoadScene(1);
    }


    //�ص����˵�
    public void BackToMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    //ȡ�����ý��水ť
    public void CancelButton()
    {
        HideSettingPanel();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SettingPanel();
        }
    }

    //���������
    public void DisplaySettingPanel()
    {
        settingPanel.SetActive(true);
        isSettingPanelActive = true;
        HideChaEquipPanel();
    }

    //�����������
    public void HideSettingPanel()
    {
        settingPanel.SetActive(false);
        isSettingPanelActive = false;
    }

    //������尴ť
    public void SettingPanel()
    {
        if (isSettingPanelActive)
        {
            HideSettingPanel();
        }
        else
        {
            DisplaySettingPanel();
        }
    }

   

    //�ҵ����رս�ɫװ�������
    public void HideChaEquipPanel()
    {
        //��װ�������ɼ�ʱ��Ҫ�������ɼ�
        if (UIManager.isEquipmentBarActive == true)
        {
            //�õ�װ��������ϵ�CanvasGroup���
            GameObject equipBarPanel = GameObject.Find("ChaEquipmentBarPanel");
            CanvasGroup canvasGroup = equipBarPanel.GetComponent<CanvasGroup>();

            // ����͸����Ϊ0
            canvasGroup.alpha = 0f;

            // ���ý�����
            canvasGroup.interactable = false;
            canvasGroup.blocksRaycasts = false;

            //�ı����
            UIManager.isEquipmentBarActive = false;
        }
    }

    //�ҵ���չʾ��ɫװ�������
    public void DisplayChaEquipPanel()
    {
        //��װ������岻�ɼ�ʱ��Ҫ�����ɼ�
        if (UIManager.isEquipmentBarActive == false)
        {
            //�õ�װ��������ϵ�CanvasGroup���
            GameObject equipBarPanel = GameObject.Find("ChaEquipmentBarPanel");
            CanvasGroup canvasGroup = equipBarPanel.GetComponent<CanvasGroup>();

            // ����͸����Ϊ0
            canvasGroup.alpha = 1f;

            // ���ý�����
            canvasGroup.interactable = true;
            canvasGroup.blocksRaycasts = true;

            //�ı����
            UIManager.isEquipmentBarActive = true;
        }
    }


    public void EquipInfoController()
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
    }
}
