using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class MoveRoleStatusPanel : MonoBehaviour
{
    [Header("上下滑动")]
    public RectTransform uiComponent;
    public bool isRoleDisplay = false;
    public Vector3 PageStartPosition;//页面开始位置
    public Vector3 PageEndPosition;//页面结束位置

    [Header("切换页码")]
    public int nowPage = 1;
    public Text nowPageTitle;//当前页码名称
    public Text nowPageNum;//当前页码页数
    public RectTransform pageComponent_1;
    public RectTransform pageComponent_2;
    public Vector3 PageStartPosition_1;//页码1开始位置
    public Vector3 PageEndPosition_1;//页码1结束位置

    public Vector3 PageStartPosition_2;//页码2开始位置
    public Vector3 PageEndPosition_2;//页码2结束位置

    private void Start()
    {
        //上下滑动功能
        // 获取UI组件的初始位置
        PageStartPosition = uiComponent.anchoredPosition3D;
        // 获取UI组件的终点位置
        PageEndPosition = new Vector3(PageStartPosition.x, PageStartPosition.y - 1000f, PageStartPosition.z);

        //左右页码切换功能
        // 获得页码1的初始位置
        PageStartPosition_1 = pageComponent_1.anchoredPosition3D;
        // 获取页码1的终点位置
        PageEndPosition_1 = new Vector3(PageStartPosition_1.x - 800f, PageStartPosition_1.y, PageStartPosition_1.z);

        // 获得页码2开始位置
        PageStartPosition_2 = pageComponent_2.anchoredPosition3D;
        // 获得页码2结束位置
        PageEndPosition_2 = new Vector3(PageStartPosition_2.x - 800f, PageStartPosition_2.y, PageStartPosition_2.z);
    }

    //角色状态界面上下滑动功能
    public void ChangeRoleStatusPanel()
    {
        
        Vector3 nowPosition = uiComponent.anchoredPosition3D;

        if( isRoleDisplay == false && nowPosition == PageStartPosition)
        {
            //得到当前位置
            nowPosition = uiComponent.anchoredPosition3D;

            // 设置目标位置
            Vector3 targetPosition = new Vector3(PageStartPosition.x, PageStartPosition.y - 1000f, PageStartPosition.z);

            // 使用DoTween插件实现UI组件的移动
            uiComponent.DOAnchorPos3D(targetPosition, 1f);

            //改变变量
            isRoleDisplay = true;

        }
        else if ( isRoleDisplay == true && nowPosition == PageEndPosition)
        {
            // 设置目标位置
            Vector3 targetPosition = new Vector3(PageStartPosition.x, PageStartPosition.y, PageStartPosition.z);

            // 使用DoTween插件实现UI组件的移动
            uiComponent.DOAnchorPos3D(targetPosition, 1f);

            //改变变量
            isRoleDisplay = false;
        }
        
    }

    //角色状态界面左右滑动切换页码功能
    //向右滑动
    public void ChangeRoleStatusPanelPage_ToRight()
    {
        //根据当前页码判断
        if( nowPage == 1)
        {
            // 设置目标位置
            Vector3 targetPosition1 = PageEndPosition_1;
            Vector3 targetPosition2 = PageEndPosition_2;

            // 使用DoTween插件实现页码2的移动
            pageComponent_1.DOAnchorPos3D(targetPosition1, 1f);

            // 使用DoTween插件实现页码1的移动
            pageComponent_2.DOAnchorPos3D(targetPosition2, 1f);

            //改变页码
            nowPage = 2;

            //改变文本
            nowPageTitle.text = "页码2";
            nowPageNum.text = "2/2";
        }
    }
    //向左移动
    public void ChangeRoleStatusPanelPage_ToLeft()
    {
        //根据当前页码判断
        if (nowPage == 2)
        {
            // 设置目标位置
            Vector3 targetPosition1 = PageStartPosition_1;
            Vector3 targetPosition2 = PageStartPosition_2;

            // 使用DoTween插件实现页码2的移动
            pageComponent_1.DOAnchorPos3D(targetPosition1, 1f);

            // 使用DoTween插件实现页码1的移动
            pageComponent_2.DOAnchorPos3D(targetPosition2, 1f);

            //改变页码
            nowPage = 1;

            //改变文本
            nowPageTitle.text = "角色信息";
            nowPageNum.text = "1/2";
        }
    }
}
