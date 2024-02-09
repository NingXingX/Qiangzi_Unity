using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//��ǰ��ɫ������
public class CharacterManager : MonoBehaviour
{
    //��ɫ���ȫ�ֱ���
    #region

    [Header("��ǰ��ɫ��Ϣ")]
    //��ǰ��ɫID
    public static int nowChaID;
    //��ǰ��ɫ�ȼ�
    public static int nowChaLevel;
    //��ǰ��ɫ����ֵ
    public static int nowChaShieldValue;
    //��ǰ��ɫѪ��
    public static int nowChaHpValue;
    #endregion


    //������
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
