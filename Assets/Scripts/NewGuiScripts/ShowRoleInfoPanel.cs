using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class ShowRoleInfoPanel : MonoBehaviour
{
    //淡入淡出参数
    public float fadeDuration = 1f;//间隔
    public float fadeDelay = 0f;//延迟

    //判断信息栏是否开启
    public bool isInfoDisplay = false;

    //所使用的CanvasGroup组件
    public CanvasGroup infoCanvasGroup;

    public void roleInfoPanelFade()
    {
        if (isInfoDisplay == false )
        {
            // 使用DoTween插件实现UI组件的透明度渐变
            infoCanvasGroup.DOFade(1f, fadeDuration).SetDelay(fadeDelay);

            //让CanvasGroup组件可以被交互
            infoCanvasGroup.interactable = true;
            infoCanvasGroup.blocksRaycasts = true;

            //改变判断变量
            isInfoDisplay = true;
        }
        else
        {
            // 使用DoTween插件实现UI组件的透明度渐变
            infoCanvasGroup.DOFade(0f, fadeDuration).SetDelay(fadeDelay);

            //让CanvasGroup组件可以被交互
            infoCanvasGroup.interactable = false;
            infoCanvasGroup.blocksRaycasts = false;

            //改变判断变量
            isInfoDisplay = false;
        }

    }
}
