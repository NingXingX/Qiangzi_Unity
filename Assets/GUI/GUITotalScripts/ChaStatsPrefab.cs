using UnityEngine;
using UnityEngine.UI;

//��ɫ״̬��Ԥ����Ľű�
public class ChaStatsPrefab : MonoBehaviour
{
    [Header("UI���")]
    //��ɫID
    /*public int CharacterID;
    //��ɫ�ȼ�
    public int CharacterLevel;*/

    //��ɫ�ƺ����
    public Text titletext;
    //��ɫ�������
    public Text chaNametext;
    //��ɫ���������
    public Slider shieldSlider;
    //��ɫѪ�������
    public Slider hpSlider;
    //Ѫ����ֵ�ı����
    public Text hpText;
    //������ֵ�ı����
    public Text shieldText;

    [Header("����")]
    private Role cachedRole;

    public UICharacterStateViewComp OwnComp;



    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        UpdateStatsInfo(this.cachedRole);

    }

    //���½�ɫ״̬����Ϣ
    public void UpdateStatsInfo(Role role)
    {

        this.cachedRole = role;
        if (this.cachedRole == null)
        {
            return;
        }

        //�õ�Character������
        //var chaData = CharacterDataLoader.Instance;
        //CharacterData characterData = chaData.GetData(ID);
   

        //�ı��ɫ�ƺ��ı�
        Transform titleText = transform.Find("��ɫ�ƺ�");
        if (titleText != null)
        {
            //�õ�Content_text������
            var content_textData = Content_textDataLoader.Instance;
            Content_textData content_TextData = content_textData.GetData(role.CharTitle);

            titletext = titleText.GetComponent<Text>();
            titletext.text = content_TextData.ChineseTranslate;
        }

        //�ı��ɫ�����ı�
        Transform chanameText = transform.Find("��ɫ����");
        if (chanameText != null)
        {
            //�õ�Content_text������
            var content_textData = Content_textDataLoader.Instance;
            Content_textData content_TextData = content_textData.GetData(role.CharName);

            chaNametext = chanameText.GetComponent<Text>();
            chaNametext.text = content_TextData.ChineseTranslate;
        }

        //�ı��ɫ��������Ѫ����
        //Read_Shield_And_HpSlider();
        //�õ���ɫGroupID
        //int ID = Level + GroupID * 100;

        //�ı��ɫ������
        Transform shieldslider = transform.Find("��ɫ������");
        if (shieldslider != null)
        {
            //�õ�Character_attribute��ɫ���Ա�����
            var character_AttributeData = Character_attributeDataLoader.Instance;
            //Character_attributeData cha_attributeData = character_AttributeData.GetData(GroupID, ID);
            shieldSlider = shieldslider.GetComponent<Slider>();
            float result = role.Shields * 1.0f / role.MaxShield;
            shieldSlider.value = result;
            //print(shieldSlider.value);
        }

        //�ı��ɫѪ����
        Transform hpslider = transform.Find("��ɫѪ��");
        if (hpslider != null)
        {
            //�õ�Character_attribute��ɫ���Ա�����
            var character_AttributeData = Character_attributeDataLoader.Instance;
            //Character_attributeData cha_attributeData = character_AttributeData.GetData(GroupID, ID);
            hpSlider = hpslider.GetComponent<Slider>();
            float result = role.Hp * 1.0f / role.MaxHp;
            hpSlider.value = result;
            //print(hpSlider.value);
        }

        //�ı�Ѫ����ֵ�ı�
        Transform hp = transform.Find("Ѫ����ֵ�ı�");
        if ( hp != null )
        {
            hpText = hp.GetComponent<Text>();
            hpText.text = role.Hp + " / " + role.MaxHp;
        }

        //�ı令����ֵ�ı�
        Transform shield = transform.Find("������ֵ�ı�");
        if( shield != null )
        {
            shieldText = shield.GetComponent<Text>();
            shieldText.text = role.Shields + " / " + role.MaxShield;
        }
    }

    //private void Read_Shield_And_HpSlider()
    //{
    //    //�õ���ɫGroupID
    //    //int ID = Level + GroupID * 100;

    //    //�ı��ɫ������
    //    Transform shieldslider = transform.Find("��ɫ������");
    //    if (shieldslider != null)
    //    {
    //        //�õ�Character_attribute��ɫ���Ա�����
    //        var character_AttributeData = Character_attributeDataLoader.Instance;
    //        //Character_attributeData cha_attributeData = character_AttributeData.GetData(GroupID, ID);
    //        shieldSlider = shieldslider.GetComponent<Slider>();
    //        float result = CharacterManager.nowChaShieldValue * 1.0f / role.Shields;
    //        shieldSlider.value = result;
    //        //print(shieldSlider.value);
    //    }

    //    //�ı��ɫѪ����
    //    Transform hpslider = transform.Find("��ɫѪ��");
    //    if(hpslider != null)
    //    {
    //        //�õ�Character_attribute��ɫ���Ա�����
    //        var character_AttributeData = Character_attributeDataLoader.Instance;
    //        Character_attributeData cha_attributeData = character_AttributeData.GetData(GroupID, ID);
    //        hpSlider = hpslider.GetComponent<Slider>();
    //        float result = CharacterManager.nowChaHpValue * 1.0f / cha_attributeData.Hp;
    //        shieldSlider.value = result;
    //        hpSlider.value = result;
    //        //print(hpSlider.value);
    //    }
    //}

    //ѡ�е�ǰ��ɫ����UI��
    public void ChangeNowCharacterID()
    {
        this.OwnComp.RoleOnSelect(this.cachedRole);
    }
}
