using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIEvents : MonoBehaviour
{

    [Header("得到游戏对象")]
    //得到设置面板
    public GameObject settingPanel;
    public bool isSettingPanelActive = false;
    //得到角色装备面板
    public GameObject chaEquipPanel;
    public bool isEquipPanelActive = false;


    public void ToLevelSelect()
    {
        SceneManager.LoadScene(1);
    }


    //回到主菜单
    public void BackToMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    //取消设置界面按钮
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

    //打开设置面板
    public void DisplaySettingPanel()
    {
        settingPanel.SetActive(true);
        isSettingPanelActive = true;
        HideChaEquipPanel();
    }

    //隐藏设置面板
    public void HideSettingPanel()
    {
        settingPanel.SetActive(false);
        isSettingPanelActive = false;
    }

    //设置面板按钮
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

   

    //找到并关闭角色装备栏面板
    public void HideChaEquipPanel()
    {
        chaEquipPanel.SetActive(false);
        isEquipPanelActive = false;
    }

    //找到并展示角色装备栏面板
    public void DisplayChaEquipPanel()
    {
        chaEquipPanel.SetActive(true);
        isEquipPanelActive = true;
    }
}
