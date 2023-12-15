using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//用于管理几乎所有UI变量的管理器
public class UIManager : MonoBehaviour
{

    //装备相关的变量
    [Header("装备相关变量")]
    public static int nowEquipID = 10011;//当前选中的装备的ID（无论是在装备栏还是在背包栏） 
    public static int nowEquipLevel;//当前选中的装备的等级
    public static int nowEquipGrade;//当前选中装备的稀有度
    public static int[,] EquipIDArray = new int [6, 9];

    //角色背包装备信息面板
    public static bool isBagEquipInfoPanelActive = false;

    //角色相关的变量
    [Header("角色相关变量")]
    public static int nowCharacterNumberInUI = 0;
    public static int[] nowCharacterEquipNumber = new int[6];

    //单例化
    private static UIManager instance;

    public static UIManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<UIManager>();

                if (instance == null)
                {
                    GameObject singletonObject = new GameObject();
                    instance = singletonObject.AddComponent<UIManager>();
                    singletonObject.name = "GameSettingManager";
                    DontDestroyOnLoad(singletonObject);
                }
            }
            return instance;
        }
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        for(int i = 0; i< 6; i ++)
        {
            for(int j = 0; j < 9; j ++)
            {
                EquipIDArray[i,j] = 0;
            }
        }

        for ( int i = 0; i < 6; i++)
        {
            nowCharacterEquipNumber[i] = 0;
        }
    }



}
