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
        chaEquipPanel.SetActive(false);
        isEquipPanelActive = false;
    }

    //�ҵ���չʾ��ɫװ�������
    public void DisplayChaEquipPanel()
    {
        chaEquipPanel.SetActive(true);
        isEquipPanelActive = true;
    }
}
