using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class MoveStorePanel : MonoBehaviour
{
    public RectTransform uiComponent;
    public bool isStoreDisplay = false;
    public Vector3 initialPosition;
    public Vector3 endPosition;
    void Start()
    {
        // 获取UI组件的初始位置
        initialPosition = uiComponent.anchoredPosition3D;
        // 获取UI组件的终点位置
        endPosition = new Vector3(initialPosition.x, initialPosition.y - 1000f, initialPosition.z);
    }


    public void ChangeStorePanel()
    {
        Vector3 nowPosition = uiComponent.anchoredPosition3D;

        if (isStoreDisplay == false && nowPosition == initialPosition)
        {
            //得到当前位置
            nowPosition = uiComponent.anchoredPosition3D;

            // 设置目标位置
            Vector3 targetPosition = new Vector3(initialPosition.x, initialPosition.y - 1000f, initialPosition.z);

            // 使用DoTween插件实现UI组件的移动
            uiComponent.DOAnchorPos3D(targetPosition, 1f);

            //改变变量
            isStoreDisplay = true;

        }
        else if ( isStoreDisplay == true && nowPosition == endPosition)
        {
            // 设置目标位置
            Vector3 targetPosition = new Vector3(initialPosition.x, initialPosition.y, initialPosition.z);

            // 使用DoTween插件实现UI组件的移动
            uiComponent.DOAnchorPos3D(targetPosition, 1f);

            //改变变量
            isStoreDisplay = false;
        }

    }
}

