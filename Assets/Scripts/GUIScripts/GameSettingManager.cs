using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//用于控制全局游戏设置的脚本
public class GameSettingManager : MonoBehaviour
{
    //游戏设置全局变量
    #region
    [Header("音乐音效")]
    //控制全局的音乐开关与大小
    public static bool openMusic = false;
    public static int musicVolume = 66;
    //控制全局的音效开关与大小
    public static bool openSound = false;
    public static int soundVolume = 66;
    #endregion

    //单例化
    private static GameSettingManager instance;

    public static GameSettingManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<GameSettingManager>();

                if (instance == null)
                {
                    GameObject singletonObject = new GameObject();
                    instance = singletonObject.AddComponent<GameSettingManager>();
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
    }

   

}
