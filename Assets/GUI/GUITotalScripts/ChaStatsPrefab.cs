using UnityEngine;
using UnityEngine.UI;

//��ɫ״̬��Ԥ����Ľű�
public class ChaStatsPrefab : MonoBehaviour
{
    [Header("UI���")]
    //��ɫID
    public int CharacterID;
    //��ɫ�ȼ�
    public int CharacterLevel;
    //��ɫ�ƺ����
    public Text titletext;
    //��ɫ�������
    public Text chaNametext;
    //��ɫ���������
    public Slider shieldSlider;
    //��ɫѪ�������
    public Slider hpSlider;

    [Header("����")]
    public int prefabNumerInUI;



    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateStatsInfo(CharacterID);
    }

    //���½�ɫ״̬����Ϣ
    public void UpdateStatsInfo(int ID)
    {
        //�õ�Character������
        var chaData = CharacterDataLoader.Instance;
        CharacterData characterData = chaData.GetData(ID);
   

        //�ı��ɫ�ƺ��ı�
        Transform titleText = transform.Find("��ɫ�ƺ�");
        if (titleText != null)
        {
            //�õ�Content_text������
            var content_textData = Content_textDataLoader.Instance;
            Content_textData content_TextData = content_textData.GetData(characterData.CharTitle);

            titletext = titleText.GetComponent<Text>();
            titletext.text = content_TextData.ChineseTranslate;
        }

        //�ı��ɫ�����ı�
        Transform chanameText = transform.Find("��ɫ����");
        if (chanameText != null)
        {
            //�õ�Content_text������
            var content_textData = Content_textDataLoader.Instance;
            Content_textData content_TextData = content_textData.GetData(characterData.CharName);

            chaNametext = chanameText.GetComponent<Text>();
            chaNametext.text = content_TextData.ChineseTranslate;
        }

        //�ı��ɫ��������Ѫ����
        Read_Shield_And_HpSlider(CharacterLevel, CharacterID);
        
    }

    private void Read_Shield_And_HpSlider(int Level,int GroupID)
    {
        //�õ���ɫGroupID
        int ID = Level + GroupID * 100;

        //�ı��ɫ������
        Transform shieldslider = transform.Find("��ɫ������");
        if (shieldslider != null)
        {
            //�õ�Character_attribute��ɫ���Ա�����
            var character_AttributeData = Character_attributeDataLoader.Instance;
            Character_attributeData cha_attributeData = character_AttributeData.GetData(GroupID, ID);
            shieldSlider = shieldslider.GetComponent<Slider>();
            float result = CharacterManager.nowChaShieldValue * 1.0f / cha_attributeData.Shields;
            shieldSlider.value = result;
            //print(shieldSlider.value);
        }

        //�ı��ɫѪ����
        Transform hpslider = transform.Find("��ɫѪ��");
        if(hpslider != null)
        {
            //�õ�Character_attribute��ɫ���Ա�����
            var character_AttributeData = Character_attributeDataLoader.Instance;
            Character_attributeData cha_attributeData = character_AttributeData.GetData(GroupID, ID);
            hpSlider = hpslider.GetComponent<Slider>();
            float result = CharacterManager.nowChaHpValue * 1.0f / cha_attributeData.Hp;
            shieldSlider.value = result;
            hpSlider.value = result;
            //print(hpSlider.value);
        }
    }

    public void ChangeNowCharacterID()
    {
        CharacterManager.nowChaLevel = CharacterLevel;
        CharacterManager.nowChaID = CharacterID;
        UIManager.nowCharacterNumberInUI = prefabNumerInUI;
        print("��ǰ��ɫIDΪ��" + CharacterManager.nowChaID);
    }
}