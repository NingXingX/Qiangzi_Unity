using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    //角色相关全局变量
    #region

    [Header("当前角色信息")]
    //当前角色ID
    public static int nowChaID = 10001;
    //当前角色等级
    public static int nowChaLevel = 10;
    //当前角色护盾值
    public static int nowChaShieldValue = 5;
    //当前角色血量
    public static int nowChaHpValue = 60;
    #endregion


    //单例化
    private static CharacterManager instance;
    public static CharacterManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<CharacterManager>();

                if (instance == null)
                {
                    GameObject singletonObject = new GameObject();
                    instance = singletonObject.AddComponent<CharacterManager>();
                    singletonObject.name = "CharacterManager";
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
