using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//���ڹ���������UI�����Ĺ�����
public class UIManager : MonoBehaviour
{

    //װ����صı���
    [Header("װ����ر���")]
    public static int nowEquipID = 10011;//��ǰѡ�е�װ����ID����������װ���������ڱ������� 
    public static int nowEquipLevel;//��ǰѡ�е�װ���ĵȼ�
    public static int nowEquipGrade;//��ǰѡ��װ����ϡ�ж�
    public static int[,] EquipIDArray = new int [6, 9];

    //��ɫ����װ����Ϣ���
    public static bool isBagEquipInfoPanelActive = false;

    //��ɫ��صı���
    [Header("��ɫ��ر���")]
    public static int nowCharacterNumberInUI = 0;
    public static int[] nowCharacterEquipNumber = new int[6];

    //������
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
