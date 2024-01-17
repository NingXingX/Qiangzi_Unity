using UnityEngine;
using UnityEngine.UI;

//角色状态栏预制体的脚本
public class ChaStatsPrefab : MonoBehaviour
{
    [Header("UI组件")]
    //角色ID
    /*public int CharacterID;
    //角色等级
    public int CharacterLevel;*/

    //角色称号组件
    public Text titletext;
    //角色名称组件
    public Text chaNametext;
    //角色护盾条组件
    public Slider shieldSlider;
    //角色血量条组件
    public Slider hpSlider;
    //血量数值文本组件
    public Text hpText;
    //护盾数值文本组件
    public Text shieldText;

    [Header("变量")]
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

    //更新角色状态栏信息
    public void UpdateStatsInfo(Role role)
    {

        this.cachedRole = role;
        if (this.cachedRole == null)
        {
            return;
        }

        //得到Character表数据
        //var chaData = CharacterDataLoader.Instance;
        //CharacterData characterData = chaData.GetData(ID);
   

        //改变角色称号文本
        Transform titleText = transform.Find("角色称号");
        if (titleText != null)
        {
            //得到Content_text表数据
            var content_textData = Content_textDataLoader.Instance;
            Content_textData content_TextData = content_textData.GetData(role.CharTitle);

            titletext = titleText.GetComponent<Text>();
            titletext.text = content_TextData.ChineseTranslate;
        }

        //改变角色名称文本
        Transform chanameText = transform.Find("角色姓名");
        if (chanameText != null)
        {
            //得到Content_text表数据
            var content_textData = Content_textDataLoader.Instance;
            Content_textData content_TextData = content_textData.GetData(role.CharName);

            chaNametext = chanameText.GetComponent<Text>();
            chaNametext.text = content_TextData.ChineseTranslate;
        }

        //改变角色护盾条和血量条
        //Read_Shield_And_HpSlider();
        //得到角色GroupID
        //int ID = Level + GroupID * 100;

        //改变角色护盾条
        Transform shieldslider = transform.Find("角色护盾条");
        if (shieldslider != null)
        {
            //得到Character_attribute角色属性表数据
            var character_AttributeData = Character_attributeDataLoader.Instance;
            //Character_attributeData cha_attributeData = character_AttributeData.GetData(GroupID, ID);
            shieldSlider = shieldslider.GetComponent<Slider>();
            float result = role.Shields * 1.0f / role.MaxShield;
            shieldSlider.value = result;
            //print(shieldSlider.value);
        }

        //改变角色血量条
        Transform hpslider = transform.Find("角色血条");
        if (hpslider != null)
        {
            //得到Character_attribute角色属性表数据
            var character_AttributeData = Character_attributeDataLoader.Instance;
            //Character_attributeData cha_attributeData = character_AttributeData.GetData(GroupID, ID);
            hpSlider = hpslider.GetComponent<Slider>();
            float result = role.Hp * 1.0f / role.MaxHp;
            hpSlider.value = result;
            //print(hpSlider.value);
        }

        //改变血量数值文本
        Transform hp = transform.Find("血量数值文本");
        if ( hp != null )
        {
            hpText = hp.GetComponent<Text>();
            hpText.text = role.Hp + " / " + role.MaxHp;
        }

        //改变护盾数值文本
        Transform shield = transform.Find("护盾数值文本");
        if( shield != null )
        {
            shieldText = shield.GetComponent<Text>();
            shieldText.text = role.Shields + " / " + role.MaxShield;
        }
    }

    //private void Read_Shield_And_HpSlider()
    //{
    //    //得到角色GroupID
    //    //int ID = Level + GroupID * 100;

    //    //改变角色护盾条
    //    Transform shieldslider = transform.Find("角色护盾条");
    //    if (shieldslider != null)
    //    {
    //        //得到Character_attribute角色属性表数据
    //        var character_AttributeData = Character_attributeDataLoader.Instance;
    //        //Character_attributeData cha_attributeData = character_AttributeData.GetData(GroupID, ID);
    //        shieldSlider = shieldslider.GetComponent<Slider>();
    //        float result = CharacterManager.nowChaShieldValue * 1.0f / role.Shields;
    //        shieldSlider.value = result;
    //        //print(shieldSlider.value);
    //    }

    //    //改变角色血量条
    //    Transform hpslider = transform.Find("角色血条");
    //    if(hpslider != null)
    //    {
    //        //得到Character_attribute角色属性表数据
    //        var character_AttributeData = Character_attributeDataLoader.Instance;
    //        Character_attributeData cha_attributeData = character_AttributeData.GetData(GroupID, ID);
    //        hpSlider = hpslider.GetComponent<Slider>();
    //        float result = CharacterManager.nowChaHpValue * 1.0f / cha_attributeData.Hp;
    //        shieldSlider.value = result;
    //        hpSlider.value = result;
    //        //print(hpSlider.value);
    //    }
    //}

    //选中当前角色传到UI中
    public void ChangeNowCharacterID()
    {
        this.OwnComp.RoleOnSelect(this.cachedRole);
    }
}
