using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class ShowMapPanel : MonoBehaviour
{
    //淡入淡出的棋盘部分CanvasGroup组件
    public CanvasGroup canvasGroupLeft;
    public CanvasGroup canvasGroupRight;

    //淡入淡出参数
    public float fadeDuration = 1f;//间隔
    public float fadeDelay = 0f;//延迟

    //判断地图是否开启
    public bool isMapDisplay = false;

    public void chessBoardFade()
    {
        //当地图没有开启时
        if( isMapDisplay == false )
        {
            // 使用DoTween插件实现UI组件的透明度渐变
            canvasGroupLeft.DOFade(0f, fadeDuration).SetDelay(fadeDelay);
            canvasGroupRight.DOFade(0f, fadeDuration).SetDelay(fadeDelay);

            //让CanvasGroup组件无法被交互
            canvasGroupLeft.interactable = false;
            canvasGroupLeft.blocksRaycasts = false;
            canvasGroupRight.interactable = false;
            canvasGroupRight.blocksRaycasts = false;

            //改变判断变量
            isMapDisplay = true;
        }
        //当地图开启时
        else
        {
            // 使用DoTween插件实现UI组件的透明度渐变
            canvasGroupLeft.DOFade(1f, fadeDuration).SetDelay(fadeDelay);
            canvasGroupRight.DOFade(1f, fadeDuration).SetDelay(fadeDelay);

            //让CanvasGroup组件可以被交互
            canvasGroupLeft.interactable = true;
            canvasGroupLeft.blocksRaycasts = true;
            canvasGroupRight.interactable = true;
            canvasGroupRight.blocksRaycasts = true;

            //改变判断变量
            isMapDisplay = false;
        }
    }
}
