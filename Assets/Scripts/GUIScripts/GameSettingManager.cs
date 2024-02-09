using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//���ڿ���ȫ����Ϸ���õĽű�
public class GameSettingManager : MonoBehaviour
{
    //��Ϸ����ȫ�ֱ���
    #region
    [Header("������Ч")]
    //����ȫ�ֵ����ֿ������С
    public static bool openMusic = false;
    public static int musicVolume = 66;
    //����ȫ�ֵ���Ч�������С
    public static bool openSound = false;
    public static int soundVolume = 66;
    #endregion

    //������
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
