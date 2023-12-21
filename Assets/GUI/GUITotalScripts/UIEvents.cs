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
        //当装备栏面板可见时，要让他不可见
        if (UIManager.isEquipmentBarActive == true)
        {
            //得到装备栏面板上的CanvasGroup组件
            GameObject equipBarPanel = GameObject.Find("ChaEquipmentBarPanel");
            CanvasGroup canvasGroup = equipBarPanel.GetComponent<CanvasGroup>();

            // 设置透明度为0
            canvasGroup.alpha = 0f;

            // 禁用交互性
            canvasGroup.interactable = false;
            canvasGroup.blocksRaycasts = false;

            //改变变量
            UIManager.isEquipmentBarActive = false;
        }
    }

    //找到并展示角色装备栏面板
    public void DisplayChaEquipPanel()
    {
        //当装备栏面板不可见时，要让他可见
        if (UIManager.isEquipmentBarActive == false)
        {
            //得到装备栏面板上的CanvasGroup组件
            GameObject equipBarPanel = GameObject.Find("ChaEquipmentBarPanel");
            CanvasGroup canvasGroup = equipBarPanel.GetComponent<CanvasGroup>();

            // 设置透明度为0
            canvasGroup.alpha = 1f;

            // 禁用交互性
            canvasGroup.interactable = true;
            canvasGroup.blocksRaycasts = true;

            //改变变量
            UIManager.isEquipmentBarActive = true;
        }
    }


    public void EquipInfoController()
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
    }
}
